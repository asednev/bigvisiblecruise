using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace BigVisibleCruise.Converters
{
	public class BooleanToVisibleConverter : IValueConverter
	{
		#region IValueConverter Members

		public object Convert(object value, Type targetType, object booleanValueForVisible, CultureInfo culture)
		{
			var suppliedValue = (bool) value;
			bool visibleValue = (booleanValueForVisible == null) ? true : bool.Parse((string) booleanValueForVisible);
			return (suppliedValue == visibleValue) ? Visibility.Visible : Visibility.Collapsed;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return null;
		}

		#endregion
	}
}
