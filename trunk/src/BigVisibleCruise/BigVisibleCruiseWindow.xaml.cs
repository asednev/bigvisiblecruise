using System;
using System.Collections.Generic;
using System.Configuration;
using System.Windows;
using System.Windows.Threading;
using CruiseControlToys.Lib;
using System.Collections.Specialized;

namespace BigVisibleCruise
{
    public partial class BigVisibleCruiseWindow : Window
    {

        DispatcherTimer _timer = new DispatcherTimer();
        IResolver _allResolvers;

        public BigVisibleCruiseWindow()
        {
            InitializeComponent();
            InitializeMonitors();
            SetDataContext();
            InitializeTimerForContextUpdate();
        }

        private void InitializeMonitors()
        {
            StringCollection dashboards = Properties.Settings.Default.Dashboards;
            List<IResolver> dashboardResolvers = new List<IResolver>(dashboards.Count);
            foreach (string dashboardLocation in dashboards)
            {
                dashboardResolvers.Add(DashboardResolver.FromUri(new Uri(dashboardLocation)));
            }

            _allResolvers = new AggregateResolver(dashboardResolvers);
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
            this.DataContext = _allResolvers.GetProjects();    
        }

    }
}