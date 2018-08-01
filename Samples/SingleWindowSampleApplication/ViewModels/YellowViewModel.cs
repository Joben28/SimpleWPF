using SimpleWPF.Core.Input;
using SimpleWPF.Core.ViewModels;
using System;
using System.Windows.Input;

namespace SingleWindowSampleApplication.ViewModels
{
    public class YellowViewModel : NavigationViewModelBase
    {
        private NavigationViewModelBase _redViewModel;

        public ICommand GotoRedCommand { get; set; }
        public ICommand NavCommand { get; set; }

        public YellowViewModel(NavigationViewModelBase redViewModel)
        {
            _redViewModel = redViewModel;
            GotoRedCommand = new RelayCommand(GotoRed);
            NavCommand = new RelayCommand<Type>(Nav);
        }

        private void Nav(Type obj)
        {
            Navigate(Activator.CreateInstance(obj) as NavigationViewModelBase);
        }

        private void GotoRed()
        {
            Navigate(_redViewModel);
        }
    }
}