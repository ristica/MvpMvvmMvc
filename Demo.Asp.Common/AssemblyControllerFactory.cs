using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Routing;

namespace Demo.Asp.Common
{
    public class AssemblyControllerFactory : DefaultControllerFactory
    {
        private readonly IDictionary<string, Type> _controllerTypes;

        public AssemblyControllerFactory(Assembly assembly)
        {
            this._controllerTypes = assembly.GetExportedTypes()
                                            .Where(x => typeof(IController).IsAssignableFrom(x) && (x.IsInterface == false && x.IsAbstract == false))
                                            .ToDictionary(x => x.Name, x => x);
        }

        public override IController CreateController(RequestContext requestContext, string controllerName)
        {
            var controller = base.CreateController(requestContext, controllerName);

            if (controller != null) return controller;
            var controllerType = this._controllerTypes
                .Where(x => x.Key == $"{controllerName}Controller")
                .Select(x => x.Value)
                .SingleOrDefault();

            var controllerActivator = DependencyResolver.Current.GetService(typeof(IControllerActivator)) as IControllerActivator;

            if (controllerType == null) return controller;

            controller = controllerActivator != null
                ? controllerActivator.Create(requestContext, controllerType)
                : Activator.CreateInstance(controllerType) as IController;

            return controller;
        }
    }
}
