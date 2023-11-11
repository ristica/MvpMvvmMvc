using System.Web.Mvc;
using Demo.Dependencies.Contracts;

namespace Demo.Asp.UI.Base
{
    public abstract class BaseController : Controller
    {
        protected readonly IDependencyContainer DependencyContainer;

        protected BaseController(IDependencyContainer dependencyContainer)
        {
            this.DependencyContainer = dependencyContainer;
        }
    }
}