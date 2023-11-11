using System.Windows.Controls;
using Demo.Wpf.Views.Contracts.Base;

namespace Demo.Wpf.Views.Contracts.Windows
{
    public interface IMainWindow : IBaseWindow
    {
        Border GetContentPanel();
    }
}
