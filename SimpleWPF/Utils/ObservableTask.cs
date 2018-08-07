using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SimpleWPF.Input;

namespace SimpleWPF.Utils
{
    internal class ObservableTask : IObservable
    {
        private Func<object, Task> _execute;

        private AsyncNotificationStatus _status;
        public AsyncNotificationStatus Status
        {
            get { return _status; }
            set
            {
                _status = value;
                Notify();
            }
        }

        public IList<IObserver> Observers { get; private set; } = new List<IObserver>();

        public ObservableTask(Func<object, Task> execute)
        {
            _execute = execute;
        }

        public void Notify()
        {
            foreach (var observer in Observers)
                observer.Update();
        }

        public void Register(IObserver observer)
        {
            if (observer == null)
                throw new ArgumentNullException(nameof(observer));

            Observers.Add(observer);
        }

        public void Unregister(IObserver observer)
        {
            if (observer == null)
                throw new ArgumentNullException(nameof(observer));

            Observers.Remove(observer);
        }

        public void Run(object parameter)
        {
            try
            {
                Status = AsyncNotificationStatus.Busy;
                _execute.Invoke(parameter).ConfigureAwait(false).GetAwaiter().OnCompleted(() => Status = AsyncNotificationStatus.Complete);
            }
            catch (TaskCanceledException)
            {
                Status = AsyncNotificationStatus.Canceled;
            }
            catch
            {
                Status = AsyncNotificationStatus.Error;
                throw;
            }
        }
    }
}
