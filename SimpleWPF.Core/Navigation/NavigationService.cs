using SimpleWPF.Core.Navigation.Arguments;
using SimpleWPF.Core.ViewModels;
using System;
using System.Collections.ObjectModel;

namespace SimpleWPF.Core.Navigation
{
    /// <summary>
    /// Handles the application navigation
    /// </summary>
    public sealed class NavigationService
    {
        public static readonly NavigationService Instance = new NavigationService();

        /// <summary>
        /// Collection of past navigation calls
        /// </summary>
        public ObservableCollection<NavigationViewModelBase> NavigationHistory { get; private set; } = new ObservableCollection<NavigationViewModelBase>();

        public INavigationProvider Provider { get; private set; }
        public NavigationViewModelBase DefaultNavigation { get; private set; }

        /// <summary>
        /// Maximum number of objects to hold in history collection
        /// </summary>
        public int MaxHistoryObjects { get; set; } = 5;

        public event BeforeNavigationEventHandler BeforeNavigation;

        public event AfterNavigationEventHandler AfterNavigation;

        public event BeforeClosingEventHandler BeforeClosing;

        public event AfterClosingEventHandler AfterClosing;

        private NavigationService()
        {
        }

        /// <summary>
        /// Navigate to ViewModel
        /// </summary>
        /// <param name="navObject">ViewModel to navigate to</param>
        public void Navigate(NavigationViewModelBase navObject)
        {
            if (Provider == null)
                throw new NullReferenceException("The navigation service does not have a registered 'ISimpleNavigationProvider'");

            var args = new NavigationEventArgs(navObject, Provider.Current);

            OnBeforeNavigate(this, args);

            if (Provider.Current != null && Provider.Current != navObject)
                AddToHistory(Provider.Current);

            Provider.Current = navObject;

            OnAfterNavigate(this, args);
        }

        /// <summary>
        /// Navigate to a ViewModel with a new window
        /// </summary>
        /// <param name="navObject">ViewModel to navigate to</param>
        /// <param name="newWindow">Window to navigate to</param>
        public void NavigateWithNewWindow(NavigationViewModelBase navObject, INavigationWindow newWindow)
        {
            if (Provider == null)
                throw new NullReferenceException("The navigation service does not have a registered 'ISimpleNavigationProvider'");

            var args = new WindowEventArgs(newWindow, Provider.Window);

            Navigate(navObject);

            OnBeforeClosing(this, args);
            Provider.Window.TransitionWindow(newWindow);
            OnAfterClosing(this, args);
        }

        /// <summary>
        /// Navigate to the previous object in history
        /// </summary>
        public void NavigateToPrevious()
        {
            if (NavigationHistory.Count <= 0)
                throw new Exception("There is no previous element to navigate");

            var previousNavigation = NavigationHistory[NavigationHistory.Count - 1];
            Navigate(previousNavigation);
        }

        /// <summary>
        /// Register the provider that contains current view
        /// </summary>
        /// <param name="provider"></param>
        public void RegisterProvider(INavigationProvider provider)
        {
            this.Provider = provider;
        }

        /// <summary>
        /// Set the ViewModel navigation defaults to
        /// </summary>
        /// <param name="navigationObject"></param>
        /// <param name="forceIfProviderEmpty"></param>
        public void SetDefaultNavigation(NavigationViewModelBase navigationObject, bool forceIfProviderEmpty = false)
        {
            DefaultNavigation = navigationObject;

            if (forceIfProviderEmpty)
            {
                if (Provider != null)
                    Provider.Current = navigationObject;
            }
        }

        private void OnBeforeNavigate(object sender, NavigationEventArgs e)
        {
            BeforeNavigation?.Invoke(this, e);
        }

        private void OnAfterNavigate(object sender, NavigationEventArgs e)
        {
            AfterNavigation?.Invoke(this, e);
        }

        private void OnBeforeClosing(object sender, WindowEventArgs e)
        {
            BeforeClosing?.Invoke(this, e);
        }

        private void OnAfterClosing(object sender, WindowEventArgs e)
        {
            AfterClosing?.Invoke(this, e);
        }

        private void AddToHistory(NavigationViewModelBase navObj)
        {
            if (NavigationHistory.Count >= MaxHistoryObjects)
                NavigationHistory.RemoveAt(0);

            NavigationHistory.Add(navObj);
        }
    }
}