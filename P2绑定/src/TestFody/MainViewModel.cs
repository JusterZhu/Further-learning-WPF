using PropertyChanged;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFody
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public string GivenName { get; set; }

        public string FamilyName { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public string FullName => $"{GivenName}{FamilyName}";
    }
}
