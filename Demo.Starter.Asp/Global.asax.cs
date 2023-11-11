using System.ComponentModel;
using System.Web.Mvc;
using System.Web.Routing;
using Demo.Bootstrapper.Asp;
using Demo.Dependencies.Builder;
using Unity;
using Unity.Mvc5;

namespace Demo.Starter.Asp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            UnityConfig.RegisterComponents();
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
