using SimpleWPF.Core.Core;
using SimpleWPF.Core.Navigation.Arguments;
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

        public ObservableCollection<SimpleViewModel> NavigationHistory { get; private set; } = new ObservableCollection<SimpleViewModel>();
        public ISimpleNavigationProvider Provider { get; private set; }
        public SimpleViewModel DefaultNavigation { get; private set; }
        public int MaxHistoryObjects { get; set; } = 5;

        private event BeforeNavigationEventHandler BeforeNavigation;
        private event AfterNavigationEventHandler AfterNavigation;
        private event BeforeClosingEventHandler BeforeClosing;
        private event AfterClosingEventHandler AfterClosing;




        private SimpleNavigationService()
        {

        }

        public void Navigate(SimpleViewModel navObject)
        {
            var args = new NavigationEventArgs(navObject, Provider.Current);

            OnBeforeNavigate(this, args);

            if (Provider.Current != null && Provider.Current != navObject)
            {
                if (NavigationHistory.Count >= MaxHistoryObjects)
                {
                    NavigationHistory.RemoveAt(0);
                }

                NavigationHistory.Add(Provider.Current);
            }

            Provider.Current = navObject;

            OnAfterNavigate(this, args);
        }

        public void NavigateWithNewWindow(SimpleViewModel navObject, ISimpleWindow newWindow)
        {
            var args = new WindowEventArgs(newWindow, Provider.Window);

            Navigate(navObject);

            OnBeforeClosing(this, args);
            Provider.Window.TransitionWindow(newWindow);
            OnAfterClosing(this, args);
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

        public void OnBeforeNavigate(object sender, NavigationEventArgs e)
        {
            BeforeNavigation?.Invoke(this, e);
        }

        public void OnAfterNavigate(object sender, NavigationEventArgs e)
        {
            AfterNavigation?.Invoke(this, e);
        }

        public void OnBeforeClosing(object sender, WindowEventArgs e)
        {
            BeforeClosing?.Invoke(this, e);
        }

        public void OnAfterClosing(object sender, WindowEventArgs e)
        {
            AfterClosing?.Invoke(this, e);
        }
    }
}
