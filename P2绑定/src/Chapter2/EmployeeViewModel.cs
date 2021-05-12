using Juster.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Chapter2
{
    public class EmployeeViewModel : BindableBase
    {
        #region MyRegion

        private double _defultContent;

        public double DefultContent
        {
            get
            {
                return _defultContent;
            }

            set
            {
                _defultContent = value;
                OnPropertyChanged("DefultContent");
            }
        }

        private double _delayContent;

        public double DelayContent
        {
            get
            {
                return _delayContent;
            }

            set
            {
                _delayContent = value;
                OnPropertyChanged("DelayContent");
            }
        }

        ObservableCollection<EmployeeModel> employees;
        public ICommand GetEmployeeCmd { get; set; }

        #endregion

        private PersonModel _person;

        public PersonModel Person 
        {
            get 
            {
                return _person;
            }

            set 
            { 
                _person = value;
                OnPropertyChanged("Person");
            } 
        }

        public EmployeeViewModel() 
        {
            DefultContent = 0.5;
            Person = new PersonModel { FirstName = "juster" , LastName = "zhu" };
            GetEmployeeCmd = new RelayCommand<EmployeeModel>(GetEmployeeAction);
            Employees.Add(new EmployeeModel { Id = "4", Name = "请选择" });
            Employees.Add(new EmployeeModel { Id = "2", Name = "wu.wang", Department = "Software" });
            Employees.Add(new EmployeeModel { Id = "3", Name = "si.li", Department = "Software" });
            Employees.Add(new EmployeeModel { Id = "1", Name = "juster.zhu", Department = "Software" });
        }

        public ObservableCollection<EmployeeModel> Employees 
        {
            get { return employees ?? (employees = new ObservableCollection<EmployeeModel>()); }
        }

        private void GetEmployeeAction(EmployeeModel model)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                MessageBox.Show($"姓名：{ model.Name },部门：{ model.Department }");
            });
        }

        //private void GetEmployeeAction(string name)
        //{
        //    Application.Current.Dispatcher.Invoke(() =>
        //    {
        //        MessageBox.Show($"姓名：{ name }");
        //    });
        //}
    }

    public class EmployeeModel : BindableBase
    {
        private string department;

        public string Department
        {
            get { return department; }
            set 
            {
                department = value;
                OnPropertyChanged("Department");
            }
        }

        private string name;

        public string Name
        {
            get 
            {
                return name;
            }
            set 
            { 
                name = value;
                OnPropertyChanged("Name");
            }
        }

        public string Id { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
