using Juster.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Chapter3
{
    public class MainViewModel
    {
        public ICommand TestCommand { get; set; }

        public MainViewModel() 
        {
            TestCommand = new RelayCommand(TestCallback);
        }

        private void TestCallback()
        {
            Application.Current.Dispatcher.Invoke(()=> 
            {
                MessageBox.Show("hello,world.");
            });
        }
    }
}
