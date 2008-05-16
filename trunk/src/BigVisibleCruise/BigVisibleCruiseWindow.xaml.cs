using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using BigVisibleCruise.Commands;
using BigVisibleCruise.Properties;
using CruiseControlToys.Lib;
using System.IO;

namespace BigVisibleCruise
{
    public partial class BigVisibleCruiseWindow : Window
    {

        readonly DispatcherTimer _timer = new DispatcherTimer();
        IResolver _dashboardResolver;

        public BigVisibleCruiseWindow()
        {
            InitializeComponent();
            InitializeWindow();
        }

        private void InitializeWindow()
        {
            _dashboardResolver = HttpProjectXmlResolver.FromUri(new Uri(Settings.Default.Dashboard));

            LoadSkin();
            SetDataContext();
            StartPollingForStatus();
        }

        private void LoadSkin()
        {
            Uri skinUri = new Uri("./Skins/" + Settings.Default.Skin + ".xaml", UriKind.Relative);
            ResourceDictionary skinResources = Application.LoadComponent(skinUri) as ResourceDictionary;

            //todo: need to remove old one
            Application.Current.Resources.MergedDictionaries.Add(skinResources);
        }


        private void StartPollingForStatus()
        {
            _timer.Interval = Settings.Default.PollFrequency;
            _timer.Tick += Timer_Tick;
            _timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            SetDataContext();
        }

        private void SetDataContext()
        {
            try
            {
                this.DataContext = _dashboardResolver.GetProjects();
            }
            catch (DashboardCommunicationException ex)
            {
                this.DataContext = null;
                TimeSpan timeToShowMessage = TimeSpan.FromSeconds(3);
                HumaneMessageWindow.Show("There was a problem connecting to " + ex.Uri + ".", timeToShowMessage);
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F11)
            {
                CommandContainer.FullscreenCommand.Execute(this);
            }

            if (e.Key == Key.F12)
            {
                SettingsWindow settingsWindow = new SettingsWindow();
                settingsWindow.Owner = this;
                settingsWindow.ShowDialog();

                InitializeWindow();
            }

            if (e.Key == Key.F5)
            {
                InitializeWindow();
            }
        }
    }
}