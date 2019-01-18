using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Game
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
               name: "AboutPage",
               url: "About",
               defaults: new { controller = "Home", action = "About" }
           );

            routes.MapRoute(
               name: "HomePage",
               url: "Home",
               defaults: new { controller = "Home", action = "Index" }
            );

            routes.MapRoute(
               name: "ContactPage",
               url: "Contact",
               defaults: new { controller = "Home", action = "Contact" }
            );

            routes.MapRoute(
               name: "KingdomPage",
               url: "ViewAllKingdoms",
               defaults: new { controller = "Kingdoms", action = "Index" }
            );

            

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

        }
    }
}
