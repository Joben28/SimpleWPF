using SimpleWPF.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleWPF.Core.Navigation;
using MultiWindowSampleApplication.Models;
using TestingApplication.Models.Cache;

namespace MultiWindowSampleApplication.ViewModels
{
    public class AuthorizedViewModel : SimpleViewModel
    {
        protected override void Navigate(SimpleViewModel navigationObject)
        {
            if(navigationObject is AuthorizedViewModel authVM)
            {
                if(VerifyNavigation(authVM))
                {
                    base.Navigate(navigationObject);
                    return;
                }

                base.NavigateWindow(service.DefaultNavigation, new LoginWindow());
                return;
            }
            base.Navigate(navigationObject);
        }

        protected override void NavigateWindow(SimpleViewModel navObject, ISimpleWindow newWindow)
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
                if(token.Timeout >= DateTime.Now)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
