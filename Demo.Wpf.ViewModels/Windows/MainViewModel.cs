using System;
using System.Windows;
using System.Windows.Input;
using Demo.Common.Contracts;
using Demo.Common.Shared;
using Demo.Dependencies.Contracts;
using Demo.Wpf.ViewModels.Base;
using Demo.Wpf.ViewModels.Commands;
using Demo.Wpf.ViewModels.Contracts.Base;
using Demo.Wpf.ViewModels.Contracts.UserControls;
using Demo.Wpf.ViewModels.Contracts.Windows;
using Demo.Wpf.Views.Contracts.Base;
using Demo.Wpf.Views.Contracts.Windows;

namespace Demo.Wpf.ViewModels.Windows
{
    public class MainViewModel : BaseViewModel, IMainViewModel, IReceiver<EventArgs>
    {
        #region FIELDS

        private readonly IMainWindow _window;
        private readonly IMessageNotificationsHelper _messageNotificationsHelper;

        #endregion

        #region COMMANDS

        public ICommand HelpCommand { get; private set; }
        public ICommand CloseCommand { get; private set; }
        public ICommand LoadCustomersCommand { get; private set; }
        public ICommand LoadDepartmentsCommand { get; private set; }

        #endregion

        #region C-TOR

        public MainViewModel(IDependencyContainer dependencyContainer) : base(dependencyContainer)
        {
            this._window = dependencyContainer.Resolve<IMainWindow>();
            this._messageNotificationsHelper = dependencyContainer.Resolve<IMessageNotificationsHelper>();

            this.SubscribeToNotifications();
            this.RegisterCommands();
            this._window.SetDataContext(this);
        }

        #endregion

        #region METHODS

        public IBaseWindow GetWindow() => this._window;

        public void Receive(object sender, EventArgs args, int messageId)
        {
            switch ((MessageType)messageId)
            {
                case MessageType.CustomerDeletedMessage:
                    this.LoadCustomersCommand.Execute(null);
                    break;
            }
        }

        public void Dispose()
        {
            this._messageNotificationsHelper.Unsubscribe(this, (int)MessageType.CustomerDeletedMessage);
        }

        #endregion

        #region HELPERS

        private void SubscribeToNotifications()
        {
            this._messageNotificationsHelper.Subscribe(this, (int)MessageType.CustomerDeletedMessage);
        }

        private void RegisterCommands()
        {
            this.HelpCommand = new DelegateCommand(ExecuteHelpCommand, CanExecuteHelpCommand);
            this.CloseCommand = new DelegateCommand(ExecuteCloseCommand, CanExecuteCloseCommand);
            this.LoadCustomersCommand = new DelegateCommand(ExecuteLoadCustomersCommand, CanExecuteLoadCustomersCommand);
            this.LoadDepartmentsCommand = new DelegateCommand(ExecuteLoadDepartmentsCommand, CanExecuteLoadDepartmentsCommand);
        }

        private bool CanExecuteLoadDepartmentsCommand(object arg) => true;
        private bool CanExecuteLoadCustomersCommand(object arg) => true;
        private bool CanExecuteHelpCommand(object arg) => true;
        private bool CanExecuteCloseCommand(object arg) => true;

        private void ExecuteHelpCommand(object obj)
        {
            DependencyContainer.Resolve<IHelpViewModel>().GetWindow().ShowModalMe();
        }

        private void ExecuteCloseCommand(object obj)
        {
            this._window.CloseMe();
        }

        private void ExecuteLoadCustomersCommand(object obj)
        {
            this.LoadCurrentData(DependencyContainer.Resolve<ICustomerViewModel>());
        }

        private void ExecuteLoadDepartmentsCommand(object obj)
        {
            this.LoadCurrentData(DependencyContainer.Resolve<IDepartmentViewModel>());
        }

        private void LoadCurrentData(IBaseViewModelForView vm)
        {
            this._window.GetContentPanel().Child = vm.GetView() as UIElement;
        }

        #endregion
    }
}
