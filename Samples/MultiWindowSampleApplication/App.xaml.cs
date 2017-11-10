using MultiWindowSampleApplication.ViewModels;
using SimpleWPF.Core.Core;
using SimpleWPF.Core.Navigation;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
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

            SimpleDataTemplateManager manager = new SimpleDataTemplateManager();
            manager.LoadDataTemplatesByConvention();
        }
    }
}
