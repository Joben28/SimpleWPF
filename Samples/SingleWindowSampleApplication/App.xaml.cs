using SimpleWPF.Core;
using SingleWindowSampleApplication.ViewModels;
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
            DataTemplateManager manager = new DataTemplateManager();
            manager.LoadDataTemplatesByConvention();

            //Alternative would be to manually pair types
            //This would idealy be used if you do not follow
            //the naming conventions 'View' and 'ViewModel'
            //manager.RegisterDataTemplate<RedViewModel, RedView>();
        }
    }
}