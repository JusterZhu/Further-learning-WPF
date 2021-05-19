using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter5
{
    public class MainViewModel
    {
        public ObservableCollection<MainModel> MainModels { get; set; }

        public MainViewModel() 
        {
            MainModels = new ObservableCollection<MainModel>();
            MainModels.Add(new MainModel { Person = Person.One , Name = "大娃" , Color = "Red" });//红色
            MainModels.Add(new MainModel { Person = Person.Two, Name = "二娃", Color = "Orinage" });//橙色
            MainModels.Add(new MainModel { Person = Person.Three, Name = "三娃", Color = "Yellow" });//黄色
            MainModels.Add(new MainModel { Person = Person.Four, Name = "四娃", Color = "Green" });//绿色
            MainModels.Add(new MainModel { Person = Person.Five, Name = "五娃", Color = "AliceBlue" });//青色
            MainModels.Add(new MainModel { Person = Person.Six, Name = "六娃", Color = "Blue" });//蓝色
            MainModels.Add(new MainModel { Person = Person.Seven, Name = "七娃", Color = "Purple" });//紫色
        }
    }
}
