using System;
using System.Globalization;
using Microsoft.Maui.Controls;

namespace AppDatePicker
{
    public class DoubleToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double doubleValue)
            {
                return doubleValue.ToString("N3", culture); 
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return double.TryParse(value?.ToString(), out double result) ? result : 0.0;
        }
    }

}
