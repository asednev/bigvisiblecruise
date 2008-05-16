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

namespace BigVisibleCruise
{
    /// <summary>
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>

    public partial class SettingsWindow : System.Windows.Window
    {

        public SettingsWindow()
        {
            InitializeComponent();
        }

        void SaveConfigurationSettings_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.Save();
            this.Close();
        }
    }
}