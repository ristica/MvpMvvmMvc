using Demo.Dependencies.Contracts;
using Demo.Presenters.Base;
using Demo.Presenters.Contracts;
using Demo.Views.Contracts.Base;
using Demo.Views.Contracts.Views;

namespace Demo.Presenters
{
    public class ErrorMessageViewPresenter : Presenter, IErrorMessageViewPresenter
    {
        private readonly IFrmErrorMessage _view;

        public ErrorMessageViewPresenter(IDependencyContainer dependencyContainer) : base(dependencyContainer)
        {
            this._view = dependencyContainer.Resolve<IFrmErrorMessage>();
            this.SubscribeToUserInterfaceEvents();
        }

        public void ShowView(string windowTitle, string errorMessage)
        {
            this._view.WindowTitle = windowTitle;
            this._view.ErrorMessage = errorMessage;
            this._view.ShowMe();
        }

        public IBaseView GetView() => this._view;

        public void ShowView()
        {
            this._view.ShowMe();
        }

        protected override void SubscribeToUserInterfaceEvents()
        {
            
        }

        /// <summary>
        /// On Form Closing
        /// </summary>
        public void Dispose()
        {

        }
    }
}
