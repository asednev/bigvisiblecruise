using System;
using System.Windows;
using System.Windows.Threading;

namespace BigVisibleCruise
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		public App() : base()
		{
			Dispatcher.UnhandledException += DispatcherOnUnhandledException;
		}

		private void DispatcherOnUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs dispatcherUnhandledExceptionEventArgs)
		{
			MessageBox.Show(dispatcherUnhandledExceptionEventArgs.Exception.Message);
		}
	}
}
