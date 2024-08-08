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

# region 'Old'
/*
//using Kataandi.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SkiaSharp;
using System.Drawing;
using System.IO;
using System;
using ZXing.SkiaSharp;
namespace Kataandi.Controllers
{
    [Route("api/controller")]
    [ApiController]
    public class UploaderController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public UploaderController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        [HttpPost]
        [Route("upload-file")]
        public IActionResult UploadFile([FromForm] IFormFile file)
        {
            try
            {
                FileModel fileModel = new FileModel();
                fileModel.file = file;

                using (var imageStream = new MemoryStream())
                {
                    file.CopyTo(imageStream);
                    imageStream.Seek(0, SeekOrigin.Begin); // Reset the stream position
                    var image = SKBitmap.Decode(imageStream);
                    if (image == null)
                    {
                        return NotFound("Unable to decode image.");
                    }

                    BarcodeReader reader = new BarcodeReader();
                    var result = reader.Decode(image);

                    Response.Headers.Add("X-Example-Header", "value");

                    if (result != null)
                    {
                        // Get the decoded barcode text
                        var barcodeText = result.Text;
                        // Return the decoded barcode text as a JSON response
                        return Ok(new { barcodeText });
                    }
                    else
                    {
                        // Return a 404 response if the barcode could not be decoded
                        return NotFound("Barcode could not be decoded.");
                    }
                }
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
*/
#endregion

namespace SHUNetMVC.Web.Controllers
{
    public class UploaderController : Controller
    {
        private IEmployeeKendoService _employeeKendoService;
        private IUserService _userService;
        private ICrudEmployeeKendoService _crudEmployeeKendoService;

        public UploaderController(IEmployeeKendoService employeeKendoService, IUserService userService, ICrudEmployeeKendoService crudEmployeeKendoService)
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