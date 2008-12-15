using System;
using System.Globalization;
using System.Windows.Data;

namespace BigVisibleCruise.Converters
{
	public class TimeSpanToDoubleConverter : IValueConverter
	{
		#region IValueConverter Members

		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var timeSpan = (TimeSpan) value;
			return timeSpan.TotalSeconds;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var aDouble = (double) value;
			return TimeSpan.FromSeconds(aDouble);
		}

		#endregion
	}
}
