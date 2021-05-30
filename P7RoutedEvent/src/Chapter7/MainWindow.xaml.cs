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

namespace Chapter7
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //冒泡路由，由事件源向上传递一直到根元素
            //grid1.AddHandler(Button.ClickEvent, new RoutedEventHandler(Grid_Click));
            //stackPanel1.AddHandler(Button.ClickEvent, new RoutedEventHandler(StackPanel_Click));
            //button1.AddHandler(Button.ClickEvent, new RoutedEventHandler(Button_Click));

            //隧道路由，从元素树的根部调用事件处理程序并依次向下深入直到事件源
            grid1.AddHandler(Button.PreviewMouseLeftButtonDownEvent, new RoutedEventHandler(Grid_Click));
            stackPanel1.AddHandler(Button.PreviewMouseLeftButtonDownEvent, new RoutedEventHandler(StackPanel_Click));
            button1.AddHandler(Button.PreviewMouseLeftButtonDownEvent, new RoutedEventHandler(Button_Click));
        }

        private void Grid_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Grid.Click");
        }
        private void StackPanel_Click(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
            MessageBox.Show("StackPanel.Click");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Button.Click");
        }

        //Point to Point
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Button.Click");
        }

        //Point to Point
        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Grid.MouseDown");
        }
    }
}
