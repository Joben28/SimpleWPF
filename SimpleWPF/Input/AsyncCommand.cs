using SimpleWPF.Components;
using SimpleWPF.Utils;
using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SimpleWPF.Input
{
    /// <summary>
    /// An async command implementation
    /// </summary>
    public class AsyncCommand : ObservableObject, IObserver, IAsyncCommand
    {
        public AsyncNotificationStatus Status
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value; OnPropertyChanged();
            }
        }

        private AsyncNotificationStatus _status = AsyncNotificationStatus.Idle;
        private ObservableTask _obvservableTask = null;
        private Func<object, bool> _canExecute;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public AsyncCommand(Func<object, Task> execute, Func<object, bool> canExecute)
        {
            if (execute != null)
            {
                _obvservableTask = new ObservableTask(execute);
                _obvservableTask.Register(this);
            }
            _canExecute = canExecute;
        }

        public AsyncCommand(Func<object, Task> execute) : this(execute, null) { }

        public bool CanExecute(object parameter)
        {
            if (Status == AsyncNotificationStatus.Busy)
                return false;

            if (_canExecute == null)
                return true;

            return _canExecute.Invoke(parameter);
        }

        public void Execute(object parameter)
        {
            _obvservableTask.Run(parameter);
            RaiseCanExecuteChanged();
        }

        protected void RaiseCanExecuteChanged()
        {
            CommandManager.InvalidateRequerySuggested();
        }

        public void Update()
        {
            Status = _obvservableTask.Status;
        }
    }
}
