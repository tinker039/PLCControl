using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace PLCControl.Helper.Converter
{
    /// <summary>
    /// 转换器   bool to  color  
    /// IO中红绿状态
    /// </summary>
    [ValueConversion(typeof(bool), typeof(Color))]
    class ColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool b = (bool)value;
            if (b == true)
                return Colors.Green;
            return Colors.Red;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
