using SimpleWPF.Core.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleWPF.Core.Input
{
    public class SimpleAsyncCommandMonitor : SimpleObservableObject
    {
        private Task _commandTask;
        private CancellationTokenSource _tokenSource;
        private CancellationToken _token;
        private bool _isMonitoring;

        private AsyncNotificationStatus _status;
        public AsyncNotificationStatus Status
        {
            get { return _status; }
            set
            {
                _status = value;
                OnPropertyChanged("Status");
            }
        }

        public async void MonitorTask(Task commandTask)
        {
            _commandTask = commandTask;
            _isMonitoring = true;

            _tokenSource = new CancellationTokenSource();
            _token = _tokenSource.Token;

            Status = AsyncNotificationStatus.Busy;

            await Task.Factory.StartNew(() =>
            {
                while (_isMonitoring)
                {
                    if (_commandTask.Status == TaskStatus.RanToCompletion)
                    {
                        Status = AsyncNotificationStatus.Complete;
                        _isMonitoring = false;
                        break;
                    }
                    else if (_commandTask.Status == TaskStatus.Faulted)
                    {
                        Status = AsyncNotificationStatus.Error;
                        _isMonitoring = false;
                        break;
                    }
                    else if (_tokenSource.IsCancellationRequested)
                    {
                        Status = AsyncNotificationStatus.Canceled;
                        _isMonitoring = false;
                        break;
                    }
                    else
                        Status = AsyncNotificationStatus.Busy;
                }
            }, _token);
        }

        public void CancelMonitor()
        {
            if (_tokenSource != null)
                _tokenSource.Cancel();
        }
    }
}
