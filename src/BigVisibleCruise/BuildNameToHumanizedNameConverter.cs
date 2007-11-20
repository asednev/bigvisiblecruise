using System;
using System.Windows.Data;

namespace BigVisibleCruise
{
    [ValueConversion(typeof(string), typeof(string))]
    public class BuildNameToHumanizedNameConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value.ToString().Replace("_", " ");
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }

    }
}