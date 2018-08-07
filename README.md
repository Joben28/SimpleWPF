
# SimpleWPF
SimpleWPF is a .Net library for creating simple and fast Windows Presentation Foundation (WPF) applications. This library includes navigation services, command implementations (Including async), and data template management, and more.

## Installation
SimpleWPF can be installed via the nuget package manager console:

    PM> Install-Package SimpleWPF -Version 2.0.2
    
## Application Setup
Before you can start using this library, you unfortunately have some boiler-plate setup you need to do first. Luckily there are only 3 simple steps!

## STEP 1: Implement INavigationProvider

To get started for navigation, you want to do some simple setup in your applications `App.xaml.cs`. Before doing this you must create an `ApplicationViewModel` which will be the provider of the navigation service. This view model must implement the `INavigationProvider` interface.

*Alternatively you could just use the `NavigationProviderViewModel` to avoid needing to implement the interface and view model base.*

***AppViewModel Example:***
````C#
    public class AppViewModel : NavigationViewModelBase, INavigationProvider
    {
        private NavigationViewModelBase current;
        public NavigationViewModelBase Current
        {
            get { return current; }
            set { OnPropertyChanged(ref current, value); }
        }

        private INavigationWindow window;
        public INavigationWindow Window
        {
            get { return window; }
            set { OnPropertyChanged(ref window, value); }
        }
    }
````

## STEP 2: App Startup

Once we have an `INavigationProvider` we can proceed to implementing the basic startup in our projects `App.xaml.cs`. In the example we do this in an override method of `OnStartup`.

***App.xaml.cs Example***
````C#
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

		    //Register AppViewModel and initial view
            SimpleCore core = new SimpleCore();
            core.Startup(new AppViewModel(), new BlueViewModel(), true);

		    //Option 1
            DataTemplateManager manager = new DataTemplateManager();
            manager.LoadDataTemplatesByConvention();

		    //Option 2
            //manager.RegisterDataTemplate(typeof(RedViewModel), typeof(RedView));
		    //OR
		    //manager.RegisterDataTemplate<RedViewModel, RedView>();
        }
    }
````

As you can see there are **two options** for managing your applications data templating. 

- **Option 1:** Simply load data templates based on a naming convention using `LoadDataTemplatesByConvention()`. For example, `xxxViewModel` is automatically paired with the `xxxView` user control. The pairs are found through the collection of types that exist in the assembly, and are paired by their names. *KEEP IN MIND THIS IS CASE SENSATIVE*. 

*Update:* You can now change the naming convention suffix for view models and views with the `ViewModelNameSuffix` and `ViewNameSuffix` properties in the data template manager.


- **Option 2:** Use the managers `RegisterDataTemplate()` method to define specific type pairs. This is shown as option 2 in the example above.

**Wait! What about Line  9?**
You may be curious as to what exactly is going on here:
````C#
core.Startup(new AppViewModel(), new BlueViewModel(), true);
````

Here we are registering our `AppViewModel` to our navigation service. Sometimes you would like to instantiate a default view for failed navigation, or you would like to simply force a startup view. In the example, `BlueViewModel` is set as a default navigation object, and the Boolean tells it that we want to force this default view on startup. So when we launch the application, the view for `BlueViewModel` is the first thing the user will see.

## STEP 3: Implement INavigationWindow

We have two options for setting up the window. 
- **Option 1:** will require some modification of our xaml in `MainWindow`.
- **Option 2:** will require some code-behind in our `MainWindow`

### Option 1:
First, we need to go to our `MainWindow.xaml` and provide a namespace for our SimpleWPF reference. Next, we need to change our `<Window>` tag to `<xxx:NavigationWindow>`.

***MainWindow Example***
````xaml
<simple:NavigationWindow x:Class="SingleWindowSampleApplication.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:SingleWindowSampleApplication"
        xmlns:simple="clr-namespace:SimpleWPF.Core.Navigation;assembly=SimpleWPF"
        mc:Ignorable="d"
        Title="MainWindow" Height="350" Width="525">
````

**You likely will see an error** stating: `Partial declaration must not specify different base classes`. In order to fix this, we need to jump to our `MainWindow` code-behind, and remove the base class `Window`. Also, keep in mind you will need to add the appropriate namespace for SimpleWindow in your MainWindow code-behind.

***Example of Window code-behind***
````C#
    public partial class MainWindow //: Window <-- remove this base class
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }
````

### Option 2:
An alternative would be to simply setup the data context in your `MainWindow` code-behind yourself. If you would rather do it yourself, you can scrap the `NavigationWindow` all together and do the following in your windows constructor.

````C#
        public MainWindow()
        {
            var provider = SimpleNavigationService.Instance.Provider;

            DataContext = provider;
        }
````

*NOTE:* In case you are wondering, the `Provider` and `NavigationService` are setup in our startup call we made earlier in *Step 2*. The provider is actually our `AppViewModel`.

## STEP 4: Setting up Window Content
Lastly, all we have left to do it give our window a `UserControl` for its content, and bind it to our providers `Current` property.

*MainWindow Content Example*
````xaml
    <Grid>
        <ContentControl Content="{Binding Current}"/>
    </Grid>
````
