using SimpleWPF.Core.Input;
using SimpleWPF.Core.ViewModels;
using System.Windows.Input;

namespace SingleWindowSampleApplication.ViewModels
{
    public class BlueViewModel : SimpleViewModel
    {
        private SimpleViewModel _redViewModel;
        public ICommand GotoRedCommand { get; set; }

        public BlueViewModel()
        {
            _redViewModel = new RedViewModel(this);
            GotoRedCommand = new SimpleRelayCommand(GotoRed);
        }

        private void GotoRed()
        {
            Navigate(_redViewModel);
        }
    }
}