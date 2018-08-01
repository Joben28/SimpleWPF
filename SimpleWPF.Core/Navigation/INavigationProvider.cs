using SimpleWPF.Core.ViewModels;

namespace SimpleWPF.Core.Navigation
{
    /// <summary>
    /// An interface for a main object handling navigation.
    /// </summary>
    public interface INavigationProvider
    {
        /// <summary>
        /// Current navigation object.
        /// </summary>
        NavigationViewModelBase Current { get; set; }

        /// <summary>
        /// Window displaying the current navigation object.
        /// </summary>
        INavigationWindow Window { get; set; }
    }
}