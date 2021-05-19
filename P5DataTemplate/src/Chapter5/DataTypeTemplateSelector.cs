using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Chapter5
{
    public class DataTypeTemplateSelector : DataTemplateSelector
    {
        /// <summary>
        /// SelectTemplate
        /// </summary>
        /// <param name="item">Model</param>
        /// <param name="container">View</param>
        /// <returns></returns>
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is MainModel)
            {
                var model = item as MainModel;
                
                switch (model.Person)
                {
                    case Person.One:
                        return (container as FrameworkElement).FindResource("OneDataTemplate") as DataTemplate;
                    case Person.Two:
                        return (container as FrameworkElement).FindResource("TwoDataTemplate") as DataTemplate;
                    case Person.Three:
                        return (container as FrameworkElement).FindResource("ThreeDataTemplate") as DataTemplate;
                    case Person.Four:
                        return (container as FrameworkElement).FindResource("FourDataTemplate") as DataTemplate;
                    case Person.Five:
                        return (container as FrameworkElement).FindResource("FiveDataTemplate") as DataTemplate;
                    case Person.Six:
                        return (container as FrameworkElement).FindResource("SixDataTemplate") as DataTemplate;
                    case Person.Seven:
                        return (container as FrameworkElement).FindResource("SevenDataTemplate") as DataTemplate;
                }
            }
            return null;
        }
    }
}
