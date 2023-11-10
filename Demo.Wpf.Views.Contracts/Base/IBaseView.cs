namespace Demo.Wpf.Views.Contracts.Base
{
    public interface IBaseView
    {
        void SetDataContext<T>(T viewModel);
    }
}
