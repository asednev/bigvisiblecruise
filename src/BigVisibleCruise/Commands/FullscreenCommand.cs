using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using System.Windows;

namespace BigVisibleCruise.Commands
{
    public class FullscreenCommand : ICommand
    {

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            Window targetWindow = parameter as Window;

            if (targetWindow == null)
            {
                throw new ArgumentException(
                    string.Format("Expected a type of {0} but received {1}.", typeof(Window).Name, parameter.GetType().Name), "parameter");
            }

            if (targetWindow.WindowStyle != WindowStyle.None)
            {
                targetWindow.WindowStyle = WindowStyle.None;
                targetWindow.Topmost = true;
                targetWindow.WindowState = WindowState.Maximized;
            }
            else
            {
                targetWindow.WindowStyle = WindowStyle.SingleBorderWindow;
                targetWindow.Topmost = false;
                targetWindow.WindowState = WindowState.Normal;
            }
        }
    }
}