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
    public class EmployeeKendoController : Controller
    {
        private IEmployeeKendoService _employeeKendoService;
        private IUserService _userService;
        private ICrudEmployeeKendoService _crudEmployeeKendoService;

        public EmployeeKendoController(IEmployeeKendoService employeeKendoService, IUserService userService, ICrudEmployeeKendoService crudEmployeeKendoService)
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
        public async Task<ActionResult> ViewForm(int EmpId)
        {
            var data = await _employeeKendoService.GetById(EmpId);
            ViewBag.Mode = "View";
            return View("~/Views/EmployeeKendo/FormEmployeeKendo.cshtml",data);
        }
        public ActionResult CreateForm()
        {
            ViewBag.Mode = "create";
            return View("~/Views/EmployeeKendo/FormEmployeeKendo.cshtml");
        }
        public async Task<ActionResult> EditForm(int EmpId)
        {
            var data = await _employeeKendoService.GetById(EmpId);
            return View("~/Views/EmployeeKendo/FormEmployeeKendo.cshtml", data);
        }
        public async Task<JsonResult> GetAllEmployeeKendo([DataSourceRequest] DataSourceRequest request)
        {
            DataSourceResult result = new DataSourceResult();
            var EmpList = new List<EmployeeDto>();

            int total = await _employeeKendoService.GetTotalCount();

            if (request.Filters.Count > 0 || request.Sorts.Count > 0)
            {
                EmpList = await _employeeKendoService.GetAll(1, total);

                result = EmpList.ToDataSourceResult(request);
            }
            else
            {
                EmpList = await _employeeKendoService.GetAll(request.Page, request.PageSize);

                result.Data = EmpList;
                result.Total = total;
            }

            return Json(result, JsonRequestBehavior.AllowGet);

            //var data = await _employeeKendoService.GetAll(request.Page, request.PageSize);
            //return Json(data.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
        public async Task<ActionResult> ViewData(int EmpId)
        {
            var data = await _employeeKendoService.GetById(EmpId);
            return View(data);
        }

        [HttpPost]
        public async Task<ActionResult> Create([DataSourceRequest] DataSourceRequest request, EmployeeDto model)
        {
            try
            {
                //await _employeeKendoService.Save(model);
                await _crudEmployeeKendoService.Create(model);
                var response = new
                {
                    Success = true

                };

                return Json(response);
            }
            catch (Exception ex)
            {
                var response = new
                {
                    Success = false
                };

                return Json(response);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Update([DataSourceRequest] DataSourceRequest request, EmployeeDto model)
        {
            try
            {
                await _crudEmployeeKendoService.Update(model);
                var response = new
                {
                    Success = true
                };

                return Json(response);
            }
            catch (Exception ex)
            {
                var response = new
                {
                    Success = false
                };

                return Json(response);
            }
        }

        public async Task<ActionResult> ExportPdf(int EmpId)
        {
            var data = await _employeeKendoService.GetById(EmpId);
            using (MemoryStream workStream = new MemoryStream())
            {
                PdfWriter writer = new PdfWriter(workStream);
                PdfDocument pdfDoc = new PdfDocument(writer);
                pdfDoc.SetDefaultPageSize(PageSize.A4);
                Document document = new Document(pdfDoc);
                float[] columnWidths = { 1f, 2f }; // 2 columns with widths in proportion
                Table table = new Table(UnitValue.CreatePercentArray(columnWidths));
                string imagePath = Server.MapPath("~/Assets/PHE_Logo_Color.png");
                document.SetMargins(80, 50, 50, 50);
                // Add the header event handler
                HeaderEventHandler headerHandler = new HeaderEventHandler("", imagePath);
                pdfDoc.AddEventHandler(PdfDocumentEvent.START_PAGE, headerHandler);
                pdfDoc.AddEventHandler(PdfDocumentEvent.END_PAGE, new FooterEventHandler());

                // Create PDF content
                document.Add(new Paragraph($"Employee Name : {data.EmpName}"));


                // Add the table to the document
                document.Add(table);
                document.Close();
                pdfDoc.Close();

                byte[] byteInfo = workStream.ToArray();
                return File(byteInfo, "application/pdf", "ExportedPdf.pdf");
            }
        }


        [HttpPost]
        public async Task<ActionResult> DeleteEmployeeKendo([DataSourceRequest] DataSourceRequest request, EmployeeDto employee)
        {
            if (employee != null && ModelState.IsValid)
            {
                await _employeeKendoService.DeleteEmployee(employee.EmpId);
            }
            return Json(new[] { employee }.ToDataSourceResult(request, ModelState));
        }
    }
}