using SimpleWPF.Core.Core;
using SingleWindowSampleApplication.ViewModels;
using SingleWindowSampleApplication.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace SingleWindowSampleApplication
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

            //The 2nd and 3rd parameters are optional. 
            //2nd: Sets a default viewmodel.
            //3rd: Force auto-navigate to default on startup.
            core.Startup(new AppViewModel(), new BlueViewModel(), true);

            //Load Templates based on naming convention
            //EX: 'RedViewModel' will be paired with 'RedView'
            SimpleDataTemplateManager manager = new SimpleDataTemplateManager();
            manager.LoadDataTemplatesByConvention();

            //Alternative would be to manually pair types
            //This would idealy be used if you do not follow
            //the naming conventions 'View' and 'ViewModel'
            //manager.RegisterDataTemplate<RedViewModel, RedView>();
        }
    }
}
