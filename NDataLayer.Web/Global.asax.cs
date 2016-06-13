using LightInject;
using NDataLayer.DigitalData;
using NDataLayer.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace NDataLayer.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var container = new ServiceContainer();

            container.EnablePerWebRequestScope();

            container.RegisterControllers();
            container.Register<DataLayer>(new PerScopeLifetime());
            container.Register<ITestService, TestService>();

            container.EnableMvc();
        }

        protected void Application_BeginRequest()
        {
            Context.Items.Add("dataLayer", new DataLayer());
        }
    }
}
