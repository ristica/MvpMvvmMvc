using System;
using System.Collections.Generic;
using Demo.Common.Contracts;
using Demo.Common.Shared;
using Demo.Dependencies.Contracts;
using Demo.Models.Contracts.CustomerDomain;
using Demo.Services.Contracts;
using Demo.WinForms.Presenters.Base;
using Demo.WinForms.Presenters.Contracts;
using Demo.WinForms.Presenters.Contracts.UserControls;
using Demo.WinForms.Views.Contracts.Base;
using Demo.WinForms.Views.Contracts.UserControls;

namespace Demo.WinForms.Presenters.UserControls
{
    public class CustomerViewPresenter : Presenter, ICustomerViewPresenter, IReceiver<EventArgs>
    {
        #region FIELDS

        private readonly ICustomerUC _uc;
        private readonly ICustomerService<ICustomerModel> _service;
        private readonly IMessageNotificationsHelper _messageNotificationsHelper;

        #endregion

        #region C-TOR

        public CustomerViewPresenter(IDependencyContainer dependencyContainer) : base(dependencyContainer)
        {
            this._messageNotificationsHelper = dependencyContainer.Resolve<IMessageNotificationsHelper>();
            this._uc = dependencyContainer.Resolve<ICustomerUC>();
            this._service = dependencyContainer.Resolve<ICustomerService<ICustomerModel>>();

            this.SubscribeToUserInterfaceEvents();
            this.SubscribeToNotifications();
            this.LoadAllCustomers();
        }

        #endregion

        #region METHODS

        public IBaseUserControl GetUserControl() => this._uc;

        public void Receive(object sender, EventArgs args, int messageId)
        {
            switch ((MessageType)messageId)
            {
                case MessageType.CustomerDeletedMessage:
                    this._uc.DataContext.Clear();
                    this._uc.UpdateMe();
                    this.LoadAllCustomers();
                    this._uc.UpdateMe();
                    break;
                case MessageType.CustomerUpdatedMessage:
                    this._uc.DataContext.Clear();
                    this.LoadAllCustomers();
                    break;
            }
        }

        public void Dispose()
        {
            // ReSharper disable once EventUnsubscriptionViaAnonymousDelegate
            this._uc.CustomerUserControlNewAddedEventRaised -= (sender, args) => { };
            // ReSharper disable once EventUnsubscriptionViaAnonymousDelegate
            this._uc.UserControlReachedCriticalHeight -= (sender, args) => { };

            foreach (var rowUc in this._uc.DataContext)
            {
                rowUc.DisposeMe();
            }
        }

        #endregion

        #region HELPERS

        protected sealed override void SubscribeToUserInterfaceEvents()
        {
            this._uc.CustomerUserControlNewAddedEventRaised += (sender, args) =>
            {
                
            };

            this._uc.UserControlReachedCriticalHeight += (sender, args) =>
            {
                this._messageNotificationsHelper.Publish<EventArgs>(
                    this, 
                    args, 
                    (int)MessageType.ResizeMainWindowMessage);
            };
        }

        private void SubscribeToNotifications()
        {
            this._messageNotificationsHelper.Subscribe(this, (int)MessageType.CustomerUpdatedMessage);
            this._messageNotificationsHelper.Subscribe(this, (int)MessageType.CustomerDeletedMessage);
        }

        private void LoadAllCustomers()
        {
            var customers = this._service.GetAll();
            var rows = new List<ICustomerRowUC>();

            foreach (var c in customers)
            {
                var rowPresenter = DependencyContainer.Resolve<ICustomerRowViewPresenter>();

                if (rowPresenter.GetUserControl() is ICustomerRowUC customerRow) customerRow.DataContext = c;
                else continue;

                rows.Add(customerRow);
            }

            this._uc.DataContext = rows;
        }

        #endregion
    }
}
