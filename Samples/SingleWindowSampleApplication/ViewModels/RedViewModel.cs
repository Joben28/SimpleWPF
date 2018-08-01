using SimpleWPF.Core.Input;
using SimpleWPF.Core.Navigation.Arguments;
using SimpleWPF.Core.ViewModels;
using System.Windows.Input;

namespace SingleWindowSampleApplication.ViewModels
{
    public class RedViewModel : NavigationViewModelBase
    {
        private NavigationViewModelBase _blueViewModel;
        private NavigationViewModelBase _yellowViewModel;

        public ICommand GotoBackCommand { get; set; }
        public ICommand GotoBlueCommand { get; set; }
        public ICommand GotoYellowCommand { get; set; }

        public RedViewModel(NavigationViewModelBase blueViewModel)
        {
            _blueViewModel = blueViewModel;
            _yellowViewModel = new YellowViewModel(this);

            GotoBackCommand = new RelayCommand(GotoBack);
            GotoBlueCommand = new RelayCommand(GotoBlue);
            GotoYellowCommand = new RelayCommand(GotoYellow);
        }

        private void GotoBack()
        {
            NavigateBack();
        }

        private void GotoBlue()
        {
            Navigate(_blueViewModel);
        }

        private void GotoYellow()
        {
            Navigate(_yellowViewModel);
        }
    }
}