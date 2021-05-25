using Juster.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Chapter6
{
    public class MainViewModel
    {
        private ObservableCollection<MainModel> mainModels;

        private ICommand _selectCommand;

        public ICommand SelectCommand
        {
            get
            {
                return _selectCommand ?? (_selectCommand = AsyncCommand.Create(SelectCallback));
            }
        }

        public ICommand InsertCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand UpdateCommand { get; set; }

        public ICommand TempCommand { get; set; }

        public ObservableCollection<MainModel> MainModels { get => mainModels??(mainModels = new ObservableCollection<MainModel>()); }

        public MainViewModel()
        {
            InsertCommand = new AsyncCommand<object>(InsertCallback);
            DeleteCommand = new AsyncCommand<object>(DeleteCallback);
            UpdateCommand = new AsyncCommand<string>(UpdateCallback);
            TempCommand = new RelayCommand(TempCallback);
            SqliteDepository.Instance.Config("data source=mydb.db");
        }

        private async void TempCallback() 
        {
            await SqliteDepository.Instance.InsertValues("mytable", new string[] { "1","2","3" });
        }

        private async Task<object> InsertCallback(CancellationToken arg)
        {
            //339
            var tempData = new List<string[]>();
            for (int i = 0; i < 100; i++)
            {
                tempData.Add(new string[] { "God", "9999", "hello,world." });
            }
            Stopwatch myWatch = new Stopwatch();
            myWatch.Start();
            await SqliteDepository.Instance.InsertValueRange("mytable", tempData);
            myWatch.Stop();
            Debug.WriteLine($"{ myWatch.ElapsedMilliseconds }ms");

            //7951
            await Task.Run(async () =>
            {
                myWatch.Reset();
                myWatch.Start();
                foreach (var item in tempData)
                {
                    await SqliteDepository.Instance.InsertValues("mytable", item);
                }
                myWatch.Stop();
                Debug.WriteLine($"{ myWatch.ElapsedMilliseconds }ms");
            });
           
            return null;
        }

        private async Task<object> DeleteCallback(CancellationToken arg)
        {
            await SqliteDepository.Instance.ExecuteQuery(@"delete from mytable;");
            MainModels.Clear();
            return null;
        }

        private async Task<string> UpdateCallback(CancellationToken arg)
        {
            //SqliteDepository.Instance.UpdateValues("", new string[] { }, new string[] { }, "", "");
            return await Task.FromResult<string>(null);
        }

        private async Task SelectCallback()
        {
            var reader = await SqliteDepository.Instance.ReadFullTable("mytable");
            while (await reader.ReadAsync())
            {
                string name = reader.GetString(reader.GetOrdinal("Name"));
                int age = reader.GetInt32(reader.GetOrdinal("Age"));
                string message = reader.GetString(reader.GetOrdinal("Message"));
                MainModels.Add(new MainModel { Name = name,Age = age , Message = message });
            }
        }
    }
}
