using SimpleWPF.Core.Components;
using SimpleWPF.Core.Navigation;
using SimpleWPF.Core.Navigation.Arguments;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleWPF.Core.ViewModels
{
    /// <summary>
    /// Base for ViewModels that implements property notification and navigation
    /// </summary>
    public abstract class NavigationViewModelBase : ObservableObject
    {
        protected static Dictionary<string, object> Cache { get; private set; }
        protected NavigationService service { get; private set; }

        public NavigationViewModelBase()
        {
            if (service == null)
                service = NavigationService.Instance;

            if (Cache == null)
                Cache = new Dictionary<string, object>();
        }

        protected virtual void Navigate(NavigationViewModelBase navigationObject)
        {
            service.Navigate(navigationObject);
        }

        protected virtual void NavigateWindow(NavigationViewModelBase navObject, INavigationWindow newWindow)
        {
            service.NavigateWithNewWindow(navObject, newWindow);
        }

        protected virtual void NavigateBack()
        {
            service.NavigateToPrevious();
        }

        protected T GetCacheObject<T>(string key)
        {
            return (T)Cache.FirstOrDefault(x => x.Key == key).Value;
        }

        protected void AddCacheObject(string key, object cacheObject)
        {
            Cache.Add(key, cacheObject);
            OnPropertyChanged("Chache");
        }

        protected void AddOrUpdateCacheObject(string key, object cacheObject)
        {
            if (!Cache.ContainsKey(key))
            {
                AddCacheObject(key, cacheObject);
                return;
            }

            Cache[key] = cacheObject;
            OnPropertyChanged("Chache");
        }

        protected bool RemoveCacheObject(string key)
        {
            var result = Cache.Remove(key);
            OnPropertyChanged("Chache");
            return result;
        }

        protected void ClearCache()
        {
            Cache.Clear();
            OnPropertyChanged("Chache");
        }
    }
}