using Ecole42Entity.MainContext;
using Ecole42Entity.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecole42WebUI.Areas.Admin.ViewModels;
using Microsoft.AspNetCore.Http;
using Ecole42WebUI.Areas.Admin.SessionCheck;

namespace Ecole42WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsefulLinkController : Controller
    {
        Context db = new Context();
        [Route("admin/list-useful-link")]
        [HttpGet]
        [SessionAuthorize]
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("Role") != "ADMIN")
                return RedirectToAction("Index", "Dashboard");
            UsefulLinkViewModel uvm = new UsefulLinkViewModel();
            uvm.Projects = await db.Projects.Where(x => !x.DeletionStatus).ToListAsync();
            uvm.ProjectUsefulLinks = await db.ProjectUsefulLinks
                .Include(x => x.UsefulLink)
                .Include(x => x.Project)
                .Where(x => !x.DeletionStatus).ToListAsync();
            return View(uvm);
        }

        [Route("admin/add-useful-link")]
        [HttpPost]
        public async Task<IActionResult> Add(UsefulLink model, Guid projectID)
        {
            if (HttpContext.Session.GetString("Email") == null
                || HttpContext.Session.GetString("Role") != "ADMIN" || string.IsNullOrEmpty(model.Title) 
                || model.Title.Length > 100 || string.IsNullOrEmpty(model.URL) || projectID == Guid.Empty)
                return Json(new { response = false, message = "Hata!" });
            model.CreateDate = DateTime.Now;
            model.LastDateTime = DateTime.Now;
            db.UsefulLinks.Add(model);
            await db.SaveChangesAsync();
            ProjectUsefulLink projectUsefulLink = new ProjectUsefulLink();
            projectUsefulLink.CreateDate = DateTime.Now;
            projectUsefulLink.LastDateTime = DateTime.Now;
            projectUsefulLink.ProjectID = projectID;
            projectUsefulLink.UsefulLinkID = model.ID;
            db.ProjectUsefulLinks.Add(projectUsefulLink);
            await db.SaveChangesAsync();
            return Json(new { response = true });
        }

        [Route("admin/update-useful-link/{id}")]
        [HttpGet]
        [SessionAuthorize]
        public async Task<IActionResult> Update(Guid id)
        {
            if (HttpContext.Session.GetString("Role") != "ADMIN")
                return View("Index", "Error");
            UsefulLinkViewModel uvm = new UsefulLinkViewModel();
            uvm.ProjectUsefulLink = db.ProjectUsefulLinks.Include(x => x.UsefulLink).FirstOrDefault(x => x.ID == id);
            if (uvm.ProjectUsefulLink == null)
                return View("Index", "Error");
            uvm.Projects = await db.Projects.Where(x => !x.DeletionStatus).ToListAsync();
            uvm.ProjectUsefulLinks = null;
            return PartialView(uvm);
        }

        [Route("admin/update-useful-link")]
        [HttpPost]
        public async Task<JsonResult> Update(UsefulLink u, Guid projectID)
        {
            if (HttpContext.Session.GetString("Email") == null
                || HttpContext.Session.GetString("Role") != "ADMIN" || string.IsNullOrEmpty(u.Title) 
                || u.Title.Length > 100 || string.IsNullOrEmpty(u.URL) || projectID == Guid.Empty || u.ID == Guid.Empty)
                return Json(new { response = false, message = "Hata meydana geldi" });
            var useful = await db.UsefulLinks.FindAsync(u.ID);
            if (useful == null)
                return Json(new { response = false, message = "Hata meydana geldi" });
            useful.LastDateTime = DateTime.Now;
            useful.Title = u.Title;
            useful.URL = u.URL;
            db.UsefulLinks.Update(useful);
            await db.SaveChangesAsync();
            var pU = await db.ProjectUsefulLinks.FirstOrDefaultAsync(x => x.UsefulLinkID == useful.ID);
            pU.ProjectID = projectID;
            pU.LastDateTime = DateTime.Now;
            db.ProjectUsefulLinks.Update(pU);
            await db.SaveChangesAsync();
            return Json(new { response = true });
        }

        [Route("admin/delete-useful-link/{id}")]
        [HttpPost]
        public async Task<JsonResult> Delete(Guid id)
        {
            if (HttpContext.Session.GetString("Email") == null
                || HttpContext.Session.GetString("Role") != "ADMIN")
                return Json(new { response = false, message = "Hata meydana geldi" });
            var current = await db.UsefulLinks.FindAsync(id);
            if (current == null)
                return Json(new { response = false, message = "Hata meydana geldi" });
            current.DeletionStatus = true;
            current.LastDateTime = DateTime.Now;
            db.UsefulLinks.Update(current);
            db.SaveChanges();
            var pu = db.ProjectUsefulLinks.FirstOrDefault(x => x.UsefulLinkID == id);
            pu.DeletionStatus = true;
            pu.LastDateTime = DateTime.Now;
            db.ProjectUsefulLinks.Update(pu);
            db.SaveChanges();
            return Json(new { response = true });
        }
    }
}
