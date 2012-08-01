using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Mvc4.Framework;

namespace Mvc4
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            DependencyResolver.SetResolver(new IoCDependencyResolver());
            GlobalConfiguration.Configuration.DependencyResolver = DependencyResolver.Current.ToServiceResolver();
            GlobalConfiguration.Dispatcher.Configuration.DependencyResolver = DependencyResolver.Current.ToServiceResolver();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}