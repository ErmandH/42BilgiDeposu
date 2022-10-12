using Ecole42Entity.Entity;
using Ecole42Entity.MainContext;
using Ecole42WebUI.Areas.Admin.SessionCheck;
using Ecole42WebUI.Areas.Admin.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecole42WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProjectController : Controller
    {
        Context db = new Context();
        [Route("admin/list-project")]
        [HttpGet]
        [SessionAuthorize]
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("Role") != "ADMIN")
                return RedirectToAction("Index", "Dashboard");
            var projects = await db.Projects.Where(x => !x.DeletionStatus).Include(x=> x.Category).ToListAsync();
            return View(projects);
        }

        [Route("admin/add-project")]
        [HttpGet]
        [SessionAuthorize]
        public async Task<IActionResult> Add()
        {
            if (HttpContext.Session.GetString("Role") != "ADMIN")
                return RedirectToAction("Index", "Dashboard");
            ProjectViewModel viewModel = new ProjectViewModel();
            viewModel.Categories = await db.Categories.Where(x => !x.DeletionStatus).ToListAsync();
            return View(viewModel);
        }

        [NonAction]
        private bool isProjectValid(Project p, Guid catID)
        {
            if (string.IsNullOrEmpty(p.Title) || p.Title.Length > 100
            || string.IsNullOrEmpty(p.Description) || p.ID == Guid.Empty || catID == Guid.Empty
            || string.IsNullOrEmpty(p.ShortDescription))
                return false;
            return true;
        }

        [Route("admin/add-project")]
        [RequestFormLimits(MultipartBodyLengthLimit = 209715200)]
        [HttpPost]
        public async Task<IActionResult> Add(Project p, Guid catID)
        {
            if (HttpContext.Session.GetString("Email") == null 
                || HttpContext.Session.GetString("Role") != "ADMIN" || !isProjectValid(p, catID))
                return Json(new { response = false, message = "Hata!" });
            var current = await db.Projects.FirstOrDefaultAsync(x => x.Title.ToLower() == p.Title.ToLower());
            if (current != null)
                return Json(new { response = false, message = "Bu projeye ait bir kayıt zaten var" });
            p.CreateDate = DateTime.Now;
            p.LastDateTime = DateTime.Now;
            p.CategoryID = catID;
            db.Projects.Add(p);
            await db.SaveChangesAsync();
            return Json(new { response = true });
        }

        [Route("admin/update-project/{id}")]
        [HttpGet]
        [SessionAuthorize]
        public async Task<IActionResult> Update(Guid id)
        {
            if (HttpContext.Session.GetString("Role") != "ADMIN")
                return RedirectToAction("Index", "Dashboard");
            ProjectViewModel viewModel = new ProjectViewModel();
            viewModel.Project = await db.Projects.FindAsync(id);
            if (viewModel.Project == null)
                return RedirectToAction("Index");
            viewModel.Categories = await db.Categories.Where(x => !x.DeletionStatus).ToListAsync();
            return View(viewModel);
        }

        [Route("admin/update-project")]
        [RequestFormLimits(MultipartBodyLengthLimit = 209715200)]
        [HttpPost]
        public async Task<JsonResult> Update(Project p, Guid catID)
        {
            if (HttpContext.Session.GetString("Email") == null 
                || HttpContext.Session.GetString("Role") != "ADMIN" || !isProjectValid(p, catID))
                return Json(new { response = false, message = "Hata!" });
            var pro = await db.Projects.FindAsync(p.ID);
            if (pro == null)
               return Json(new { response = false, message = "Hata!" });
            pro.LastDateTime = DateTime.Now;
            pro.CategoryID = catID;
            pro.Title = p.Title;
            pro.Description = p.Description;
            pro.ShortDescription = p.ShortDescription;

            db.Projects.Update(pro);
            await db.SaveChangesAsync();
            return Json(new { response = true });
        }

        [Route("/admin/project/get-description/{id}")]
        [HttpGet]
        public string getDescription(Guid id)
        {
            if (HttpContext.Session.GetString("Email") == null 
                || HttpContext.Session.GetString("Role") != "ADMIN")
                return null;
            string desc = db.Projects.Find(id).Description;
            return desc;
        }


        [Route("/admin/project/get-short-description/{id}")]
        [HttpGet]
        public string getShortDescription(Guid id)
        {
            if (HttpContext.Session.GetString("Email") == null
                || HttpContext.Session.GetString("Role") != "ADMIN")
                return null;
            string desc = db.Projects.Find(id).ShortDescription;
            return desc;
        }

        [Route("admin/delete-project/{id}")]
        [HttpPost]
        public async Task<JsonResult> Delete(Guid id) 
        {
            if (HttpContext.Session.GetString("Email") == null
                || HttpContext.Session.GetString("Role") != "ADMIN")
                return Json(new { response = false, message = "Hata!" });
            var p = await db.Projects.FindAsync(id);
            if (p == null)
                return Json(new { response = false, message = "Hata!" });
            p.DeletionStatus = true;
            p.LastDateTime = DateTime.Now;
            db.Projects.Update(p);
            await db.SaveChangesAsync();
            return Json(new { response = true });
        }

    }
}
