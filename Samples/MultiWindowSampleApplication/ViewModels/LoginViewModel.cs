using LoginSampleApplication.Models;
using SimpleWPF.Core.Core;
using SimpleWPF.Core.Navigation;
using SimpleWPF.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TestingApplication.Models.Cache;

namespace LoginSampleApplication
{
    public class LoginViewModel : SimpleViewModel
    {
        public ICommand LoginCommand { get; set; }

        public LoginViewModel()
        {
            LoginCommand = new SimpleRelayCommand(Login);
        }

        private void Login(object obj)
        {
            var auth = new AuthCache();
            var account = new AccountModel();

            AddCacheObject("auth", auth);
            AddCacheObject("user", account);

            NavigateWindow(new NewPostViewModel(), new MainWindow());         
        }
    }
}
