using Demo.Wpf.ViewModels.Base;
using Demo.Dependencies.Contracts;
using Demo.Wpf.ViewModels.Contracts.UserControls;
using Demo.Wpf.Views.Contracts.Base;
using Demo.Wpf.Views.Contracts.UserControls;

namespace Demo.Wpf.ViewModels.UserControls
{
    public class DepartmentRowViewModel : BaseViewModel, IDepartmentRowViewModel
    {
        private readonly IDepartmentRowView _view;

        public DepartmentRowViewModel(IDependencyContainer dependencyContainer) : base(dependencyContainer)
        {
            this._view = dependencyContainer.Resolve<IDepartmentRowView>();
        }

        public IBaseView GetView() => this._view;
    }
}
