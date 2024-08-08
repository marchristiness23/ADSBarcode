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

#region'Old'
/*
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
//using Kataandi.Models;
//using Kataandi.Models.dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SHUNetMVC.Web.Models;
//using ZXing.QrCode.Internal;
namespace Kataandi.Controllers
{
    public class BarcodeScannerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BarcodeScannerController(ApplicationDbContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            var scannedData = _context.MD_Aset.FromSqlRaw("SELECT * FROM master.dbo.[MD_Aset];").ToList();
            return View(scannedData);
        }

        [HttpPost]
        public ActionResult Scan(BarcodeChangeRequest request)
        {
            try
            {
                if (!string.IsNullOrEmpty(request.Aset_No))
                {
                    var dataFilter = _context.MD_Aset.FromSqlRaw($"SELECT * FROM master.dbo.[MD_Aset] WHERE AsetNo = {request.Aset_No};");
                    return Json(dataFilter);
                }
                return Json("ini pasti null" + request.Aset_No);
            }
            catch (Exception e)
            {
                return Json(e.Message);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
*/
#endregion

namespace SHUNetMVC.Web.Controllers
{
    public class BarcodeScannerController : Controller
    {
        private IEmployeeKendoService _employeeKendoService;
        private IUserService _userService;
        private ICrudEmployeeKendoService _crudEmployeeKendoService;

        public BarcodeScannerController(IEmployeeKendoService employeeKendoService, IUserService userService, ICrudEmployeeKendoService crudEmployeeKendoService)
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