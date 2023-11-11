using Demo.Dependencies.Contracts;
using Demo.Wpf.ViewModels.Base;
using Demo.Wpf.ViewModels.Contracts.UserControls;
using Demo.Wpf.Views.Contracts.Base;
using Demo.Wpf.Views.Contracts.UserControls;
using System.Windows;
using Demo.Models.Contracts.CustomerDomain;
using Demo.Services.Contracts;

namespace Demo.Wpf.ViewModels.UserControls
{
    public class CustomerViewModel : BaseViewModel, ICustomerViewModel
    {
        #region FIELDS

        private readonly ICustomerView _view;
        private readonly ICustomerService<ICustomerModel> _service;

        #endregion

        #region C-TOR

        public CustomerViewModel(IDependencyContainer dependencyContainer) : base(dependencyContainer)
        {
            this._view = dependencyContainer.Resolve<ICustomerView>();
            this._service = dependencyContainer.Resolve<ICustomerService<ICustomerModel>>();

            this.LoadAllCustomers();
        }

        #endregion

        #region METHODS

        public IBaseView GetView() => this._view;

        #endregion

        #region HELPERS

        private void LoadAllCustomers()
        {
            var customers = this._service.GetAll();

            foreach (var c in customers)
            {
                var rowViewModel = DependencyContainer.Resolve<ICustomerRowViewModel>();

                rowViewModel.Customer = c;
                rowViewModel.PropagateDataContext();

                this._view.GetPanelControl().Children.Add(rowViewModel.GetView() as UIElement);
            }
        }

        #endregion
    }
}
