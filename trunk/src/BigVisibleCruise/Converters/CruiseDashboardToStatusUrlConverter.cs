using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Data;

namespace BigVisibleCruise.Converters
{

    public class CruiseDashboardToStatusUrlConverter : IValueConverter
    {
        
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string xmlUrl = (string) value;
            return xmlUrl.Replace(@"/XmlStatusReport.aspx", string.Empty);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
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

    }

}
