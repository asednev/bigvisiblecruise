using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Threading;
using BigVisibleCruise.Properties;
using CruiseControlToys.Lib;

namespace BigVisibleCruise
{
    public partial class BigVisibleCruiseWindow : Window
    {

        readonly DispatcherTimer _timer = new DispatcherTimer();
        IResolver _dashboardResolver;

        public BigVisibleCruiseWindow()
        {
            InitializeComponent();
            InitializeMonitors();
            SetDataContext();
            InitializeTimerForContextUpdate();
        }

        private void SetInitialDataContext()
        {
            SetDataContext();
        }

        private void InitializeMonitors()
        {
            _dashboardResolver = HttpProjectXmlResolver.FromUri(new Uri(Settings.Default.Dashboard));
        }

        private void InitializeTimerForContextUpdate()
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
                this.DataContext =
                    (Settings.Default.ProjectNamesToInclude == null)
                        ? _dashboardResolver.GetProjects()
                        : _dashboardResolver.GetProjectsByName(Settings.Default.ProjectNamesToInclude);
            }
            catch (DashboardCommunicationException ex)
            {
                this.DataContext = null;

                // notify and retry
                TimeSpan timeToShowMessage = Settings.Default.PollFrequency - TimeSpan.FromSeconds(3);
                HumaneMessageWindow.Show("There was a problem connecting to " + ex.Uri + ".", timeToShowMessage);
            }   
        }

    }
}