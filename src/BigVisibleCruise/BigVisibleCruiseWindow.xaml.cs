using System;
using System.Collections.Generic;
using System.Configuration;
using System.Windows;
using System.Windows.Threading;
using CruiseControlToys.Lib;

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
            string delimitedDashboardSetting = Properties.Settings.Default.Dashboards;
            string[] dashboards = delimitedDashboardSetting.Split(',');
            
            List<IResolver> dashboardResolvers = new List<IResolver>(dashboards.Length);
            for (int index = 0; index < dashboards.Length; index++ )
            {
                dashboardResolvers.Add(DashboardResolver.FromUri(new Uri(dashboards[index])));
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