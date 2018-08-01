using SimpleWPF.Navigation;
using SimpleWPF.ViewModels;
using System;
using TestingApplication.Models.Cache;

namespace MultiWindowSampleApplication.ViewModels
{
    public class AuthorizedViewModel : NavigationViewModelBase
    {
        protected override void Navigate(NavigationViewModelBase navigationObject)
        {
            if (navigationObject is AuthorizedViewModel authVM)
            {
                if (VerifyNavigation(authVM))
                {
                    base.Navigate(navigationObject);
                    return;
                }

                base.NavigateWindow(service.DefaultNavigation, new LoginWindow());
                return;
            }
            base.Navigate(navigationObject);
        }

        protected override void NavigateWindow(NavigationViewModelBase navObject, INavigationWindow newWindow)
        {
            if (navObject is AuthorizedViewModel authVM)
            {
                if (VerifyNavigation(authVM))
                {
                    base.Navigate(navObject);
                    return;
                }

                base.NavigateWindow(service.DefaultNavigation, new LoginWindow());
                return;
            }
            base.NavigateWindow(navObject, newWindow);
        }

        private bool VerifyNavigation(AuthorizedViewModel authorizedViewModel)
        {
            var token = GetCacheObject<AuthCache>("auth");
            if (token != null)
            {
                if (token.Timeout >= DateTime.Now)
                {
                    return true;
                }
            }
            return false;
        }
    }
}