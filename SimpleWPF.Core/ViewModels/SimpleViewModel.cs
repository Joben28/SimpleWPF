using SimpleWPF.Core.Core;
using SimpleWPF.Core.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWPF.Core.ViewModels
{
    public class SimpleViewModel : SimplePropertyChanged
    {
        protected static Dictionary<string, object> Cache { get; private set; }
        protected SimpleNavigationService service { get; private set; }

        public SimpleViewModel()
        {
            if(service == null)
                service = SimpleSingleton
                    .GetSingleton<SimpleNavigationService>();

            if(Cache == null)
                Cache = new Dictionary<string, object>();
        }

        protected virtual void Navigate(SimpleViewModel navigationObject)
        {
            if (service == null)
                throw new NullReferenceException("A 'SimpleNavigationService' has not been provided.");
            //gg
            service.Navigate(navigationObject);
        }

        public virtual void NavigateWindow(SimpleViewModel navObject, ISimpleWindow newWindow)
        {
            service.NavigateWithNewWindow(navObject, newWindow);
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
