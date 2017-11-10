using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SimpleWPF.Core.ViewModels
{
    public class SimpleRelayCommand<T> : ICommand
    {
        private readonly Action<T> _execute = null;
        private readonly Predicate<T> _canExecute = null;

        /// <summary>
                /// Creates a new command that can always execute.
                /// </summary>
                /// <param name="execute">The execution logic.</param>
        public SimpleRelayCommand(Action<T> execute) : this(execute, null)
        {
        }

        /// <summary>
                /// Creates a new command with conditional execution.
                /// </summary>
                /// <param name="execute">The execution logic.</param>
                /// <param name="canExecute">The execution status logic.</param>
        public SimpleRelayCommand(Action<T> execute, Predicate<T> canExecute)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute((T)parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                if (_canExecute != null)
                    CommandManager.RequerySuggested += value;
            }
            remove
            {
                if (_canExecute != null)
                    CommandManager.RequerySuggested -= value;
            }
        }

        public void Execute(object parameter)
        {
            _execute((T)parameter);
        }
    }
}
