using SimpleWPF.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SingleWindowSampleApplication.ViewModels
{
    public class RedViewModel : SimpleViewModel
    {
        public ICommand GotoBlueCommand { get; set; }
        public ICommand GotoYellowCommand { get; set; }

        public RedViewModel()
        {
            GotoBlueCommand = new SimpleRelayCommand(GotoBlue);
            GotoYellowCommand = new SimpleRelayCommand(GotoYellow);
        }

        private void GotoYellow()
        {
            Navigate(new YellowViewModel());
        }

        private void GotoBlue()
        {
            Navigate(new BlueViewModel());
        }
    }
}
