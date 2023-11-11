using Demo.Dependencies.Contracts;

namespace Demo.Asp.Presenter.Base
{
    public abstract class BasePresenter
    {
        protected readonly IDependencyContainer DependencyContainer;

        protected BasePresenter(IDependencyContainer dependencyContainer)
        {
            this.DependencyContainer = dependencyContainer;
        }
    }
}
