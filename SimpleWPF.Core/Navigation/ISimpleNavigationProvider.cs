using SimpleWPF.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWPF.Core.Navigation
{
    /// <summary>
    /// An interface for a main object handling navigation.
    /// </summary>
    public interface ISimpleNavigationProvider
    {
        /// <summary>
        /// Current navigation object.
        /// </summary>
        SimpleViewModel Current { get; set; }

        /// <summary>
        /// Window displaying the current navigation object.
        /// </summary>
        ISimpleWindow Window { get; set; }
    }
}
