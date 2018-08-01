using System.Windows;

namespace SimpleWPF.Core.Navigation
{
    /// <summary>
    /// Base for navigation window
    /// </summary>
    public class NavigationWindow : Window, INavigationWindow
    {
        private INavigationProvider provider;

        public NavigationWindow()
        {
            provider = NavigationService.Instance.Provider;

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

        public void TransitionWindow(INavigationWindow to)
        {
            to.SetDataContext(DataContext);
            to.ShowWindow();

            CloseWindow();
            provider.Window = to;
        }
    }
}