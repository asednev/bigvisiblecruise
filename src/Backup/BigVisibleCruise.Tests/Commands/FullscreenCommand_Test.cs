using System.Windows;
using BigVisibleCruise.Commands;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace BigVisibleCruise.Tests.Commands
{
	[TestFixture]
	public class FullscreenCommand_Test
	{
		[Test]
        [Category("ExcludeFromCI")]
		public void GoesFullscreen_IfNotAlready_Fullschreen()
		{
			var aWindow = new Window
			              {
			              	WindowStyle = WindowStyle.SingleBorderWindow,
			              	Topmost = false,
			              	WindowState = WindowState.Normal
			              };

			var command = new FullscreenCommand();
			command.Execute(aWindow);

			Assert.That(aWindow.WindowStyle, Is.EqualTo(WindowStyle.None));
			Assert.That(aWindow.Topmost, Is.EqualTo(true));
			Assert.That(aWindow.WindowState, Is.EqualTo(WindowState.Maximized));
		}

		[Test]
        [Category("ExcludeFromCI")]
		public void GoesNotFullscreen_WhenAlready_FullScreen()
		{
			var aWindow = new Window
			              {
			              	WindowStyle = WindowStyle.None,
			              	Topmost = true,
			              	WindowState = WindowState.Maximized
			              };

			var command = new FullscreenCommand();
			command.Execute(aWindow);

			Assert.That(aWindow.WindowStyle, Is.EqualTo(WindowStyle.SingleBorderWindow));
			Assert.That(aWindow.Topmost, Is.EqualTo(false));
			Assert.That(aWindow.WindowState, Is.EqualTo(WindowState.Normal));
		}
	}
}
