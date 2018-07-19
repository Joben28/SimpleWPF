using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SimpleWPF.Core.Input
{
    /// <summary>
    /// An async command implementation
    /// </summary>
    public class SimpleAsyncCommand : ISimpleAsyncCommand
    {
        /// <summary>
        /// Monitor for the commands current status
        /// </summary>
        public SimpleAsyncCommandMonitor CommandMonitor { get; private set; }

        public bool IsCanceled { get; private set; }

        private Func<object, Task> _execute;
        private Func<object, bool> _canExecute;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public SimpleAsyncCommand(Func<object, Task> execute, Func<object, bool> canExecute)
        {
            CommandMonitor = new SimpleAsyncCommandMonitor();
            _execute = execute;
            _canExecute = canExecute;
        }

        public SimpleAsyncCommand(Func<object, Task> execute) : this(execute, null) { }

        public bool CanExecute(object parameter)
        {
            if (CommandMonitor.Status == AsyncNotificationStatus.Busy)
                return false;

            if (_canExecute == null)
                return true;

            return _canExecute.Invoke(parameter);
        }

        public void Execute(object parameter)
        {
            if (_execute == null)
                return;

            IsCanceled = false;

            var commandTask = _execute.Invoke(parameter);
            ExecuteAsync(commandTask);
            CommandMonitor.MonitorTask(commandTask);
        }

        public async void ExecuteAsync(Task task)
        {
            await task;
            RaiseCanExecuteChanged();
        }

        public void CancelAsync()
        {
            CommandMonitor.CancelMonitor();
            IsCanceled = true;
        }

        protected void RaiseCanExecuteChanged()
        {
            CommandManager.InvalidateRequerySuggested();
        }
    }
}
