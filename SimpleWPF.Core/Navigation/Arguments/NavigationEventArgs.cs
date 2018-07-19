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
        public SimpleViewModel ViewModelTo { get; private set; }

        /// <summary>
        /// ViewModel being navigated from
        /// </summary>
        public SimpleViewModel ViewModelFrom { get; private set; }

        public NavigationEventArgs()
        {
        }

        public NavigationEventArgs(SimpleViewModel navigatingTo, SimpleViewModel navigatingFrom = null)
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
        public ISimpleWindow WindowTo { get; private set; }

        /// <summary>
        /// Window being navigated from
        /// </summary>
        public ISimpleWindow WindowFrom { get; private set; }

        public WindowEventArgs()
        {
        }

        public WindowEventArgs(ISimpleWindow windowTo, ISimpleWindow windowFrom = null)
        {
            WindowTo = windowTo;
            WindowFrom = windowFrom;
        }
    }
}