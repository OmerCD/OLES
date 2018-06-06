using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using OLES.Classes.Database;
using OLESClass;

namespace OLES
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            DbFactory.SetConnection("127.0.0.1");
         
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
