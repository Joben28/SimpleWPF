using MultiWindowSampleApplication.Models;
using SimpleWPF.Core.Input;
using SimpleWPF.Core.ViewModels;
using System.Windows.Input;
using TestingApplication.Models.Cache;

namespace MultiWindowSampleApplication
{
    public class LoginViewModel : SimpleViewModel
    {
        public ICommand LoginCommand { get; set; }

        public LoginViewModel()
        {
            LoginCommand = new SimpleRelayCommand(Login);
        }

        private void Login()
        {
            var auth = new AuthCache();
            var account = new AccountModel();

            AddCacheObject("auth", auth);
            AddCacheObject("user", account);

            NavigateWindow(new NewPostViewModel(), new MainWindow());
        }
    }
}