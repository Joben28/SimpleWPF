using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWPF.Dialog
{
    /// <summary>
    /// A base class for a dialog view model.
    /// </summary>
    /// <typeparam name="T">Type of dialog result returned.</typeparam>
    public abstract class DialogViewModelBase<T>
    {
        /// <summary>
        /// Gets or sets a window's title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the content message.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the dialog result.
        /// </summary>
        public T DialogResult { get; set; }

        public DialogViewModelBase() : this(string.Empty, string.Empty)
        {
        }

        /// <param name="title">Window title.</param>
        public DialogViewModelBase(string title) : this(title, string.Empty)
        {
        }

        /// <param name="title">Window title.</param>
        /// <param name="message">Content message.</param>
        public DialogViewModelBase(string title, string message)
        {
            Title = title;
            Message = message;
        }

        /// <summary>
        /// Closes the dialog window and sets the result.
        /// </summary>
        /// <param name="dialog">Window of the dialog.</param>
        /// <param name="result">Result from dialog view model.</param>
        public void CloseDialogWithResult(IDialogWindow dialog, T result)
        {
            DialogResult = result;

            if (dialog != null)
                dialog.DialogResult = true;
        }
    }
}
