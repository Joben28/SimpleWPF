using SimpleWPF.Core.Navigation;
using SimpleWPF.Core.ViewModels;

namespace SimpleWPF.Core.Core
{
    public class SimpleCore
    {
        private SimpleNavigationService service;
        public ISimpleNavigationProvider Handler { get; set; }

        public SimpleCore()
        {
            service = SimpleNavigationService.Instance;
        }

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