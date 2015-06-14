using System;
using System.Globalization;
using System.Windows.Data;

namespace AnketaPro.Service.Converters
{
    public class StackPanelMaxWidthConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return System.Convert.ToDouble(value) / System.Convert.ToDouble(4);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
