using System;
using System.Windows;
using System.Windows.Threading;
using BigVisibleCruise.Properties;
using CruiseControlToys.Lib;
using System.Text.RegularExpressions;

namespace BigVisibleCruise
{

    public partial class BigVisibleCruiseWindow : Window
    {
        private readonly DispatcherTimer _timer = new DispatcherTimer();
        private IResolver _dashboardResolver;


        public BigVisibleCruiseWindow()
        {
            InitializeComponent();
            InitializeWindow();
        }

        private void InitializeWindow()
        {
            _dashboardResolver = new HttpProjectXmlResolver(new Uri(Settings.Default.Dashboard)) 
                                     { 
                                         ExplicitInclude = new Regex(Settings.Default.ExplicityIncludeProjectRegEx) 
                                     };

            LoadSkin();
            SetDataContext();
            StartPollingForStatus();
        }


        private static void LoadSkin()
		{
			var skinUri = new Uri("./Skins/" +  Settings.Default.Skin + ".xaml", UriKind.Relative);
			var skinResources = Application.LoadComponent(skinUri) as ResourceDictionary;
 
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
				DataContext = _dashboardResolver.GetProjectStatusList();
			}
			catch (DashboardCommunicationException ex)
			{
				DataContext = null;
				TimeSpan timeToShowMessage = TimeSpan.FromSeconds(3);
				HumaneMessageWindow.Show("There was a problem connecting to " + ex.Uri +  ".", timeToShowMessage);
			}
		}

        internal void ReInitializeWindow()
        {
            InitializeWindow();
        }
    }
}