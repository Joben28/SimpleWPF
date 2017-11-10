using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWPF.Core.Core
{
    public abstract class SimpleSingleton : IDisposable
    {
        private static readonly List<SimpleSingleton> Singletons = new List<SimpleSingleton>();

        protected int Count
        {
            get
            {
                return Singletons != null ? Singletons.Count : 0;
            }
        }

        protected SimpleSingleton()
        {
            lock(Singletons)
            {
                Singletons.Add(this);
            }
        }

        public static void ClearAllSingletons()
        {
            lock (Singletons)
            {
                foreach (var s in Singletons)
                {
                    s.Dispose();
                }

                Singletons.Clear();
            }
        }

        public static T GetSingleton<T>() where T : SimpleSingleton
        {
            return (T)Singletons.First(x => x.GetType() == typeof(T));
        }

        public static T AddSingleton<T>() where T : SimpleSingleton
        {
            return Activator.CreateInstance<T>();
        }

        public void Dispose()
        {
            Dispose();
        }
    }

    public abstract class SimpleSingleton<T> : SimpleSingleton
    {
        public SimpleSingleton Instance { get; private set; }

        public SimpleSingleton()
        {
            if (Instance != null)
                throw new Exception("You cannot create more than one instance of a SimpleSingleton.");

            Instance = this;
        }
    }
}
