using SimpleWPF.Core.Input;
using SimpleWPF.Core.ViewModels;
using System.Windows.Input;

namespace SingleWindowSampleApplication.ViewModels
{
    public class RedViewModel : SimpleViewModel
    {
        private SimpleViewModel _blueViewModel;
        private SimpleViewModel _yellowViewModel;

        public ICommand GotoBackCommand { get; set; }
        public ICommand GotoBlueCommand { get; set; }
        public ICommand GotoYellowCommand { get; set; }

        public RedViewModel(SimpleViewModel blueViewModel)
        {
            _blueViewModel = blueViewModel;
            _yellowViewModel = new YellowViewModel(this);

            GotoBackCommand = new SimpleRelayCommand(GotoBack);
            GotoBlueCommand = new SimpleRelayCommand(GotoBlue);
            GotoYellowCommand = new SimpleRelayCommand(GotoYellow);
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