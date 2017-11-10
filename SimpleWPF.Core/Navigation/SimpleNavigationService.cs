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
    public sealed class SimpleNavigationService
    {
        public static readonly SimpleNavigationService Instance = new SimpleNavigationService();

        public ISimpleNavigationProvider Provider { get; private set; }
        public SimpleViewModel DefaultNavigation { get; private set; }

        public int MaxHistoryObjects { get; set; } = 5;

        public ObservableCollection<SimpleViewModel> NavigationHistory { get; private set; } = new ObservableCollection<SimpleViewModel>();

        private SimpleNavigationService()
        {

        }

        public void Navigate(SimpleViewModel navObject)
        {
            if (Provider.Current != null && Provider.Current != navObject)
            {
                if (NavigationHistory.Count >= MaxHistoryObjects)
                {
                    NavigationHistory.RemoveAt(0);
                }

                NavigationHistory.Add(Provider.Current);
            }

            Provider.Current = navObject;
        }

        public void NavigateWithNewWindow(SimpleViewModel navObject, ISimpleWindow newWindow)
        {
            Navigate(navObject);
            Provider.Window.TransitionWindow(newWindow);
        }

        public void RegisterProvider(ISimpleNavigationProvider provider)
        {
            this.Provider = provider;
        }

        public void SetDefaultNavigation(SimpleViewModel navigationObject, bool forceIfProviderEmpty = false)
        {
            DefaultNavigation = navigationObject;

            if(forceIfProviderEmpty)
            {
                if (Provider != null)
                    Provider.Current = navigationObject;
            }
        }
    }
}
