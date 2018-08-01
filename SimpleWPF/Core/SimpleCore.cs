using SimpleWPF.Navigation;
using SimpleWPF.ViewModels;

namespace SimpleWPF.Core
{
    /// <summary>
    /// The core object to implement SimpleWPF
    /// </summary>
    public class SimpleCore
    {
        private NavigationService service;
        public INavigationProvider Handler { get; set; }

        public SimpleCore()
        {
            service = NavigationService.Instance;
        }

        /// <summary>
        /// Setup the core navigation requirements
        /// </summary>
        /// <param name="navigationHandler">Object that handles navigation</param>
        /// <param name="defaultNavigation">View that navigation defaults to</param>
        /// <param name="forceDefaultNavigation">Force default view on startup?</param>
        public void Startup(INavigationProvider navigationHandler,
            NavigationViewModelBase defaultNavigation = null,
            bool forceDefaultNavigation = false)
        {
            service.RegisterProvider(navigationHandler);
            Handler = navigationHandler;

            if (defaultNavigation != null)
                service.SetDefaultNavigation(defaultNavigation, forceDefaultNavigation);
        }
    }
}