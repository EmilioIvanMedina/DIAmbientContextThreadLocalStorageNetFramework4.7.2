using DIAmbientContextThreadLocalStorageInfrastructure.AmbientContextConfigurations;
using DIAmbientContextThreadLocalStoragePresentation.Struct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace DIAmbientContextThreadLocalStoragePresentation.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            var myService = RoleServiceContext.Current;

            var role = await myService.GetUserRole();

            if (role == null && !await myService.UserHasRole(Roles.Viewer))
                return View(@"..\Views\Shared\Error.cshtml");

            return View();
        }

        public async Task<ActionResult> About()
        {
            var myService = RoleServiceContext.Current;
            
            await myService.SetUserRole(Roles.Admin);

            if (!await myService.UserHasRole(Roles.Admin))
                return View("Error");

            ViewBag.Message = "Your application description page.";

            return View();
        }

        public async Task<ActionResult> Contact()
        {
            var myService = RoleServiceContext.Current;
            await myService.SetUserRole(Roles.Viewer);

            if (!await myService.UserHasRole(Roles.Manager))
                return View("Error");

            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}