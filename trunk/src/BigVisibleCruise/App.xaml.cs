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
            LoadSkin(Settings.Default.Skin);
            base.OnStartup(e);
        }

        public void LoadSkin(string skinName)
        {
            Uri skinUri = new Uri("./Skins/" + skinName + ".xaml", UriKind.Relative);

            ResourceDictionary skinResources = Application.LoadComponent(skinUri) as ResourceDictionary;
            Application.Current.Resources = skinResources;
        }

    }
}