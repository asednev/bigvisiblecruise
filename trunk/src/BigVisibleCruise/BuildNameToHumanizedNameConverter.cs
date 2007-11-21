using System;
using System.Windows.Data;
using System.Collections.Specialized;

namespace BigVisibleCruise
{
    [ValueConversion(typeof(string), typeof(string))]
    public class BuildNameToHumanizedNameConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string startingValue = value.ToString();
            if (Properties.Settings.Default.ProjectNameSubstitutions != null)
            {
                StringCollection replacements = Properties.Settings.Default.ProjectNameSubstitutions;
                foreach (string replacement in replacements)
                {
                    string from = replacement.Split('=')[0];
                    string to = replacement.Split('=')[1];
                    if (startingValue == from)
                    {
                        return to;
                    }
                }
            }
            return value.ToString().Replace("_", " ");
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }

    }
}