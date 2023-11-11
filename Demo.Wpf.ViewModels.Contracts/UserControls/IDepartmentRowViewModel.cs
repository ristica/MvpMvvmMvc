using Demo.Models.Contracts.DepartmentDomain;
using Demo.Wpf.ViewModels.Contracts.Base;

namespace Demo.Wpf.ViewModels.Contracts.UserControls;

public interface IDepartmentRowViewModel : IBaseViewModelForView
{
    IDepartmentModel Department { get; set; }
    void PropagateDataContext();
}