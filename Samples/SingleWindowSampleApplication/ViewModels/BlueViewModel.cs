using SimpleWPF.Input;
using SimpleWPF.ViewModels;
using System.Windows.Input;

namespace SingleWindowSampleApplication.ViewModels
{
    public class BlueViewModel : NavigationViewModelBase
    {
        private NavigationViewModelBase _redViewModel;
        public ICommand GotoRedCommand { get; set; }

        public BlueViewModel()
        {
            _redViewModel = new RedViewModel(this);
            GotoRedCommand = new RelayCommand(GotoRed);
        }

        private void GotoRed()
        {
            Navigate(_redViewModel);
        }
    }
}