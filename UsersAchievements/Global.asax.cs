using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace UsersAchievements
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AddBundles();
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        private void AddBundles()
        {
            var styleBundle = new StyleBundle("~/Content/css");
            styleBundle.Include("~/Content/bootstrap.css");
            styleBundle.Include("~/Content/Site.css");

            var scriptBundle = new ScriptBundle("~/Scripts/js");
            scriptBundle.Include("~/Scripts/jquery-{version}.js");
            scriptBundle.Include("~/Scripts/jquery.validate.js");
            scriptBundle.Include("~/Scripts/jquery.validate.unobtrusive.js");
            scriptBundle.Include("~/Scripts/bootstrap.js");

            BundleTable.Bundles.Add(styleBundle);
            BundleTable.Bundles.Add(scriptBundle);

            BundleTable.EnableOptimizations = false;
        }
    }
}
