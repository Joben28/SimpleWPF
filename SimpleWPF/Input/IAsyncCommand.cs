using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SimpleWPF.Input
{
    public interface IAsyncCommand : ICommand
    {
        AsyncNotificationStatus Status { get; set; }
    }
}
