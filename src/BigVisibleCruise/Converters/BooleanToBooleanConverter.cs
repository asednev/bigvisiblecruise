using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Data;

namespace BigVisibleCruise.Converters
{

    public class BooleanToBooleanConverter : IValueConverter
    {


        public object Convert(object value, Type targetType, object valueForTrue, System.Globalization.CultureInfo culture)
        {
            bool suppliedValue = (bool)value;
            bool trueValue = (valueForTrue == null) ? true : bool.Parse((string) valueForTrue);
            return (suppliedValue == trueValue);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }

    }

}
