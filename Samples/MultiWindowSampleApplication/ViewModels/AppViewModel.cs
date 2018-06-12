using SimpleWPF.Core.Input;
using SimpleWPF.Core.Navigation;
using SimpleWPF.Core.ViewModels;
using System.Windows.Input;

namespace MultiWindowSampleApplication.ViewModels
{
    public class AppViewModel : SimpleViewModel, ISimpleNavigationProvider
    {
        public ICommand HomeCommand { get; set; }

        private SimpleViewModel current;

        public SimpleViewModel Current
        {
            get { return current; }
            set
            {
                OnPropertyChanged(ref current, value);
            }
        }

        private ISimpleWindow window;

        public ISimpleWindow Window
        {
            get { return window; }
            set
            {
                OnPropertyChanged(ref window, value);
            }
        }

        public AppViewModel()
        {
            HomeCommand = new SimpleRelayCommand(NavigateToHome);
        }

        private void NavigateToHome()
        {
            Navigate(new NewPostViewModel());
        }
    }
}