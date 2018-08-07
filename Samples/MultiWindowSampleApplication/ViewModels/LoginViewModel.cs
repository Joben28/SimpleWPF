using MultiWindowSampleApplication.Models;
using SimpleWPF.Input;
using SimpleWPF.ViewModels;
using System.Threading.Tasks;
using System.Windows.Input;
using TestingApplication.Models.Cache;

namespace MultiWindowSampleApplication
{
    public class LoginViewModel : NavigationViewModelBase
    {
        public IAsyncCommand LoginCommand { get; set; }
        public LoginViewModel()
        {
            LoginCommand = new AsyncCommand(async (parameter) => await Login());
        }

        private async Task Login()
        {
            var auth = new AuthCache();
            var account = new AccountModel();
            await Task.Delay(2000);
            AddCacheObject("auth", auth);
            AddCacheObject("user", account);

            NavigateWindow(new NewPostViewModel(), new MainWindow());
        }
    }
}