using System;
using System.Windows.Input;

namespace SmartHunter.Core
{
    #pragma warning disable 67
    public class Command : ICommand
    {
        private readonly Action<object> _action;
        private readonly Func<Command, object, bool> _canExecuteFunction;

        public Command(Action<object> action, Func<Command, object, bool> canExecute = null)
        {
            _action = action;
            _canExecuteFunction = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            if (_canExecuteFunction != null)
            {
                return _canExecuteFunction(this, parameter);
            }
            return true;
        }

        public void Execute(object parameter)
        {
            _action(parameter);
        }

        public event EventHandler CanExecuteChanged;
    }
}
