using SimpleWPF.Core.ViewModels;
using System.Windows.Input;

namespace SingleWindowSampleApplication.ViewModels
{
    public class YellowViewModel : SimpleViewModel
    {
        public ICommand GotoRedCommand { get; set; }

        public YellowViewModel()
        {
            GotoRedCommand = new SimpleRelayCommand(GotoRed);
        }

        private void GotoRed()
        {
            Navigate(new RedViewModel());
        }
    }
}