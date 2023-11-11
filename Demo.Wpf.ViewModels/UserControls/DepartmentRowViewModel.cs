using Demo.Wpf.ViewModels.Base;
using Demo.Dependencies.Contracts;
using Demo.Wpf.ViewModels.Contracts.UserControls;
using Demo.Wpf.Views.Contracts.Base;
using Demo.Wpf.Views.Contracts.UserControls;

namespace Demo.Wpf.ViewModels.UserControls
{
    public class DepartmentRowViewModel : BaseViewModel, IDepartmentRowViewModel
    {
        #region FIELDS

        private readonly IDepartmentRowView _view;

        #endregion

        #region C-TOR

        public DepartmentRowViewModel(IDependencyContainer dependencyContainer) : base(dependencyContainer)
        {
            this._view = dependencyContainer.Resolve<IDepartmentRowView>();
        }

        #endregion

        #region METHODS

        public IBaseView GetView() => this._view;

        #endregion
    }
}
