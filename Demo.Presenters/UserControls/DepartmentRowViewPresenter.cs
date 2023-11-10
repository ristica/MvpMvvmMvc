using Demo.Dependencies.Contracts;
using Demo.Presenters.Base;
using Demo.Presenters.Contracts.UserControls;
using Demo.Views.Contracts.Base;
using Demo.Views.Contracts.UserControls;

namespace Demo.Presenters.UserControls
{
    public class DepartmentRowViewPresenter : Presenter, IDepartmentRowViewPresenter
    {
        private readonly IDepartmentRowUC _view;

        public DepartmentRowViewPresenter(IDependencyContainer dependencyContainer) : base(dependencyContainer)
        {
            this._view = dependencyContainer.Resolve<IDepartmentRowUC>();

            this.SubscribeToUserInterfaceEvents();
        }

        protected sealed override void SubscribeToUserInterfaceEvents()
        {
            this._view.DepartmentRowUserControlEditEventRaised += (sender, args) =>
            {

            };

            this._view.DepartmentRowUserControlDeleteEventRaised += (sender, args) =>
            {

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
