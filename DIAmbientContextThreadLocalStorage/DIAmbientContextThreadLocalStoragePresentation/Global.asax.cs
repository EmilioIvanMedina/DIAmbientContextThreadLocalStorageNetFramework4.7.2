using DIAmbientContextThreadLocalStorageInfrastructure.AmbientContextConfigurations;
using DIAmbientContextThreadLocalStorageInfrastructure.Implementations;
using DIAmbientContextThreadLocalStorageInfrastructure.Interfaces;
using DIAmbientContextThreadLocalStoragePresentation.App_Start;
using DIAmbientContextThreadLocalStoragePresentation.Controllers;
using DIAmbientContextThreadLocalStoragePresentation.Controllers.Filters;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace DIAmbientContextThreadLocalStoragePresentation
{
    public class MvcApplication : System.Web.HttpApplication
    {

        public static IServiceProvider ServiceProvider { get; private set; }
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var services = new ServiceCollection();

            ConfigureServices(services);

            ServiceProvider = services.BuildServiceProvider();

            DependencyResolver.SetResolver(new ServiceProviderDependencyResolver(ServiceProvider));
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IRoleService, RoleService>();

            // register the Action Filer in GlobalFilers
            GlobalFilters.Filters.Add(new RoleServiceFilter());

            // register the controller
            services.AddTransient<HomeController>();
        }
    }
}
