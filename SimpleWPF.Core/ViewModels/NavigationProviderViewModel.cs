using SimpleWPF.Navigation;

namespace SimpleWPF.ViewModels
{
    /// <summary>
    /// A base provider for the navigation service
    /// </summary>
    public class NavigationProviderViewModel : NavigationViewModelBase, INavigationProvider
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
    }
}