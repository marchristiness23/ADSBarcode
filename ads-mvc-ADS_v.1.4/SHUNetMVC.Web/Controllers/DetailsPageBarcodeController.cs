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

namespace SHUNetMVC.Web.Controllers
{
    public class DetailPageBarcodeController : Controller
    {
        private IEmployeeKendoService _employeeKendoService;
        private IUserService _userService;
        private ICrudEmployeeKendoService _crudEmployeeKendoService;

        public DetailPageBarcodeController(IEmployeeKendoService employeeKendoService, IUserService userService, ICrudEmployeeKendoService crudEmployeeKendoService)
        {
            _employeeKendoService = employeeKendoService;
            _userService = userService;
            _crudEmployeeKendoService = crudEmployeeKendoService;
        }
        // GET: EmployeeKendo
        public async Task<ActionResult> Index()
        {
            return View();
        }
    }
}