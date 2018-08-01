namespace SimpleWPF.Core.Navigation
{
    public interface INavigationWindow
    {
        void ShowWindow();

        void CloseWindow();

        void SetDataContext(object dataContext);

        void TransitionWindow(INavigationWindow to);
    }
}