using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Chapter2
{
    public class EmployeeTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item != null && item is EmployeeModel) 
            {
                var obj = item as EmployeeModel;
                switch (obj.Id)
                {
                    case "AEmployee":
                        return (container as FrameworkElement).FindResource("ATemplate") as DataTemplate;
                    case "BEmployee":
                        return (container as FrameworkElement).FindResource("BTemplate") as DataTemplate;
                }
            }
            return base.SelectTemplate(item, container);
        }
    }
}
