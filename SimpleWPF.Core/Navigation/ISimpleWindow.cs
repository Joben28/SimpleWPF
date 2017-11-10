using SimpleWPF.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWPF.Core.Navigation
{
    public interface ISimpleWindow
    {
        void ShowWindow();
        void CloseWindow();
        void SetDataContext(object dataContext);
        void TransitionWindow(ISimpleWindow to);
    }
}
