using Demo.Dependencies.Contracts;
using Demo.Wpf.ViewModels.Base;
using Demo.Wpf.ViewModels.Contracts.UserControls;
using Demo.Wpf.Views.Contracts.Base;
using Demo.Wpf.Views.Contracts.UserControls;

namespace Demo.Wpf.ViewModels.UserControls
{
    public class DepartmentViewModel : BaseViewModel, IDepartmentViewModel
    {
        #region FIELDS

        private readonly IDepartmentView _view;

        #endregion

        #region C-TOR

        public DepartmentViewModel(IDependencyContainer dependencyContainer) : base(dependencyContainer)
        {
            this._view = dependencyContainer.Resolve<IDepartmentView>();
        }

        #endregion

        #region METHODS

        public IBaseView GetView() => this._view;

        #endregion
    }
}
