using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWPF.Dialog
{
    public interface IDialogWindow
    {
        /// <summary>
        /// Gets or sets the dialog result value, which is the value returned from <see cref="ShowDialog"/> method.
        /// </summary>
        bool? DialogResult { get; set; }

        /// <summary>
        /// Gets or sets the data context for an element when it participates in data binding.
        /// </summary>
        object DataContext { get; set; }

        /// <summary>
        /// Opens a window and returns only when the newly opened window is closed.
        /// </summary>
        /// <returns>returns <see cref="DialogResult"/></returns>
        bool? ShowDialog();
    }
}
