using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Winery
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "ProductByStyle",
                url: "Product/style/{style}",
                defaults: new { controller = "Product", action = "Index", style = 0 }
            );
            routes.MapRoute(
                name: "ProductByName",
                url: "Product/{product_name}",
                defaults: new { controller = "Product", action = "Details" }
            );
        }
    }
}
