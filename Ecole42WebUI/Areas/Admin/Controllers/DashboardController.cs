using Ecole42WebUI.Areas.Admin.SessionCheck;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Ecole42WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        [Route("admin/dashboard")]
        [SessionAuthorize]
        public IActionResult Index()
        {
            return View();
        }

        [Route("admin/get-intra-id")]
        [HttpGet]
        public string getIntraId()
        {
            return HttpContext.Session.GetString("intraID");           
        }
    
    }
}
