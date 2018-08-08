using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWPF.Dialog
{
    public interface IDialogService
    {
        /// <summary>
        /// Opens a dialog window with the content provided for the <see cref="DialogViewModelBase{T}"/>.
        /// </summary>
        /// <typeparam name="T">Type of dialog result.</typeparam>
        /// <param name="viewModel">Dialog view model.</param>
        /// <returns>returns <typeparamref name="T"/> result.</returns>
        T OpenDialog<T>(DialogViewModelBase<T> viewModel);
    }
}
