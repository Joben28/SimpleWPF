using SimpleWPF.Core.Navigation;

namespace SimpleWPF.Core.ViewModels
{
    /// <summary>
    /// A base provider for the navigation service
    /// </summary>
    public class SimpleProviderViewModel : SimpleViewModel, ISimpleNavigationProvider
    {
        private SimpleViewModel current;

        public SimpleViewModel Current
        {
            get { return current; }
            set { OnPropertyChanged(ref current, value); }
        }

        private ISimpleWindow window;

        public ISimpleWindow Window
        {
            get { return window; }
            set { OnPropertyChanged(ref window, value); }
        }
    }
}