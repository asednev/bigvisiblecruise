using System;
using System.Windows;
using BigVisibleCruise.Properties;

namespace BigVisibleCruise
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        protected override void OnStartup(StartupEventArgs e)
        {
            LoadSkin(new Uri(Settings.Default.Skin, UriKind.Relative));
            base.OnStartup(e);
        }

        public void LoadSkin(Uri skinUri)
        {
            ResourceDictionary skinResources = Application.LoadComponent(skinUri) as ResourceDictionary;
            Application.Current.Resources = skinResources;
        }

    }
}