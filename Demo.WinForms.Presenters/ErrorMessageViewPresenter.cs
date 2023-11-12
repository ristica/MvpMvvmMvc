using Demo.Dependencies.Contracts;
using Demo.WinForms.Presenters.Base;
using Demo.WinForms.Presenters.Contracts;
using Demo.WinForms.Views.Contracts.Base;
using Demo.WinForms.Views.Contracts.Views;

namespace Demo.WinForms.Presenters
{
    public abstract class ErrorMessageViewPresenter : Presenter, IErrorMessageViewPresenter
    {
        private readonly IFrmErrorMessage _view;

        protected ErrorMessageViewPresenter(IDependencyContainer dependencyContainer) : base(dependencyContainer)
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

        protected sealed override void SubscribeToUserInterfaceEvents()
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
