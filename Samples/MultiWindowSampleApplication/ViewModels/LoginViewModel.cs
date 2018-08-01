using MultiWindowSampleApplication.Models;
using SimpleWPF.Input;
using SimpleWPF.ViewModels;
using System.Windows.Input;
using TestingApplication.Models.Cache;

namespace MultiWindowSampleApplication
{
    public class LoginViewModel : NavigationViewModelBase
    {
        public ICommand LoginCommand { get; set; }

        public LoginViewModel()
        {
            LoginCommand = new RelayCommand(Login);
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