using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Demo.Dependencies.Contracts;

namespace Demo.Bootstrapper.Asp
{
    public class CustomDependencyResolver : IDependencyResolver
    {
        private readonly IDependencyContainer _dependencyContainer;

        public CustomDependencyResolver(IDependencyContainer dependencyContainer)
        {
            this._dependencyContainer = dependencyContainer;
        }

        public object GetService(Type serviceType)
        {
            if (serviceType == null)
                return null;

            try
            {
                return this._dependencyContainer.Resolve(serviceType);
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return this._dependencyContainer.ResolveAll(serviceType);
        }
    }
}