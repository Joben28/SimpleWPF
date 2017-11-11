using SimpleWPF.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWPF.Core.Navigation.Arguments
{
    public delegate void BeforeNavigationEventHandler(object sender, NavigationEventArgs e);
    public delegate void AfterNavigationEventHandler(object sender, NavigationEventArgs e);
    public delegate void BeforeClosingEventHandler(object sender, WindowEventArgs e);
    public delegate void AfterClosingEventHandler(object sender, WindowEventArgs e);

    public class NavigationEventArgs : EventArgs
    {
        public SimpleViewModel ViewModelTo { get; private set; }
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
        public ISimpleWindow WindowTo { get; private set; }
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
