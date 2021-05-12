using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfCustomControlLibrary1;

namespace Chapter1._1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string _testContent;

        //public string TestContent
        //{
        //    get
        //    {
        //        return AttachWatermark.GetWatermark(BackGroundInputTest);
        //    }
        //    set
        //    {
        //        _testContent = value;
        //        AttachWatermark.SetWatermark(BackGroundInputTest, value);
        //    }
        //}

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            //Binding binding = new Binding();
            //binding.Source = InputTest;
            //binding.Path = new PropertyPath("Text");
            //BindingOperations.SetBinding(BackGroundInputTest, AttachWatermark.WatermarkProperty, binding);
        }
    }
}
