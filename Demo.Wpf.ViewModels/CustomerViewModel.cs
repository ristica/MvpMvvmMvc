using Demo.Dependencies.Contracts;
using Demo.Wpf.ViewModels.Base;
using Demo.Wpf.ViewModels.Contracts;
using Demo.Wpf.Views.Contracts;
using Demo.Wpf.Views.Contracts.Base;

namespace Demo.Wpf.ViewModels
{
    public class CustomerViewModel : BaseViewModel, ICustomerViewModel
    {
        private readonly ICustomerView _view;

        public CustomerViewModel(IDependencyContainer dependencyContainer) : base(dependencyContainer)
        {
            this._view = dependencyContainer.Resolve<ICustomerView>();

            this.SetDataContext();
        }

        public IBaseView GetView() => this._view;

        protected sealed override void SetDataContext()
        {
            
        }
    }
}
