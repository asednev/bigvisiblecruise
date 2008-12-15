using System;
using System.Globalization;
using System.Windows.Data;

namespace BigVisibleCruise.Converters
{
	public class CruiseDashboardToStatusUrlConverter : IValueConverter
	{
		#region IValueConverter Members

		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var xmlUrl = (string) value;
			return xmlUrl.Replace(@"/XmlStatusReport.aspx", string.Empty);
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			string inputValue = ((string) value).Trim();

			if (!inputValue.StartsWith("http://"))
			{
				inputValue = "http://" + inputValue;
			}

			if (!inputValue.EndsWith(@"/"))
			{
				inputValue += @"/";
			}

			inputValue += "XmlStatusReport.aspx";

			return inputValue;
		}

		#endregion
	}
}
