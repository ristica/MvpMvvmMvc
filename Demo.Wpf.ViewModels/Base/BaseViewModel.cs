using Demo.Dependencies.Contracts;
using Demo.Wpf.Presentation.Shared;

namespace Demo.Wpf.ViewModels.Base
{
    public abstract class BaseViewModel : CommonBase
    {
        protected readonly IDependencyContainer DependencyContainer;

        protected BaseViewModel(IDependencyContainer dependencyContainer)
        {
            this.DependencyContainer = dependencyContainer;
        }
    }
}
