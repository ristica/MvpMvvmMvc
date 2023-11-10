using Demo.Wpf.Views.Contracts.Base;

namespace Demo.Wpf.ViewModels.Contracts.Base
{
    public interface IBaseViewModelForView
    {
        IBaseView GetView();
    }
}
