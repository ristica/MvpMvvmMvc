namespace Demo.Wpf.Views.Contracts.Base
{
    public interface IBaseWindow
    {
        void ShowMe();
        void CloseMe();
        void ShowModalMe();
        void SetDataContext<T>(T viewModel);
    }
}
