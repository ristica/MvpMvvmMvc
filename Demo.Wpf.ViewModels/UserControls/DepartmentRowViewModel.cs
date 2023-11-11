using Demo.Wpf.ViewModels.Base;
using Demo.Dependencies.Contracts;
using Demo.Models.Contracts.DepartmentDomain;
using Demo.Wpf.ViewModels.Contracts.UserControls;
using Demo.Wpf.Views.Contracts.Base;
using Demo.Wpf.Views.Contracts.UserControls;
using Demo.Common.Contracts;
using Demo.Models.Contracts.CustomerDomain;
using Demo.Services.Contracts;
using System.Windows.Input;
using Demo.Common.Shared;
using Demo.Wpf.ViewModels.Commands;

namespace Demo.Wpf.ViewModels.UserControls
{
    public class DepartmentRowViewModel : BaseViewModel, IDepartmentRowViewModel
    {
        #region FIELDS

        private readonly IDepartmentRowView _view;
        private readonly IDepartmentService<IDepartmentModel> _service;
        private readonly IMessageNotificationsHelper _messageNotificationsHelper;
        private IDepartmentModel _department;

        #endregion

        #region PROPERTIES

        public IDepartmentModel Department
        {
            get => this._department;
            set
            {
                this._department = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region COMMANDS

        public ICommand DeleteDepartmentCommand { get; private set; }

        public void PropagateDataContext()
        {
            this._view.SetDataContext(this);
        }

        #endregion

        #region C-TOR

        public DepartmentRowViewModel(IDependencyContainer dependencyContainer) : base(dependencyContainer)
        {
            this._view = dependencyContainer.Resolve<IDepartmentRowView>();
            this._service = dependencyContainer.Resolve<IDepartmentService<IDepartmentModel>>();
            this._messageNotificationsHelper = dependencyContainer.Resolve<IMessageNotificationsHelper>();

            this.RegisterCommands();
        }

        #endregion

        #region METHODS

        public IBaseView GetView() => this._view;

        #endregion

        #region HELPERS

        private void RegisterCommands()
        {
            this.DeleteDepartmentCommand =
                new DelegateCommand(ExecuteDeleteDepartmentCommand, CanExecuteDeleteDepartmentCommand);
        }

        private void ExecuteDeleteDepartmentCommand(object obj)
        {
            var id = (int)obj;
            this._service.Delete(id);

            this._messageNotificationsHelper.Publish(
                this,
                new ButtonIdEventArgs(id),
                (int)MessageType.DepartmentDeletedMessage);
        }

        private bool CanExecuteDeleteDepartmentCommand(object arg) => true;

        #endregion
    }
}
