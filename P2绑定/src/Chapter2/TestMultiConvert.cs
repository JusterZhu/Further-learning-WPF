using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Chapter2
{
    public class TestMultiConvert : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Count() == 0) return string.Empty;

            switch (parameter as string)
            {
                case "FirstLast":
                    return $"{ values[0] }  { values[1] }";
                case "LastFirst":
                    return $"{ values[1] }  { values[0] }";
                default:
                    throw new ArgumentException($"invalid argument { parameter }");
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
