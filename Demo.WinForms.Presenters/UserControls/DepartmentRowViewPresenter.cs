using Demo.Common.Contracts;
using Demo.Common.Shared;
using Demo.Dependencies.Contracts;
using Demo.Models.Contracts.DepartmentDomain;
using Demo.Services.Contracts;
using Demo.WinForms.Presenters.Base;
using Demo.WinForms.Presenters.Contracts.UserControls;
using Demo.WinForms.Views.Contracts.Base;
using Demo.WinForms.Views.Contracts.UserControls;

namespace Demo.WinForms.Presenters.UserControls
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class DepartmentRowViewPresenter : Presenter, IDepartmentRowViewPresenter
    {
        private readonly IDepartmentRowUC _view;
        private readonly IDepartmentService<IDepartmentModel> _service;
        private readonly IMessageNotificationsHelper _messageNotificationsHelper;

        public DepartmentRowViewPresenter(IDependencyContainer dependencyContainer) : base(dependencyContainer)
        {
            this._view = dependencyContainer.Resolve<IDepartmentRowUC>();
            this._service = dependencyContainer.Resolve<IDepartmentService<IDepartmentModel>>();
            this._messageNotificationsHelper = dependencyContainer.Resolve<IMessageNotificationsHelper>();

            this.SubscribeToUserInterfaceEvents();
        }

        protected sealed override void SubscribeToUserInterfaceEvents()
        {
            this._view.DepartmentRowUserControlEditEventRaised += (sender, args) =>
            {

            };

            this._view.DepartmentRowUserControlDeleteEventRaised += (sender, args) =>
            {
                var customerId = ((ButtonIdEventArgs)args).ButtonId;
                this._service.Delete(customerId);

                this._messageNotificationsHelper.Publish(
                    this,
                    new ButtonIdEventArgs(customerId),
                    (int)MessageType.DepartmentDeletedMessage);
            };

            this._view.DepartmentRowUserControlDisposeEventRaised += (sender, args) =>
            {
                this.Dispose();
            };
        }

        public IBaseUserControl GetUserControl() => this._view;

        public void Dispose()
        {
            // ReSharper disable once EventUnsubscriptionViaAnonymousDelegate
            this._view.DepartmentRowUserControlEditEventRaised -= (sender, args) => { };

            // ReSharper disable once EventUnsubscriptionViaAnonymousDelegate
            this._view.DepartmentRowUserControlDeleteEventRaised -= (sender, args) => { };

            // ReSharper disable once EventUnsubscriptionViaAnonymousDelegate
            this._view.DepartmentRowUserControlDisposeEventRaised -= (sender, args) => { };
        }
    }
}
