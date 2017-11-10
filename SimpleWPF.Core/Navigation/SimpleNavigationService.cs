using SimpleWPF.Core.Core;
using SimpleWPF.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWPF.Core.Navigation
{
    public class SimpleNavigationService : SimpleSingleton<SimpleNavigationService>
    {
        private ISimpleNavigationHandler provider;
        public SimpleViewModel DefaultNavigation;

        public int MaxHistoryObjects { get; set; } = 5;

        public ObservableCollection<SimpleViewModel> NavigationHistory { get; private set; } = new ObservableCollection<SimpleViewModel>();

        public void Navigate(SimpleViewModel navObject)
        {
            if (provider.Current != null && provider.Current != navObject)
            {
                if (NavigationHistory.Count >= MaxHistoryObjects)
                {
                    NavigationHistory.RemoveAt(0);
                }

                NavigationHistory.Add(provider.Current);
            }

            provider.Current = navObject;
        }

        public void NavigateWithNewWindow(SimpleViewModel navObject, ISimpleWindow newWindow)
        {
            Navigate(navObject);
            provider.Window.TransitionWindow(newWindow);
        }

        public void RegisterHandler(ISimpleNavigationHandler provider)
        {
            this.provider = provider;
        }

        public void SetDefaultNavigation(SimpleViewModel navigationObject, bool forceIfProviderEmpty = false)
        {
            DefaultNavigation = navigationObject;

            if(forceIfProviderEmpty)
            {
                if (provider != null)
                    provider.Current = navigationObject;
            }
        }

        public ISimpleNavigationHandler GetProvider()
        {
            return provider;
        }
    }
}
