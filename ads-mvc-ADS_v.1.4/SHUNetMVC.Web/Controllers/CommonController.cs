using SHUNetMVC.Abstraction.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SHUNetMVC.Web.Controllers
{
    public class CommonController : Controller
    {
        private ICommonService _commonService;
        public CommonController(ICommonService commonService)
        {
            _commonService = commonService;
        }
        // GET: Common
        public ActionResult Index()
        {
            return View();
        }
        public async Task<JsonResult> GetDepartment()
        {
            var data = await _commonService.GetDepartement();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}