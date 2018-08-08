using DialogSampleApplication.Dialogs;
using DialogSampleApplication.Dialogs.Alert;
using SimpleWPF.Dialog;
using SimpleWPF.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DialogSampleApplication
{
    public class AppViewModel
    {
        private IDialogService _service;
        public ICommand ShowAlertCommand { get; private set; }

        public AppViewModel()
        {
            //Setup service, normally this would be dependency injected.
            _service = new DialogService(new DialogWindow());

            ShowAlertCommand = new RelayCommand(ShowAlert);
        }

        private void ShowAlert()
        {
            _service.OpenDialog(new AlertDialogViewModel("Alert", "Can you see this?"));
        }
    }
}
