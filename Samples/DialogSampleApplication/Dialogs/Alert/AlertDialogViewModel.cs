using SimpleWPF.Dialog;
using SimpleWPF.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DialogSampleApplication.Dialogs.Alert
{
    //This only returnes a simple DialogResults enum. However, the return type could be anything (string, object, etc.)
    public class AlertDialogViewModel : DialogViewModelBase<DialogResults>
    {
        public ICommand OKCommand { get; private set; }

        public AlertDialogViewModel(string title, string message) : base(title, message)
        {
            OKCommand = new RelayCommand<IDialogWindow>(OK);
        }

        //Window must be passed in param to close.
        private void OK(IDialogWindow window)
        {
            CloseDialogWithResult(window, DialogResults.Undefined);
        }
    }
}
