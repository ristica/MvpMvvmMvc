using Demo.Common.Contracts;
using Demo.Common.Shared;
using Demo.Dependencies.Contracts;
using Demo.Models.Contracts.CustomerDomain;
using Demo.Services.Contracts;
using Demo.WinForms.Presenters.Base;
using Demo.WinForms.Presenters.Contracts.UserControls;
using Demo.WinForms.Views.Contracts.Base;
using Demo.WinForms.Views.Contracts.UserControls;

namespace Demo.WinForms.Presenters.UserControls
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class CustomerRowViewPresenter : Presenter, ICustomerRowViewPresenter
    {
        #region FIELDS

        private readonly ICustomerRowUC _view;
        private readonly ICustomerService<ICustomerModel> _service;
        private readonly IMessageNotificationsHelper _messageNotificationsHelper;

        #endregion

        #region C-TOR

        public CustomerRowViewPresenter(IDependencyContainer dependencyContainer) : base(dependencyContainer)
        {
            this._view = dependencyContainer.Resolve<ICustomerRowUC>();
            this._service = dependencyContainer.Resolve<ICustomerService<ICustomerModel>>();
            this._messageNotificationsHelper = dependencyContainer.Resolve<IMessageNotificationsHelper>();

            this.SubscribeToUserInterfaceEvents();
        }

        #endregion

        #region METHODS

        public IBaseUserControl GetUserControl() => this._view;

        public void Dispose()
        {
            // ReSharper disable once EventUnsubscriptionViaAnonymousDelegate
            this._view.CustomerRowUserControlEditEventRaised -= (sender, args) => { };

            // ReSharper disable once EventUnsubscriptionViaAnonymousDelegate
            this._view.CustomerRowUserControlDeleteEventRaised -= (sender, args) => { };

            // ReSharper disable once EventUnsubscriptionViaAnonymousDelegate
            this._view.CustomerRowUserControlDisposeEventRaised -= (sender, args) => { };
        }

        #endregion

        #region HELPERS

        protected sealed override void SubscribeToUserInterfaceEvents()
        {
            this._view.CustomerRowUserControlEditEventRaised += (sender, args) =>
            {
                var customerId = ((ButtonIdEventArgs)args).ButtonId;
                var customerModel = this._service.Get(customerId);

                // presenter ...
                // set datacotext of the edit view ...

                this._messageNotificationsHelper.Publish(
                    this, 
                    new ButtonIdEventArgs(customerId), 
                    (int)MessageType.CustomerUpdatedMessage);
            };

            this._view.CustomerRowUserControlDeleteEventRaised += (sender, args) =>
            {
                var customerId = ((ButtonIdEventArgs)args).ButtonId;
                this._service.Delete(customerId);

                this._messageNotificationsHelper.Publish(
                    this, 
                    new ButtonIdEventArgs(customerId), 
                    (int)MessageType.CustomerDeletedMessage);
            };

            this._view.CustomerRowUserControlDisposeEventRaised += (sender, args) =>
            {
                this.Dispose();
            };
        }

        #endregion
    }
}
