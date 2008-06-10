using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using BigVisibleCruise.Converters;
using BigVisibleCruise.Properties;

namespace BigVisibleCruise
{
    /// <summary>
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>

    public partial class SettingsWindow : System.Windows.Window
    {


        //TODO: Get all of this validation ish out of the codebehind

        public SettingsWindow()
        {
            InitializeComponent();
        }

        private void UrlTextboxChanged(object sender, TextChangedEventArgs args)
        {
            ValidateUrlTextBlock.Visibility = Visibility.Visible;
            DashboardUrlError.Visibility = Visibility.Collapsed;
            DashboardUrlConfirmation.Visibility = Visibility.Collapsed;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {   
            this.Close();
        }

        private void Validate_Click(object sender, RoutedEventArgs e)
        {
            ValidateUrlTextBlock.Visibility = Visibility.Collapsed;

            if (this.UrlIsValid)
            {
                DashboardUrlError.Visibility = Visibility.Visible;
            }
            else
            {
                DashboardUrlConfirmation.Visibility = Visibility.Visible;
            }
        }

        private bool UrlIsValid
        {
            get
            {    
                UrlTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                return Validation.GetErrors(UrlTextBox).Count > 0;
            }
        }

    }
}