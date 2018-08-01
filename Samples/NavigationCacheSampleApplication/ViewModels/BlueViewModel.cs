using SimpleWPF.Core.Input;
using SimpleWPF.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NavigationCacheSampleApplication.ViewModels
{
    public class BlueViewModel : NavigationViewModelBase
    {
        public ICommand GetMessageCommand { get; private set; }
        public ICommand GotoRedCommand { get; private set; }

        private string _message;
        public string Message
        {
            get { return _message; }
            set { OnPropertyChanged(ref _message, value); }
        }

        public BlueViewModel()
        {
            GotoRedCommand = new RelayCommand(GotoRed);
            GetMessageCommand = new RelayCommand(GetMessage);
        }

        private void GetMessage()
        {
            Message = GetCacheObject<string>("_message");
        }

        private void GotoRed()
        {
            NavigateBack();
        }
    }
}
