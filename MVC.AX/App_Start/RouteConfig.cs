using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVC.AX
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "GuessingGame",
                url: "GuessingGame/",
                defaults: new { controller = "Page", action = "GuessingGame" }
                );

            routes.MapRoute(
                name: "Fevercheck",
                url: "fevercheck/",
                defaults: new { controller = "Page", action = "Fevercheck" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Page", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
