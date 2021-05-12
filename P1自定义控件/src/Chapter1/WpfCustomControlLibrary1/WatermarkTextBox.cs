using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WpfCustomControlLibrary1
{
    //继承基础控件
    public class WaterMarkTextbox : TextBox
    {
        static WaterMarkTextbox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(WaterMarkTextbox), new FrameworkPropertyMetadata(typeof(WaterMarkTextbox)));
        }


        public static readonly DependencyProperty WaterMarkProperty = 
            //依赖属性名称，依赖属性数据类型，所有者的类型，属性的元数据
            DependencyProperty.Register("WaterMark", typeof(string), typeof(WaterMarkTextbox), new PropertyMetadata("Input text box watermark."));

        public string WaterMark
        {
            get { return (string)GetValue(WaterMarkProperty); }
            set { SetValue(WaterMarkProperty, value); }
        }

        public static readonly DependencyProperty WaterMarkVerticalProperty = DependencyProperty.Register("WaterMarkVertical", typeof(VerticalAlignment), typeof(WaterMarkTextbox), new PropertyMetadata(VerticalAlignment.Center));

        public VerticalAlignment WaterMarkVertical
        {
            get { return (VerticalAlignment)GetValue(WaterMarkVerticalProperty); }
            set { SetValue(WaterMarkVerticalProperty, value); }
        }
    }
}
