namespace SimpleWPF.Core.Navigation
{
    public interface ISimpleWindow
    {
        void ShowWindow();

        void CloseWindow();

        void SetDataContext(object dataContext);

        void TransitionWindow(ISimpleWindow to);
    }
}