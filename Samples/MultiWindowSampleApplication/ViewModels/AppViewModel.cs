using SimpleWPF.Input;
using SimpleWPF.Navigation;
using SimpleWPF.ViewModels;
using System.Windows.Input;

namespace MultiWindowSampleApplication.ViewModels
{
    public class AppViewModel : NavigationViewModelBase, INavigationProvider
    {
        public ICommand HomeCommand { get; set; }

        private NavigationViewModelBase current;

        public NavigationViewModelBase Current
        {
            get { return current; }
            set
            {
                OnPropertyChanged(ref current, value);
            }
        }

        private INavigationWindow window;

        public INavigationWindow Window
        {
            get { return window; }
            set
            {
                OnPropertyChanged(ref window, value);
            }
        }

        public AppViewModel()
        {
            HomeCommand = new RelayCommand(NavigateToHome);
        }

        private void NavigateToHome()
        {
            Navigate(new NewPostViewModel());
        }
    }
}