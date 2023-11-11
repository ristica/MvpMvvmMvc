using Demo.Dependencies.Contracts;
using Demo.Models.Contracts.DepartmentDomain;
using Demo.Services.Contracts;
using Demo.Wpf.ViewModels.Base;
using Demo.Wpf.ViewModels.Contracts.UserControls;
using Demo.Wpf.Views.Contracts.Base;
using Demo.Wpf.Views.Contracts.UserControls;
using System.Windows;

namespace Demo.Wpf.ViewModels.UserControls
{
    public class DepartmentViewModel : BaseViewModel, IDepartmentViewModel
    {
        #region FIELDS

        private readonly IDepartmentView _view;
        private readonly IDepartmentService<IDepartmentModel> _service;

        #endregion

        #region C-TOR

        public DepartmentViewModel(IDependencyContainer dependencyContainer) : base(dependencyContainer)
        {
            this._view = dependencyContainer.Resolve<IDepartmentView>();
            this._service = dependencyContainer.Resolve<IDepartmentService<IDepartmentModel>>();

            this.LoadAllDepartments();
        }

        #endregion

        #region METHODS

        public IBaseView GetView() => this._view;

        #endregion

        #region HELPERS

        private void LoadAllDepartments()
        {
            var departments = this._service.GetAll();

            foreach (var d in departments)
            {
                var rowViewModel = DependencyContainer.Resolve<IDepartmentRowViewModel>();

                rowViewModel.Department = d;
                rowViewModel.PropagateDataContext();

                this._view.GetPanelControl().Children.Add(rowViewModel.GetView() as UIElement);
            }
        }

        #endregion
    }
}
