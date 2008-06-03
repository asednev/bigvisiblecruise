using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
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

                return new ValidationResult(false, "Please enter the url of a dasbhoard. You can see an example of a dashboard at http://ccnetlive.thoughtworks.com/ccnet");
            }

            try
            {
                IResolver dashboardResolver = HttpProjectXmlResolver.FromUri(new Uri(text));
                IList<ProjectStatus> projects = dashboardResolver.GetProjects();
            }
            catch
            {
                string errorMessage = string.Format("There was a problem trying to get information from {0}. Make sure that you can open that page in a browser and that is is pointing to Cruise Control dashboard.\n\nIf everything looks ok to you and the url still doesn't validate, please post a topic on www.getsatisfaction.com/bigvisiblecruise and we will do our best to track down the issue." , text);
                return new ValidationResult(false, errorMessage);
            }

            return ValidationResult.ValidResult;
        }
    }
}
