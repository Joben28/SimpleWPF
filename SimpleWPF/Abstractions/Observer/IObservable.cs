using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWPF
{
    internal interface IObservable
    {
        IList<IObserver> Observers { get; }
        void Notify();
        void Register(IObserver observer);
        void Unregister(IObserver observer);
    }
}
