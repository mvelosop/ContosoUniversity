using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using ContosoUniversity.DAL;
using System.Data.Entity.Infrastructure.Interception;
using System.IO;
using ContosoUniversity.App_Start;
using Serilog;

namespace ContosoUniversity
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            LoggingConfig.RegisterLogger();

            var logger = LoggingConfig.GetLoggerForContext(typeof(MvcApplication));

            logger.Information("Registering areas");
            AreaRegistration.RegisterAllAreas();

            logger.Information("Registering Filters");
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);

            logger.Information("Registering routes");
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            logger.Information("Registering Bundles");
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            logger.Information("Registering DbInterceptors");
            DbInterception.Add(new SchoolInterceptorTransientErrors());
            DbInterception.Add(new SchoolInterceptorLogging());

        }
    }
}
