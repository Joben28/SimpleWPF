using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SimpleWPF.Core.Input
{
    public interface ISimpleAsyncCommand : ICommand
    {
        bool IsCanceled { get; }
        void ExecuteAsync(Task parameter);
        void CancelAsync();
    }
}
