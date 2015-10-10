using System;
using System.Windows.Data;
using System.Windows.Media;
using System.Globalization;

namespace BigVisibleCruise.Converters
{
    [ValueConversion(typeof(string), typeof(SolidColorBrush))]
    public class BuildStatusToColorConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch (value.ToString()) 
            {
                case "Success":
                    return new SolidColorBrush(Colors.Green);
                case "Building":
                    return new SolidColorBrush(Colors.Yellow);
                case "Failure":
                case "Exception":
                    return new SolidColorBrush(Colors.Red);
                default:
                    return new SolidColorBrush(Colors.White);
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }

    }
}