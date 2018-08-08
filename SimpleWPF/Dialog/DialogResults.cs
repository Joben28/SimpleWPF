using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWPF.Dialog
{
    /// <summary>
    /// Dialog result types.
    /// </summary>
    public enum DialogResults
    {
        /// <summary>
        /// User returned yes.
        /// </summary>
        Yes,

        /// <summary>
        /// User returned no.
        /// </summary>
        No,

        /// <summary>
        /// User returned no specific result.
        /// </summary>
        Undefined
    }
}
