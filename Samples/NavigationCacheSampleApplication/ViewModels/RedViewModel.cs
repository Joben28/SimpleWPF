using SimpleWPF.Input;
using SimpleWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NavigationCacheSampleApplication.ViewModels
{
    public class RedViewModel : NavigationViewModelBase
    {
        private BlueViewModel _blueVM;
        public ICommand GotoBlueCommand { get; private set; }

        private string _cacheMessage;
        public string CacheMessage
        {
            get { return _cacheMessage; }
            set { OnPropertyChanged(ref _cacheMessage, value); }
        }

        public RedViewModel()
        {
            _blueVM = new BlueViewModel();
            GotoBlueCommand = new RelayCommand(GotoBlue);
        }

        private void GotoBlue()
        {
            AddOrUpdateCacheObject("_message", CacheMessage);
            Navigate(_blueVM);
        }
    }
}
