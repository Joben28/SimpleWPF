﻿using SimpleWPF.Core.Navigation.Arguments;
using SimpleWPF.Core.ViewModels;
using System;
using System.Collections.ObjectModel;

namespace SimpleWPF.Core.Navigation
{
    public sealed class SimpleNavigationService
    {
        public static readonly SimpleNavigationService Instance = new SimpleNavigationService();

        public ObservableCollection<SimpleViewModel> NavigationHistory { get; private set; } = new ObservableCollection<SimpleViewModel>();
        public ISimpleNavigationProvider Provider { get; private set; }
        public SimpleViewModel DefaultNavigation { get; private set; }
        public int MaxHistoryObjects { get; set; } = 5;

        public event BeforeNavigationEventHandler BeforeNavigation;

        public event AfterNavigationEventHandler AfterNavigation;

        public event BeforeClosingEventHandler BeforeClosing;

        public event AfterClosingEventHandler AfterClosing;

        private SimpleNavigationService()
        {
        }

        public void Navigate(SimpleViewModel navObject)
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

        public void NavigateWithNewWindow(SimpleViewModel navObject, ISimpleWindow newWindow)
        {
            if (Provider == null)
                throw new NullReferenceException("The navigation service does not have a registered 'ISimpleNavigationProvider'");

            var args = new WindowEventArgs(newWindow, Provider.Window);

            Navigate(navObject);

            OnBeforeClosing(this, args);
            Provider.Window.TransitionWindow(newWindow);
            OnAfterClosing(this, args);
        }

        public void NavigateToPrevious()
        {
            if (NavigationHistory.Count <= 0)
                throw new Exception("There is no previous element to navigate");

            var previousNavigation = NavigationHistory[NavigationHistory.Count - 1];
            Navigate(previousNavigation);
        }

        public void RegisterProvider(ISimpleNavigationProvider provider)
        {
            this.Provider = provider;
        }

        public void SetDefaultNavigation(SimpleViewModel navigationObject, bool forceIfProviderEmpty = false)
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

        private void AddToHistory(SimpleViewModel navObj)
        {
            if (NavigationHistory.Count >= MaxHistoryObjects)
                NavigationHistory.RemoveAt(0);

            NavigationHistory.Add(navObj);
        }
    }
}