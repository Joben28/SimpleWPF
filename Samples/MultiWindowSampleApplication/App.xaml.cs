using MultiWindowSampleApplication.ViewModels;
using SimpleWPF.Core.Core;
using System.Windows;

namespace MultiWindowSampleApplication
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            SimpleCore core = new SimpleCore();
            var appVm = new AppViewModel();
            var loginVm = new LoginViewModel();
            core.Startup(appVm, loginVm, true);

            DataTemplateManager manager = new DataTemplateManager();
            manager.LoadDataTemplatesByConvention();
        }
    }
}