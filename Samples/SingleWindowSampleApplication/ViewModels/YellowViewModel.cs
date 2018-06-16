using SimpleWPF.Core.Input;
using SimpleWPF.Core.ViewModels;
using System;
using System.Windows.Input;

namespace SingleWindowSampleApplication.ViewModels
{
    public class YellowViewModel : SimpleViewModel
    {
        private SimpleViewModel _redViewModel;

        public ICommand GotoRedCommand { get; set; }
        public ICommand NavCommand { get; set; }

        public YellowViewModel(SimpleViewModel redViewModel)
        {
            _redViewModel = redViewModel;
            GotoRedCommand = new SimpleRelayCommand(GotoRed);
            NavCommand = new SimpleRelayCommand<Type>(Nav);
        }

        private void Nav(Type obj)
        {
            Navigate(Activator.CreateInstance(obj) as SimpleViewModel);
        }

        private void GotoRed()
        {
            Navigate(_redViewModel);
        }
    }
}