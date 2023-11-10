using Demo.Dependencies.Contracts;
using Demo.Wpf.ViewModels.Base;
using Demo.Wpf.ViewModels.Contracts;
using Demo.Wpf.Views.Contracts;
using Demo.Wpf.Views.Contracts.Base;

namespace Demo.Wpf.ViewModels
{
    public class DepartmentViewModel : BaseViewModel, IDepartmentViewModel
    {
        private readonly IDepartmentView _view;

        public DepartmentViewModel(IDependencyContainer dependencyContainer) : base(dependencyContainer)
        {
            this._view = dependencyContainer.Resolve<IDepartmentView>();

            this.SetDataContext();
        }

        public IBaseView GetView() => this._view;

        protected sealed override void SetDataContext()
        {
            
        }
    }
}
