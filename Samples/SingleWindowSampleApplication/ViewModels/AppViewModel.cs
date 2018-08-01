using System;
using SimpleWPF.Core.Navigation;
using SimpleWPF.Core.Navigation.Arguments;
using SimpleWPF.Core.ViewModels;

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