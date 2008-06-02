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
            StopImage.Visibility = Visibility.Collapsed;
            CheckImage.Visibility = Visibility.Collapsed;
        }


        private void Validate_Click(object sender, RoutedEventArgs e)
        {
            UrlTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();

            ValidateUrlTextBlock.Visibility = Visibility.Collapsed;

            if (Validation.GetErrors(UrlTextBox).Count > 0)
            {
                StopImage.Visibility = Visibility.Visible;
            }
            else
            {
                CheckImage.Visibility = Visibility.Visible;
            }
        }
    }
}