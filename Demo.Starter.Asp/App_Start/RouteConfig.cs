using System.Web.Mvc;
using System.Web.Routing;
using Demo.Asp.Common;
using Demo.Asp.UI;

namespace Demo.Starter.Asp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Customer", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoutes(typeof(CustomerController).Assembly);
            routes.MapRoutes(typeof(DepartmentController).Assembly);
        }
    }
}
