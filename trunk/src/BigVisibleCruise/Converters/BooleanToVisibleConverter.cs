using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Data;

namespace BigVisibleCruise.Converters
{
    public class BooleanToVisibleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool suppliedValue = (bool) value;
            bool visibleValue = (parameter == null) ? true : bool.Parse((string)parameter);
            return (suppliedValue == visibleValue) ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
