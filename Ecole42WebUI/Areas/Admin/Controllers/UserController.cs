using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ecole42Entity.Entity;
using Ecole42Entity.MainContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecole42WebUI.Areas.Admin.SessionCheck;

namespace Ecole42WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        Context db = new Context();
        [Route("admin/list-site-user")]
        [SessionAuthorize]
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("Role") != "ADMIN")
                return RedirectToAction("Index", "Dashboard");
            var userList = db.Users.Where(x=> !x.DeletionStatus).ToListAsync();
            return View(await userList);
        }
    }
}
