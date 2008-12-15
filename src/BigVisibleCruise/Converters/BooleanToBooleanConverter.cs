using System;
using System.Globalization;
using System.Windows.Data;

namespace BigVisibleCruise.Converters
{
	public class BooleanToBooleanConverter : IValueConverter
	{
		#region IValueConverter Members

		public object Convert(object value, Type targetType, object valueForTrue, CultureInfo culture)
		{
			var suppliedValue = (bool) value;
			bool trueValue = (valueForTrue == null) ? true : bool.Parse((string) valueForTrue);
			return (suppliedValue == trueValue);
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return null;
		}

		#endregion
	}
}
