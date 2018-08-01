using System;
using SimpleWPF.Navigation;
using SimpleWPF.Navigation.Arguments;
using SimpleWPF.ViewModels;

namespace SingleWindowSampleApplication.ViewModels
{
    public class AppViewModel : NavigationViewModelBase, INavigationProvider
    {
        private NavigationViewModelBase current;

        public NavigationViewModelBase Current
        {
            get { return current; }
            set { OnPropertyChanged(ref current, value); }
        }

        private INavigationWindow window;

        public INavigationWindow Window
        {
            get { return window; }
            set { OnPropertyChanged(ref window, value); }
        }

        public AppViewModel()
        {
            service.BeforeNavigation += OnBeforeNavigation;
        }

        private void OnBeforeNavigation(object sender, NavigationEventArgs e)
        {
            Console.WriteLine("About to navigate!");
        }
    }
}