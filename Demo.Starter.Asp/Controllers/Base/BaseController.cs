using Demo.Dependencies.Contracts;
using System.Web.Mvc;

namespace Demo.Starter.Asp.Controllers.Base
{
    public abstract class BaseController : Controller
    {
        private readonly IDependencyContainer DependencyContainer;

        protected BaseController(IDependencyContainer dependencyContainer)
        {
            this.DependencyContainer = dependencyContainer;
        }
    }
}