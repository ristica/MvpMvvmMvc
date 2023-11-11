using Demo.Wpf.Views.Contracts.Base;
using System.Windows.Input;

namespace Demo.Wpf.ViewModels.Contracts.Base
{
    public interface IBaseViewModelForWindow
    {
        ICommand CloseCommand { get; }
        IBaseWindow GetWindow();
    }
}
