using System;
using System.Collections.Generic;
using System.Text;
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
        public void GoesFullscreenWhenNot()
        {
            Window aWindow = new Window();

            aWindow.WindowStyle = WindowStyle.SingleBorderWindow;
            aWindow.Topmost = false;
            aWindow.WindowState = WindowState.Normal;

            FullscreenCommand command = new FullscreenCommand();
            command.Execute(aWindow);

            Assert.That(aWindow.WindowStyle, Is.EqualTo(WindowStyle.None));
            Assert.That(aWindow.Topmost, Is.EqualTo(true));
            Assert.That(aWindow.WindowState, Is.EqualTo(WindowState.Maximized));
        }

        [Test]
        public void GoesNotWhenFullScreen()
        {
            Window aWindow = new Window();

            aWindow.WindowStyle = WindowStyle.None;
            aWindow.Topmost = true;
            aWindow.WindowState = WindowState.Maximized;

            FullscreenCommand command = new FullscreenCommand();
            command.Execute(aWindow);

            Assert.That(aWindow.WindowStyle, Is.EqualTo(WindowStyle.SingleBorderWindow));
            Assert.That(aWindow.Topmost, Is.EqualTo(false));
            Assert.That(aWindow.WindowState, Is.EqualTo(WindowState.Normal));
        }
    }

}
