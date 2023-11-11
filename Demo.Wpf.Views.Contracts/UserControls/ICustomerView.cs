using Demo.Wpf.Views.Contracts.Base;
using System.Windows.Controls;

namespace Demo.Wpf.Views.Contracts.UserControls
{
    public interface ICustomerView : IBaseView
    {
        StackPanel GetPanelControl();
    }
}