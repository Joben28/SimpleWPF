using SimpleWPF.Core.ViewModels;
using System.Windows.Input;

namespace SingleWindowSampleApplication.ViewModels
{
    public class BlueViewModel : SimpleViewModel
    {
        public ICommand GotoRedCommand { get; set; }

        public BlueViewModel()
        {
            GotoRedCommand = new SimpleRelayCommand(GotoRed);
        }

        private void GotoRed()
        {
            Navigate(new RedViewModel());
        }
    }
}