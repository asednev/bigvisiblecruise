using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Data;

namespace BigVisibleCruise.Converters
{
    public class TimeSpanToDoubleConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            TimeSpan timeSpan = (TimeSpan) value;
            return (double) timeSpan.TotalSeconds;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Double aDouble = (double) value;
            return TimeSpan.FromSeconds(aDouble);
        }

    }
}
