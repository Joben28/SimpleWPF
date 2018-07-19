using SimpleWPF.Core.Navigation;
using SimpleWPF.Core.ViewModels;

namespace SimpleWPF.Core.Core
{
    /// <summary>
    /// The core object to implement SimpleWPF
    /// </summary>
    public class SimpleCore
    {
        private SimpleNavigationService service;
        public ISimpleNavigationProvider Handler { get; set; }

        public SimpleCore()
        {
            service = SimpleNavigationService.Instance;
        }

        /// <summary>
        /// Setup the core navigation requirements
        /// </summary>
        /// <param name="navigationHandler">Object that handles navigation</param>
        /// <param name="defaultNavigation">View that navigation defaults to</param>
        /// <param name="forceDefaultNavigation">Force default view on startup?</param>
        public void Startup(ISimpleNavigationProvider navigationHandler,
            SimpleViewModel defaultNavigation = null,
            bool forceDefaultNavigation = false)
        {
            service.RegisterProvider(navigationHandler);
            Handler = navigationHandler;

            if (defaultNavigation != null)
                service.SetDefaultNavigation(defaultNavigation, forceDefaultNavigation);
        }
    }
}