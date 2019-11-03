using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MyMVCApplication
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
           name: "Default1",
           url: "MVC/Warriors",
           defaults: new { controller = "Default", action = "AboutUs", id = UrlParameter.Optional }
       );

            routes.MapRoute(
                name: "Hello",
                url: "default/hello/{EmpID}",
                defaults: new { controller = "Default", action = "Hello", EmpID = UrlParameter.Optional});

            routes.MapRoute(
              name: "Default",
              url: "{controller}/{action}/{id}",
              defaults: new { controller = "Default", action = "AboutUs", id = UrlParameter.Optional }
          );

        }
    }
}
