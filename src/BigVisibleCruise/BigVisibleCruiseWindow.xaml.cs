﻿using System;
using System.Linq;
using System.Windows;
using System.Windows.Threading;
using BigVisibleCruise.Properties;
using CruiseControlToys.Lib;
using System.Text.RegularExpressions;
using BigVisibleCruise.Commands;

namespace BigVisibleCruise
{

    public partial class BigVisibleCruiseWindow : Window
    {
        private readonly DispatcherTimer _timer = new DispatcherTimer();
        private IResolver _dashboardResolver;


        public BigVisibleCruiseWindow()
        {
            InitializeComponent();
			
			Loaded	 += OnLoaded;
        }

	    private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
	    {
		    try
		    {
			    InitializeWindow();
		    }
		    catch (Exception ex)
		    {
				HumaneMessageWindow.Show(string.Format("Initialization failed: {0}", ex.Message));
			}
	    }

		private void InitializeWindow()
        {
		    var raw = Settings.Default.Dashboard;
		    var login = Settings.Default.DashboardLogin;
		    var password = Settings.Default.DashboardPassword;

		    var uriList = raw.Split(';').Select(x => new Uri(x)).ToList();

		    _dashboardResolver = new HttpProjectXmlResolver(uriList, login, password)
		    {
			    ExplicitInclude = new Regex(Settings.Default.ExplicityIncludeProjectRegEx)
		    };

		    LoadSkin();
		    SetDataContext();
		    StartPollingForStatus();

		    if (Settings.Default.StartFullscreen)
		    {
			    if (CommandContainer.FullscreenCommand != null)
				    CommandContainer.FullscreenCommand.Execute(null);
		    }
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