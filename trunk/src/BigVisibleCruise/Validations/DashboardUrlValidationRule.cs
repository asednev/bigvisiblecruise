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

                return new ValidationResult(false, "Please enter the url of a dasbhoard.");
            }

            try
            {
                IResolver dashboardResolver = HttpProjectXmlResolver.FromUri(new Uri(text));
                IList<ProjectStatus> projects = dashboardResolver.GetProjects();
            }
            catch
            {
                string errorMessage = string.Format("There was a problem trying to access the dashboard." , text);
                return new ValidationResult(false, errorMessage);
            }

            return ValidationResult.ValidResult;
        }
    }
}
