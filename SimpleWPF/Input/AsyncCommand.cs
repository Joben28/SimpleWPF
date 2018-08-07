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
        private AsyncNotificationStatus _status = AsyncNotificationStatus.Idle;
        public AsyncNotificationStatus Status
        {
            get { return _status; }
            set { OnPropertyChanged(ref _status, value); }
        }

        private ObservableTask _obvservableTask;
        private Func<object, bool> _canExecute;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public AsyncCommand(Func<object, Task> execute, Func<object, bool> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException(nameof(execute));

            _obvservableTask = new ObservableTask(execute);
            _obvservableTask.Register(this);
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
