using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Data;

namespace BigVisibleCruise.Converters
{
    public class SliderValueInSecondsToReadableTimeFormatConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            double secondRepresentation = (double) value;

            if (secondRepresentation < 60)
            {
                return ((int) secondRepresentation) + " seconds";
            }

            if (secondRepresentation == 60)
            {
                return "1 minute";
            }

            if (secondRepresentation > 60)
            {
                double minutes = Math.Floor(secondRepresentation / 60);
                double seconds = Math.Floor(secondRepresentation % 60);
                
                if (seconds == 0)
                {
                    return minutes.ToString() + " minutes";
                }
                else
                {
                    if (minutes == 1)
                    {
                        return string.Format("{0} minute and {1} seconds", minutes, seconds);
                    }
                    else
                    {
                        return string.Format("{0} minutes and {1} seconds", minutes, seconds);
                    }
                }
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }

    }
}
