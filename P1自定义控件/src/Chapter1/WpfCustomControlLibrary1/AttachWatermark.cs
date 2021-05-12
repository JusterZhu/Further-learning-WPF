using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WpfCustomControlLibrary1
{
    public class AttachWatermark
    {
        //2.定义依赖属性
        public static readonly DependencyProperty WatermarkProperty = DependencyProperty.RegisterAttached(
            "Watermark", typeof(string), typeof(AttachWatermark), new PropertyMetadata("1", new PropertyChangedCallback(OnColorChanged)));

        //3.属性监听回调
        private static void OnColorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var element = d as TextBox;
            if (element == null || e.NewValue == null) return;

            if (string.IsNullOrWhiteSpace(e.NewValue.ToString()))
            {
                element.Foreground = new SolidColorBrush(Colors.Red);
                element.Text = "Input text box watermark.";
            }
            else
            {
                element.Text = e.NewValue.ToString();
            }
        }

        //供view.cs后台文件文件c#代码显示调用
        public static string GetWatermark(DependencyObject d)
        {
            return (string)d.GetValue(WatermarkProperty);
        }

        public static void SetWatermark(DependencyObject obj, string value)
        {
            obj.SetValue(WatermarkProperty, value);
        }
    }
}
