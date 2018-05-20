using SimpleWPF.Core.Components;
using SimpleWPF.Core.Navigation;
using System.Collections.Generic;
using System.Linq;

namespace SimpleWPF.Core.ViewModels
{
    public class SimpleViewModel : SimplePropertyChanged
    {
        protected static Dictionary<string, object> Cache { get; private set; }
        protected SimpleNavigationService service { get; private set; }

        public SimpleViewModel()
        {
            if (service == null)
                service = SimpleNavigationService.Instance;

            if (Cache == null)
                Cache = new Dictionary<string, object>();
        }

        protected virtual void Navigate(SimpleViewModel navigationObject)
        {
            service.Navigate(navigationObject);
        }

        protected virtual void NavigateWindow(SimpleViewModel navObject, ISimpleWindow newWindow)
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