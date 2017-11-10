using SimpleWPF.Core.Navigation;
using SimpleWPF.Core.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;

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

            if(defaultNavigation != null)
                service.SetDefaultNavigation(defaultNavigation, forceDefaultNavigation);
        }
    }
}
