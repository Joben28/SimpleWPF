using System;
using System.Windows.Input;

namespace SimpleWPF.Core.Input
{
    public class SimpleRelayCommand<T> : ICommand
    {
        private readonly Action<T> _execute = null;
        private readonly Func<T, bool> _canExecute = null;

        public SimpleRelayCommand(Action<T> execute, Func<T, bool> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute ?? (_ => true);
        }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public bool CanExecute(object parameter) => _canExecute((T)parameter);

        public void Execute(object parameter) => _execute((T)parameter);
    }

    public class SimpleRelayCommand : SimpleRelayCommand<object>
    {
        public SimpleRelayCommand(Action execute)
            : base(_ => execute()) { }

        public SimpleRelayCommand(Action execute, Func<bool> canExecute)
            : base(_ => execute(), _ => canExecute()) { }
    }
}