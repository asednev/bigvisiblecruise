using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Data;

namespace BigVisibleCruise.Converters
{
    public class LastBuildDateToDeviceIndependentUnitsConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            TimeSpan duration = DateTime.Now.Subtract((DateTime)value);
            
            if (duration.TotalMinutes < 10)
            {
                return 10d;
            }

            if (duration.TotalMinutes > 100)
            {
                return 100d;
            }

            return duration.TotalMinutes;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
