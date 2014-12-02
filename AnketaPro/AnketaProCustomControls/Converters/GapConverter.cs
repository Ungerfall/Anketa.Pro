using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace AnketaProCustomControls.Converters
{
    public class GapConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return new Thickness(0, System.Convert.ToDouble(value), 0, 0);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                var thickness = (Thickness) value;
                return System.Convert.ToDouble(thickness.Top);
            }
            catch (Exception)
            {
                throw new Exception(string.Format("Cannot convert, unknown value {0}", value));
            }
        }
    }
}