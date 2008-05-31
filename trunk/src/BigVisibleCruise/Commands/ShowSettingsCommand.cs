using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace BigVisibleCruise.Commands
{
    public class ShowSettingsCommand : ICommand
    {

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            BigVisibleCruiseWindow targetWindow = parameter as BigVisibleCruiseWindow;

            if (targetWindow == null)
            {
                //HACK: Couldn't figure out how to pass this in from XAML
                targetWindow = Application.Current.MainWindow as BigVisibleCruiseWindow;
            }

            SettingsWindow settingsWindow = new SettingsWindow();
            settingsWindow.Owner = targetWindow;
            settingsWindow.ShowDialog();

            targetWindow.ReInitializeWindow();
        }
    }
}
