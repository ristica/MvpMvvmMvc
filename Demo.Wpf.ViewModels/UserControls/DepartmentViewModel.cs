using Demo.Dependencies.Contracts;
using Demo.Wpf.ViewModels.Base;
using Demo.Wpf.ViewModels.Contracts.UserControls;
using Demo.Wpf.Views.Contracts.Base;
using Demo.Wpf.Views.Contracts.UserControls;

namespace Demo.Wpf.ViewModels.UserControls
{
    public class DepartmentViewModel : BaseViewModel, IDepartmentViewModel
    {
        private readonly IDepartmentView _view;

        public DepartmentViewModel(IDependencyContainer dependencyContainer) : base(dependencyContainer)
        {
            this._view = dependencyContainer.Resolve<IDepartmentView>();
        }

        public IBaseView GetView() => this._view;
    }
}
