using Demo.Models.Contracts.CustomerDomain;
using Demo.Wpf.ViewModels.Contracts.Base;

namespace Demo.Wpf.ViewModels.Contracts.UserControls;

public interface ICustomerRowViewModel : IBaseViewModelForView
{
    ICustomerModel Customer { get; set; }
    void PropagateDataContext();
}