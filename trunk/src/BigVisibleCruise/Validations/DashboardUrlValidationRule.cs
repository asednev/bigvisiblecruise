using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using CruiseControlToys.Lib;

namespace BigVisibleCruise.Validations
{
    public class DashboardUrlValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            string text = (string)value;

            if (text == string.Empty)
            {
                return new ValidationResult(false, "Please enter a dasbhoard url. This is the page that lists out the projects that are hosted by Cruise. You can see an example at http://ccnetlive.thoughtworks.com/ccnet");
            }

            try
            {
                IResolver dashboardResolver = HttpProjectXmlResolver.FromUri(new Uri(text));
                IList<ProjectStatus> projects = dashboardResolver.GetProjects();
            }
            catch
            {
                string errorMessage = string.Format("There was a problem trying to get information from {0}. Make sure that you can browse to this page in a browser and that you are using vX.X or higher of Cruise Control.", text);
                return new ValidationResult(false, errorMessage);
            }


            return ValidationResult.ValidResult;
        }
    }
}
