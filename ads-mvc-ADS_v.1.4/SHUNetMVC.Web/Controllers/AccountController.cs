using System.Net.Http;
using System.Web;
using System.Linq;
using System.Web.Mvc;
using System.Threading.Tasks;
using SHUNetMVC.Abstraction.Services;
using SHUNetMVC.Abstraction.Model.Response;
using System.Web.Security;
using System.Runtime.Caching;

namespace SHUNetMVC.Web.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly MemoryCache _cache;

        public AccountController(IUserService userService, MemoryCache cache)
        {
            _userService = userService;
            _cache = cache;
        }

        public ActionResult LogOff()
        {
            _cache.Remove(_userService.GetCurrentUserName());
            if (Request.IsAuthenticated)
            {
                FormsAuthentication.SignOut();
                var authTypes = HttpContext.GetOwinContext().Authentication.GetAuthenticationTypes();
                HttpContext.GetOwinContext().Authentication.SignOut(authTypes.Select(t => t.AuthenticationType).ToArray());
            }
            return Redirect("/");
        }

        public async Task<ActionResult> Index()
        {
            return View(await _userService.GetCurrentUserInfo());
        }

        [Authorize]
        public PartialViewResult UserHeader()
        {
            var task = Task.Run(async () => await _userService.GetCurrentUserInfo());
            User user = task.Result;
            return PartialView("Layout/_Header", user );
        }

        [Authorize]
        public PartialViewResult UserMenu()
        {
            var task = Task.Run(async () => await _userService.GetCurrentUserInfo());
            var user = task.Result;
            return PartialView("Layout/_SidebarUserMenu", user);
        } 
    }
}
