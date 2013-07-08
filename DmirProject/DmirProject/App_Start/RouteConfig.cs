using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DmirProject
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "FindUsers",
                url: "Search/{action}/{n}",
                defaults: new {controller = "Search", action = "FindUsers", n = UrlParameter.Optional }
                );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{n}",
                defaults: new { controller = "Home", action = "Index", n = UrlParameter.Optional }
            );
        }
    }
}