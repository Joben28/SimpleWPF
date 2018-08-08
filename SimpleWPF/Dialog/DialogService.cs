using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWPF.Dialog
{
    /// <summary>
    /// Service for displaying dialogs.
    /// </summary>
    public class DialogService : IDialogService
    {
        private IDialogWindow _window;

        /// <param name="window">Window to open dialog content in.</param>
        public DialogService(IDialogWindow window)
        {
            _window = window;
        }

        /// <summary>
        /// Open a dialog window.
        /// </summary>
        /// <typeparam name="T">Dialog result type.</typeparam>
        /// <param name="viewModel">Dialog view model.</param>
        /// <returns>returns <typeparamref name="T"/> result.</returns>
        public T OpenDialog<T>(DialogViewModelBase<T> viewModel)
        {
            var window = (IDialogWindow)Activator.CreateInstance(_window.GetType());
            window.DataContext = viewModel ?? throw new ArgumentNullException(nameof(viewModel));
            window.ShowDialog();
            return viewModel.DialogResult;
        }
    }
}
