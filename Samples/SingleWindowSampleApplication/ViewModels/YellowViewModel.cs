using SimpleWPF.Input;
using SimpleWPF.ViewModels;
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
            NavCommand = new RelayCommand<NavigationViewModelBase>(Nav);
        }

        //Navigate from object in XAML
        private void Nav(NavigationViewModelBase viewModel)
        {
            Navigate(viewModel);
        }

        //Navigate from class dependency
        private void GotoRed()
        {
            Navigate(_redViewModel);
        }
    }
}