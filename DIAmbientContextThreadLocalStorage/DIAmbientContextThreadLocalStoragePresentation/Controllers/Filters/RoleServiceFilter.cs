using DIAmbientContextThreadLocalStorageInfrastructure.AmbientContextConfigurations;
using DIAmbientContextThreadLocalStorageInfrastructure.Interfaces;
using DIAmbientContextThreadLocalStoragePresentation.App_Start;
using System;
using System.Web.Mvc;

namespace DIAmbientContextThreadLocalStoragePresentation.Controllers.Filters
{
    public class RoleServiceFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (filterContext.HttpContext.Items["RoleServiceScope"] is IDisposable disposable)
                disposable.Dispose();
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var service = ServiceLocator.GetService<IRoleService>();
            filterContext.HttpContext.Items["RoleServiceScope"] = RoleServiceContext.BeginScope(service);
        }
    }
}