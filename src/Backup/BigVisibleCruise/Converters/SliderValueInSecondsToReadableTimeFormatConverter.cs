using System;
using System.Globalization;
using System.Windows.Data;

namespace BigVisibleCruise.Converters
{
	public class SliderValueInSecondsToReadableTimeFormatConverter : IValueConverter
	{
		#region IValueConverter Members

		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var secondRepresentation = (double) value;
			string message = string.Empty;


			if (secondRepresentation < 60)
			{
				message = ((int) secondRepresentation) + " seconds";
			}

			if (secondRepresentation == 60)
			{
				message = "1 minute";
			}

			if (secondRepresentation > 60)
			{
				double minutes = Math.Floor(secondRepresentation/60);
				double seconds = Math.Floor(secondRepresentation%60);

				if (seconds == 0)
				{
					message = minutes + " minutes";
				}
				else
				{
					if (minutes == 1)
					{
						message = string.Format("{0} minute and {1} seconds", minutes, seconds);
					}
					else
					{
						message = string.Format("{0} minutes and {1} seconds", minutes, seconds);
					}
				}
			}

			return "Every " + message;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return null;
		}

		#endregion
	}
}
