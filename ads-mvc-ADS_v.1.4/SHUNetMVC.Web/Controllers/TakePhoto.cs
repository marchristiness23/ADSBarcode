using iText.Kernel.Events;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using SHUNetMVC.Abstraction.Model.Dto;
using SHUNetMVC.Abstraction.Services;
using SHUNetMVC.Infrastructure.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

#region 'Old'
/*
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using SHUNetMVC.Abstraction.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Web.Mvc;
public class TakePhoto : Controller
{
    private readonly IWebHostEnvironment _webHostEnvironment;

    public TakePhoto(IWebHostEnvironment webHostEnvironment)
    {
        _webHostEnvironment = webHostEnvironment;
    }

    public ActionResult Index()
    {
        // Define the directory to store images
        string imageDirectory = Path.Combine(_webHostEnvironment.WebRootPath, "images");

        // Ensure the directory exists
        Directory.CreateDirectory(imageDirectory);

        // Get all image files from the directory
        string[] allImageFiles = Directory.GetFiles(imageDirectory, "*.txt");

        if (allImageFiles.Length > 0)
        {
            List<string> base64text = new List<string>();
            foreach (var item in allImageFiles)
            {
                base64text.Add(System.IO.File.ReadAllText(item));
            }
            ViewBag.Images = base64text;
        }

        return View();
    }

    [HttpPost]
    public void SaveImage(string base64image)
    {
        string imageDirectory = Path.Combine(_webHostEnvironment.WebRootPath, "images");

        Directory.CreateDirectory(imageDirectory);

        string fileName = DateTime.Now.ToString("yyyyMMdd_hhmmss") + ".txt";

        string filePath = Path.Combine(imageDirectory, fileName);

        System.IO.File.WriteAllText(filePath, base64image);
    }
}
*/
#endregion

namespace SHUNetMVC.Web.Controllers
{
    public class TakePhotoController : Controller
    {
        private IEmployeeKendoService _employeeKendoService;
        private IUserService _userService;
        private ICrudEmployeeKendoService _crudEmployeeKendoService;

        public TakePhotoController(IEmployeeKendoService employeeKendoService, IUserService userService, ICrudEmployeeKendoService crudEmployeeKendoService)
        {
            _employeeKendoService = employeeKendoService;
            _userService = userService;
            _crudEmployeeKendoService = crudEmployeeKendoService;
        }
        // GET: EmployeeKendo
        public async Task<ActionResult> Index()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                var currentUser = await _userService.GetCurrentUserInfo();
                if (currentUser.Roles == null)
                {
                    return View("NotAuthorized");
                }
                ViewBag.Roles = currentUser.Roles.FirstOrDefault().Value;
                return View();
            }
            return RedirectToAction("Index", "Home");
        }
    }
}