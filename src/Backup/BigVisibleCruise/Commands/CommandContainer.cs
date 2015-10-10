using System.Windows.Input;

namespace BigVisibleCruise.Commands
{
	public static class CommandContainer
	{
		private static readonly ICommand _fullscreenCommand = new FullscreenCommand();
		private static readonly ICommand _refreshCommand = new RefreshCommand();
		private static readonly ICommand _showSettingsCommand = new ShowSettingsCommand();

		public static ICommand FullscreenCommand
		{
			get { return _fullscreenCommand; }
		}

		public static ICommand ShowSettingsCommand
		{
			get { return _showSettingsCommand; }
		}

		public static ICommand RefreshCommand
		{
			get { return _refreshCommand; }
		}
	}
}
