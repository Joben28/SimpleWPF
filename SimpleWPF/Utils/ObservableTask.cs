using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SimpleWPF.Input;

namespace SimpleWPF.Utils
{
    internal class ObservableTask : IObservable
    {
        private AsyncNotificationStatus _status;
        private Func<object, Task> execute;

        public IList<IObserver> Observers { get; private set; } = new List<IObserver>();
        public AsyncNotificationStatus Status
        {
            set
            {
                _status = value;
                Notify();
            }
            get { return _status; }
        }

        public ObservableTask(Func<object, Task> execute)
        {
            this.execute = execute;
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
                execute.Invoke(parameter).ConfigureAwait(false).GetAwaiter().OnCompleted(() => Status = AsyncNotificationStatus.Complete);
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
