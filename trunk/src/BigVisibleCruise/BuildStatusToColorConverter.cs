using System;
using System.Windows.Data;
using System.Windows.Media;

namespace BigVisibleCruise
{
    [ValueConversion(typeof(string), typeof(SolidColorBrush))]
    public class BuildStatusToColorConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
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
                    throw new ApplicationException("Unexpected value: " + value.ToString());
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }

    }
}