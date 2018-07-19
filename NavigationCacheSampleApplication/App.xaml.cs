using NavigationCacheSampleApplication.ViewModels;
using SimpleWPF.Core.Core;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace NavigationCacheSampleApplication
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
            var redVm = new RedViewModel();
            core.Startup(appVm, redVm, true);

            SimpleDataTemplateManager manager = new SimpleDataTemplateManager();
            manager.LoadDataTemplatesByConvention();
        }
    }
}
