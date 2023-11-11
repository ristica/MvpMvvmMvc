using System.Windows.Input;
using Demo.Common.Contracts;
using Demo.Common.Shared;
using Demo.Wpf.ViewModels.Base;
using Demo.Dependencies.Contracts;
using Demo.Wpf.ViewModels.Commands;
using Demo.Wpf.ViewModels.Contracts.UserControls;
using Demo.Wpf.Views.Contracts.Base;
using Demo.Wpf.Views.Contracts.UserControls;
using Demo.Models.Contracts.CustomerDomain;
using Demo.Services.Contracts;

namespace Demo.Wpf.ViewModels.UserControls
{
    public class CustomerRowViewModel : BaseViewModel, ICustomerRowViewModel
    {
        #region FIELDS

        private readonly ICustomerRowView _view;
        private readonly ICustomerService<ICustomerModel> _service;
        private readonly IMessageNotificationsHelper _messageNotificationsHelper;
        private ICustomerModel _customer;

        #endregion

        #region PROPERTIES

        public ICustomerModel Customer
        {
            get => this._customer;
            set
            {
                this._customer = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region COMMANDS

        public ICommand DeleteCustomerCommand { get; private set; }

        #endregion

        #region C-TOR

        public CustomerRowViewModel(IDependencyContainer dependencyContainer) : base(dependencyContainer)
        {
            this._view = dependencyContainer.Resolve<ICustomerRowView>();
            this._service = dependencyContainer.Resolve<ICustomerService<ICustomerModel>>();
            this._messageNotificationsHelper = dependencyContainer.Resolve<IMessageNotificationsHelper>();

            this.RegisterCommands();
        }

        #endregion

        #region METHODS

        public IBaseView GetView() => this._view;

        public void PropagateDataContext()
        {
            this._view.SetDataContext(this);
        }

        #endregion

        #region HELPERS

        private void RegisterCommands() 
        {
            this.DeleteCustomerCommand =
                new DelegateCommand(ExecuteDeleteCustomerCommand, CanExecuteDeleteCustomerCommand);
        }

        private void ExecuteDeleteCustomerCommand(object obj)
        {
            var customerId = (int)obj;
            this._service.Delete(customerId);

            this._messageNotificationsHelper.Publish(
                this,
                new ButtonIdEventArgs(customerId),
                (int)MessageType.CustomerDeletedMessage);
        }

        private bool CanExecuteDeleteCustomerCommand(object arg) => true;

        #endregion
    }
}
