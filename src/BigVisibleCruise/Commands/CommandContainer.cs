using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace BigVisibleCruise.Commands
{
    public static class CommandContainer
    {
        private static readonly ICommand _fullscreenCommand = new FullscreenCommand();

        public static ICommand FullscreenCommand
        {
            get
            {
                return _fullscreenCommand;
            }
        }
    }
}
