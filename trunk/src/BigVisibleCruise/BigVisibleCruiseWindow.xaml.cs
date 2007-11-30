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

        //
        //TODO: Convert overall strategy to event-based.
        //
        // I'm Starting to feel like the timers are getting very nasty. 
        // Need to convert all this to an event model (much cleaner).
        //


        readonly DispatcherTimer _timer = new DispatcherTimer();
        IResolver _dashboardResolver;

        public BigVisibleCruiseWindow()
        {
            InitializeComponent();
            InitializeMonitors();
            SetInitialDataContext();
            InitializeTimerForContextUpdate();
        }

        private void SetInitialDataContext()
        {
            HumaneMessageWindow messageWindow = HumaneMessageWindow.Show("Connecting to " + Properties.Settings.Default.Dashboard + " ...");
            SetDataContext();
            messageWindow.CloseWithFade();
        }

        private void InitializeMonitors()
        {
            _dashboardResolver = DashboardResolver.FromUri(new Uri(Properties.Settings.Default.Dashboard));
        }

        private void InitializeTimerForContextUpdate()
        {
            _timer.Interval = Properties.Settings.Default.PollFrequency;
            _timer.Tick += new EventHandler(Timer_Tick);
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
                // notify and retry
                TimeSpan timeToShowMessage = Settings.Default.PollFrequency - TimeSpan.FromSeconds(3);
                HumaneMessageWindow.Show("There was a problem connecting to " + ex.Uri.ToString() + ".", timeToShowMessage);
            }   
        }

    }
}