﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;

namespace MVVMToolkit
{
    public abstract class BaseViewModel : ObservableObject, ICommandSink
    {
        private CommandSink _sink = new CommandSink();

        public bool CanExecuteCommand(ICommand command, object parameter, out bool handled)
        {
            return _sink.CanExecuteCommand(command, parameter, out handled);
        }

        public void ExecuteCommand(ICommand command, object parameter, out bool handled)
        {
            _sink.ExecuteCommand(command, parameter, out handled);
        }

        protected void RegisterCommand(ICommand command, Predicate<object> canExecute, Action<object> execute)
        {
            _sink.RegisterCommand(command, canExecute, execute);
        }

        protected void UnregisterCommand(ICommand command)
        {
            _sink.UnregisterCommand(command);
        }
    }
}
