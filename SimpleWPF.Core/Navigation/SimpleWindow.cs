using SimpleWPF.Core.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SimpleWPF.Core.Navigation
{
    public class SimpleWindow : Window, ISimpleWindow
    {
        private ISimpleNavigationHandler provider;

        public SimpleWindow()
        {
            provider = SimpleSingleton
                .GetSingleton<SimpleNavigationService>()
                .GetProvider();

            if (provider.Window == null)
                provider.Window = this;

            DataContext = provider;
        }

        public void CloseWindow()
        {
            Close();
        }

        public void SetDataContext(object dataContext)
        {
            DataContext = dataContext;
        }

        public void ShowWindow()
        {
            Show();
        }

        public void TransitionWindow(ISimpleWindow to)
        {
            to.SetDataContext(DataContext);
            to.ShowWindow();

            CloseWindow();
            provider.Window = to;
        }
    }
}
