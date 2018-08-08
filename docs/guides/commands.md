# RelayCommand
The `RelayCommand` is a standard `ICommand` implementation for non-asynchronous operations. It can accept an `Action<T>` parameter, or be parameterless.

**Code Example:**
`````C# 
public class FooViewModel
{
	public ICommand BarCommand { get; private set; }
	public ICommand BarParamCommand { get; private set; }

	public FooViewModel()
	{
		BarCommand = new RelayCommand(DoBar, CanDoBar);//Optional 'CanDoBar' for CanExecute
		BarParamCommand = new RelayCommand<string>(DoBarParam)
	}

	private void DoBar()
	{
		Console.WriteLine("Doing Bar stuff...");
	}
	
	private void DoBarParam(string message)
	{
		Console.WriteLine(message);
	}
	
	private bool CanDoBar()
	{
		return true;
	}
}

`````

# AsyncCommand
The `AsyncCommand` is a simple asynchronous command implementation with a bindable `Status` property which can indicate if the current task is busy, had an error, or is complete. Currently all `AsyncCommand`'s take an `object` parameter -- but can be used on methods without parameters as shown in the example below.

**Code Example:**
````C#
    public class FooViewModel
    {
        public IAsyncCommand BarCommand { get; set; }
        public IAsyncCommand BarParamCommand { get; set; }

        public FooViewModel()
        {
            BarCommand = new AsyncCommand(x => DoBar());
            BarParamCommand = new AsyncCommand(DoBarParam);
        }

        private async Task DoBarParam(object arg)
        {
            await Task.Delay(3000);
            Console.WriteLine("Bar is done!");
        }

        private async Task DoBar()
        {
            await Task.Delay(3000);
            Console.WriteLine("Bar is done!");
        }
    }
````

Here is what the XAML content would look like if you were to bind and also bind to the `IAsyncCommand` property `Status`.

**Code Example:**
````XAML
    <StackPanel>
        <Button Content="Async W/ out param" Command="{Binding BarCommand}"/>
        <Label Content="{Binding BarCommand.Status}"/>
        <Button Content="Async W/ param" Command="{Binding BarParamCommand}"/>
        <Label Content="{Binding BarParamCommand.Status}"/>
    </StackPanel>
````

**The View:**

![](https://github.com/Joben28/SimpleWPF/blob/master/AsyncExampleView.png?raw=true)
