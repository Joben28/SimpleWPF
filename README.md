# Getting Started

SimpleWPF implements navigation through utilizing data templating. You can either manually define ViewModel and View pairs, or you can rely on these pairs being automatically assigned based on naming conventions.

## STEP 1: Setting up ApplicationViewModel

Typically to get started for navigation, you want to do some simple setup in your applications `App.xaml.cs`. However, before doing this you must create an `ApplicationViewModel` which will be the provider of the navigation service. This view model must implement the `INavigationProvider` interface and it will hold the navigations *current* view model instance, as well as the current view models *window* (If, as you will see later, you use the NavigationWindow).

It also would be neccessary to setup the interface properties to handle property change notification. You can do this by using the `NavigationViewModelBase` as the base class. 

*AppViewModel Example:*
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

Alternatively you could just use the `NavigationProviderViewModel` to avoid needing to implement the interface and view model base.

## STEP 2: Application Startup

Once we have an `ApplicationViewModel` we can proceed to implementing the basic startup in our projects `App.xaml.cs`. We will do this in an override method of `OnStartup`.

*App.xaml.cs Example*
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

- **Option 1:** Simply load data templates based on a naming convention using `LoadDataTemplatesByConvention()`. For example, `RedViewModel` is automatically paired with the `RedView` usercontrol. The pairs are found through the collection of types that exist in the assembly, and are paired by their names. *KEEP IN MIND THIS IS CASE SENSATIVE*. 

- **Option 2:** Use the managers `RegisterDataTemplate()` method to define specific type pairs. This is shown as option 2 in the example above.

### Wait! What about Line  9?
You may be curious as to what exactly is going on here:
````C#
core.Startup(new AppViewModel(), new BlueViewModel(), true);
````

Here we are registering our `AppViewModel` to our navigation service. This is why we needed the provider interface earlier. However, sometimes you would like to instantiate a default view for failed navigations, or you would like to simply force a startup view. In the example, `BlueViewModel` is set as a default navigation object, and the boolean tells it that we want to force this default view on startup. So when we launch the application, the view for `BlueViewModel` is the first thing the user will see.

# STEP 3: Setting up the Window

We have two options for setting up the window. 
- **Option 1:** will require some modification of our xaml in `MainWindow`.
- **Option 2:** will require some code-behind in our `MainWindow`

### Option 1:
As of now, we must also setup our applications launch window for our navigation service to work. I hope to find a way to cut this part out and reduce the amount of boiler plate needed, but for now it is unfortunately neccessary. Luckily, it is very quick and simple.

First, we need to goto our `MainWindow.xaml` and provide a namespace for our SimpleWPF reference. Next, we need to change our `<Window>` tag to `<xxx:NavigationWindow>`.

*MainWindow Example*
````xaml
<simple:NavigationWindow x:Class="SingleWindowSampleApplication.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:SingleWindowSampleApplication"
        xmlns:simple="clr-namespace:SimpleWPF.Core.Navigation;assembly=SimpleWPF.Core"
        mc:Ignorable="d"
        Title="MainWindow" Height="350" Width="525">
````

**You likely will see an error** stating: `Partial declaration must not specify different base classes`, or you may just simply recieve a crash on launch. In order to fix this, we need to jump to our `MainWindow` code-behind, and remove the base class `Window`. **Also, keep in mind you will need to add the appropriate namespace for SimpleWindow in your MainWindow code-behind.**

*Example of Window code-behind*
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
An alternative would be to simply setup the data context in your `MainWindow` code-behind yourself. However, I chose to use `NavigationWindow` in the xaml to eliminate the need of code-behind in the window control. If you would rather do it yourself, you can scrap the `NavigationWindow` all together and do the following in your windows constructor.

````C#
        public MainWindow()
        {
            var provider = SimpleNavigationService.Instance.Provider;

            DataContext = provider;
        }
````

**NOTE:** In case you are wondering, the `Provider` and `NavigationService` are setup in our startup call we made earlier in *Step 2*. The provider is actually our `AppViewModel`.

# STEP 4: Setting up Window Content
Lastly, all we have left to do it give our window a `UserControl` for its content, and bind it to our providers `Current` property.

*MainWindow Content Example*
````xaml
    <Grid>
        <ContentControl Content="{Binding Current}"/>
    </Grid>
````
