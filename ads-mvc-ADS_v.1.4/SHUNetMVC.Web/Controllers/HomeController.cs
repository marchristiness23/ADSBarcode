using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OpenIdConnect;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using SHUNetMVC.Abstraction.Services;
using System.Web.Security;
using System.Security.Principal;
using System.Web.Configuration;
using AppLog_Component;
using SHUNetMVC.Abstraction.Model.Response;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;
using System.Net.PeerToPeer;
using System.Security.Claims;
using Microsoft.Owin;
using DocumentFormat.OpenXml.Wordprocessing;
using SHUNetMVC.Infrastructure.Constant;
using SHUNetMVC.Abstraction.Model.Entities;
using System.Data.Entity;

namespace SHUNetMVC.Web.Controllers
{

    public class HomeController : Controller
    {
        private readonly IUserService _userService;
        private DbContextMapper _context = new DbContextMapper();

        public HomeController(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<ActionResult> Index()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                ViewBag.Title = "Home Page";
                var currentUser = await _userService.GetCurrentUserInfo();
                var asd = await _context.MD_Aset.AsNoTracking().FirstOrDefaultAsync();
                if (currentUser.Roles == null)
                {
                    return View("NotAuthorized");
                }
                //Harus di sematkan di HOME

                var name = currentUser.EmpAccount;
                AppLogger _appLog = new AppLogger();
                _appLog.Applog_Insert("Home", name, AimanConstant.AppLogCode, "Description", "Success",
                    AimanConstant.AppLogLink, AimanConstant.AppLogKey);


                return View("Index", currentUser);
            }

            //if (IsSSOEnabled())
            //{
            //    return RedirectToAction("LoginSSO");
            //}

            return View("LoginForm");
        }

        private bool IsSSOEnabled()
        {
            AuthenticationSection authenticationSection = (AuthenticationSection)ConfigurationManager.GetSection("system.web/authentication");
            return authenticationSection.Mode == System.Web.Configuration.AuthenticationMode.None;
        }

        [Authorize]
        public ActionResult LoginSSO()
        {
            ViewBag.Title = "Home Page";
            return View("Index");
        }

        [HttpGet]
        public bool LoginForm(string userName)
        {
            if (IsSSOEnabled())
                return false;

            var user = _userService.GetUserInfo(userName);
            if (user == null)
                return false;


            HttpContext.User = new GenericPrincipal(new GenericIdentity(userName), new string[] { "user" });
            FormsAuthentication.SetAuthCookie(userName, true);
            return true;
        }

        [HttpPost]
        public async Task<ActionResult> LoginFormImpersonate(string account)
        {

            string userName = account;
            var user = await _userService.GetUserInfo(userName);
            //if (user == null)
            //    return false;

            var claims = new[]
                 {
                    new Claim(ClaimTypes.Name, userName)
                };

            var identity = new ClaimsIdentity(claims, "ApplicationCookie");

            // Sign in the user by setting the authentication cookie
            var authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignIn(identity);

            // Redirect to the desired page after login (e.g., homepage)
            return RedirectToAction("Index", "Home");

        }

        public async Task<ActionResult> RunAs()
        {
            return View(await _userService.GetCurrentUserInfo());
        }
    }
}

#region'Old'
/*
using ASPNetMVC.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;
using Microsoft.Extensions.Logging;
using SHUNetMVC.Web.Models;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Web.Mvc;
using System;

namespace ASPNetMVC.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IWebHostEnvironment _webHostEnvironment;

        private readonly ApplicationDbContext _applicationDbContext;

        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment webHostEnvironment, ApplicationDbContext applicationDbContext)
        {
            _logger = logger;
            _webHostEnvironment = webHostEnvironment;
            _applicationDbContext = applicationDbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Route("test")]
        public IActionResult Test()
        {
            var image = new SKBitmap();
            BarcodeReader reader = new BarcodeReader();
            var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "images.png");
            using (var stream = new FileStream(filePath, FileMode.Open))
            {
                image = SKBitmap.Decode(stream);
            }

            var result = reader.Decode(image);

            if (result != null)
            {
                // Get the decoded barcode text
                var barcodeText = result.Text;
                // Return the decoded barcode text as a JSON response
                return Json(new { barcodeText });
            }
            else
            {
                // Return a 404 response if the barcode could not be decoded
                return NotFound();
            }
        }

        [HttpGet]
        public IActionResult Index1()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(double latitude, double longitude)
        {
            // Handle the received latitude and longitude
            // For demonstration, just passing them back to the view
            ViewBag.Latitude = latitude;
            ViewBag.Longitude = longitude;
            return View();
        }

        public async Task<IActionResult> TestDbConnection()
        {
            try
            {
                // Attempt a simple query to test the connection
                var canConnect = await _applicationDbContext.Database.CanConnectAsync();
                if (canConnect)
                {
                    return Content("Database connection successful.");
                }
                else
                {
                    return Content("Database connection failed.");
                }
            }
            catch (Exception ex)
            {
                return Content($"An error occurred: {ex.Message}");
            }
        }
    }
}
*/
#endregion