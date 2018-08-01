using System.Web.Mvc;
using System.Web.Routing;

namespace events.tac.local
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            RouteTable.Routes.MapRoute(
             Sitecore.Mvc.Configuration.MvcSettings.SitecoreRouteName,
             "{*pathInfo}",
             new { scIsFallThrough = true },
             new { isContent = new Sitecore.Mvc.Presentation.IsContentUrlRestraint() });
        }
    }
}
