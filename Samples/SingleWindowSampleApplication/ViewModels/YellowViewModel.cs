using SimpleWPF.Core.Input;
using SimpleWPF.Core.ViewModels;
using System;
using System.Windows.Input;

namespace SingleWindowSampleApplication.ViewModels
{
    public class YellowViewModel : SimpleViewModel
    {
        public ICommand GotoRedCommand { get; set; }
        public ICommand NavCommand { get; set; }

        public YellowViewModel()
        {
            GotoRedCommand = new SimpleRelayCommand(GotoRed);
            NavCommand = new SimpleRelayCommand<Type>(Nav);
        }

        private void Nav(Type obj)
        {
            Navigate(Activator.CreateInstance(obj) as SimpleViewModel);
        }

        private void GotoRed()
        {
            Navigate(new RedViewModel());
        }
    }
}