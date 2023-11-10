using System;
using System.Windows.Input;

namespace Demo.Wpf.ViewModels.Commands
{
    internal class DelegateCommand : ICommand
    {
        private readonly Action<object> _action;
        private readonly Func<object, bool> _canExecute;

        public DelegateCommand(Action<object> action)
        {
            this._action = action;
        }

        public DelegateCommand(Action<object> action, Func<object, bool> canExecute)
        {
            this._action = action;
            this._canExecute = canExecute;
        }

        public void Execute(object parameter)
        {
            this._action(parameter);
        }

        public bool CanExecute(object parameter)
        {
            return this._canExecute(parameter);
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler CanExecuteChanged;
    }
}
