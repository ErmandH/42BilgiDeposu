using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecole42WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ErrorController : Controller
    {
        [Route("/admin/404-error")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
