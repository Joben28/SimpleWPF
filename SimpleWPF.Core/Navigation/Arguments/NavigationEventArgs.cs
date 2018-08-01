using SimpleWPF.Core.ViewModels;
using System;

namespace SimpleWPF.Core.Navigation.Arguments
{
    public delegate void BeforeNavigationEventHandler(object sender, NavigationEventArgs e);

    public delegate void AfterNavigationEventHandler(object sender, NavigationEventArgs e);

    public delegate void BeforeClosingEventHandler(object sender, WindowEventArgs e);

    public delegate void AfterClosingEventHandler(object sender, WindowEventArgs e);

    public class NavigationEventArgs : EventArgs
    {
        /// <summary>
        /// ViewModel being navigated to
        /// </summary>
        public NavigationViewModelBase ViewModelTo { get; private set; }

        /// <summary>
        /// ViewModel being navigated from
        /// </summary>
        public NavigationViewModelBase ViewModelFrom { get; private set; }

        public NavigationEventArgs()
        {
        }

        public NavigationEventArgs(NavigationViewModelBase navigatingTo, NavigationViewModelBase navigatingFrom = null)
        {
            ViewModelTo = navigatingTo;
            ViewModelFrom = navigatingFrom;
        }
    }

    public class WindowEventArgs : EventArgs
    {
        /// <summary>
        /// Window to be navigated to
        /// </summary>
        public INavigationWindow WindowTo { get; private set; }

        /// <summary>
        /// Window being navigated from
        /// </summary>
        public INavigationWindow WindowFrom { get; private set; }

        public WindowEventArgs()
        {
        }

        public WindowEventArgs(INavigationWindow windowTo, INavigationWindow windowFrom = null)
        {
            WindowTo = windowTo;
            WindowFrom = windowFrom;
        }
    }
}