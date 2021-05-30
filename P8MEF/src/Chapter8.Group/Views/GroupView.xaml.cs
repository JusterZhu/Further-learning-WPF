using Chapter8.Group.ViewModels;
using Chapter8.Infrastructure.Common.Interfaces;
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

namespace Chapter8.Group.Views
{
    /// <summary>
    /// GroupView.xaml 的交互逻辑
    /// </summary>
    public partial class GroupView : UserControl, IView
    {
        public GroupView()
        {
            InitializeComponent();
            DataContext = new GroupViewModel();
        }
    }
}
