using Demo.Dependencies.Contracts;

namespace Demo.Presenters.Base
{
    public abstract class Presenter
    {
        protected readonly IDependencyContainer DependencyContainer;

        protected Presenter(IDependencyContainer dependencyContainer)
        {
           this.DependencyContainer = dependencyContainer;
        }

        protected abstract void SubscribeToUserInterfaceEvents();
    }
}
