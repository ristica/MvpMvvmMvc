using System;
using System.Windows.Forms;
using Demo.Common.Contracts;
using Demo.Common.Shared;
using Demo.Dependencies.Contracts;
using Demo.Presenters.Base;
using Demo.Presenters.Contracts;
using Demo.Presenters.Contracts.Base;
using Demo.Presenters.Contracts.UserControls;
using Demo.Views.Contracts.Base;
using Demo.Views.Contracts.Views;

namespace Demo.Presenters
{
    public class MainViewPresenter : Presenter, IMainViewPresenter, IReceiver<EventArgs>
    {
        #region FIELDS

        private readonly IFrmMain _view;
        private IBaseUserControlPresenter _currentUserControlPresenter;
        private readonly IMessageNotificationsHelper _messageNotificationsHelper;

        #endregion

        #region C-TOR

        public MainViewPresenter(IDependencyContainer dependencyContainer) : base(dependencyContainer)
        {
            this._messageNotificationsHelper = dependencyContainer.Resolve<IMessageNotificationsHelper>();
            this._view = dependencyContainer.Resolve<IFrmMain>();

            this.SubscribeToNotifications();
            this.SubscribeToUserInterfaceEvents();
        }

        #endregion

        #region METHODS

        public IBaseView GetView() => this._view;

        public void ShowView()
        {
           // intentionally left blank ...
        }

        public void Receive(object sender, EventArgs args, int messageId)
        {
            if ((MessageType)messageId == MessageType.ResizeMainWindowMessage)
            {
                this._view.ResizeMe(args);
            }
        }

        public void Dispose()
        {
            // ReSharper disable once EventUnsubscriptionViaAnonymousDelegate
            this._view.FormLoadEventRaised -= (sender, args) => { };
            // ReSharper disable once EventUnsubscriptionViaAnonymousDelegate
            this._view.CustomersViewShowEventRaised -= (sender, args) => { };
            // ReSharper disable once EventUnsubscriptionViaAnonymousDelegate
            this._view.HelpViewShowEventRaised -= (sender, args) => { };
            // ReSharper disable once EventUnsubscriptionViaAnonymousDelegate
            this._view.DepartmentsViewShowEventRaised -= (sender, args) => { };
            // ReSharper disable once EventUnsubscriptionViaAnonymousDelegate
            this._view.FormCloseEventRaised -= (sender, args) => { };

            this._view.GetContentPanel().Controls.Clear();
            this._currentUserControlPresenter?.Dispose();

            this._messageNotificationsHelper.Unsubscribe(this, (int)MessageType.ResizeMainWindowMessage);
            this._messageNotificationsHelper.Dispose();
        }

        #endregion

        #region HELPERS

        protected sealed override void SubscribeToUserInterfaceEvents()
        {
            this._view.FormLoadEventRaised += (sender, args) =>
            {
                this._view.GetContentPanel().Controls.Clear();
                this._currentUserControlPresenter?.Dispose();

                this._currentUserControlPresenter = DependencyContainer.Resolve<ICustomerViewPresenter>();
                this._view.GetContentPanel().Controls.Add(this._currentUserControlPresenter.GetUserControl() as UserControl);
            };

            this._view.CustomersViewShowEventRaised += (sender, args) =>
            {
                this._view.GetContentPanel().Controls.Clear();
                this._currentUserControlPresenter?.Dispose();

                this._currentUserControlPresenter = DependencyContainer.Resolve<ICustomerViewPresenter>();
                this._view.GetContentPanel().Controls.Add(this._currentUserControlPresenter.GetUserControl() as UserControl);
            };

            this._view.HelpViewShowEventRaised += (sender, args) =>
            {
                DependencyContainer.Resolve<IHelpViewPresenter>().ShowView();
            };

            this._view.DepartmentsViewShowEventRaised += (sender, args) =>
            {
                this._view.GetContentPanel().Controls.Clear();
                this._currentUserControlPresenter?.Dispose();

                this._currentUserControlPresenter = DependencyContainer.Resolve<IDepartmentViewPresenter>();
                this._view.GetContentPanel().Controls.Add(this._currentUserControlPresenter.GetUserControl() as UserControl);
            };

            this._view.FormCloseEventRaised += (sender, args) =>
            {
                this.Dispose();
            };
        }

        private void SubscribeToNotifications()
        {
            this._messageNotificationsHelper.Subscribe(this, (int)MessageType.ResizeMainWindowMessage);
        }

        #endregion
    }
}
