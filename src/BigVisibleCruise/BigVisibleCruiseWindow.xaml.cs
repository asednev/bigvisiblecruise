using System;
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
            this.DataContext = (Settings.Default.ProjectNamesToInclude == null) ? _dashboardResolver.GetProjects() : _dashboardResolver.GetProjectsByName(Settings.Default.ProjectNamesToInclude);
        }

    }
}