using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ecole42Entity.Entity;
using Ecole42Entity.MainContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Ecole42WebUI.Areas.Admin.SessionCheck;

namespace Ecole42WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        Context db = new Context();

        [Route("admin/list-category")]
        [HttpGet]
        [SessionAuthorize]
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("Role") != "ADMIN")
                return RedirectToAction("Index", "Dashboard");
            var cat = await db.Categories.Where(x => !x.DeletionStatus).ToListAsync();
            return View(cat);
        }

        [Route("admin/add-category")]
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [Route("admin/add-category")]
        [HttpPost]
        public async Task<IActionResult> Add(Category model)
        {
            if (HttpContext.Session.GetString("Email") == null 
                || HttpContext.Session.GetString("Role") != "ADMIN" || string.IsNullOrEmpty(model.Name))
                return Json(new { response = false, message = "Hata!" });
            var cat = await db.Categories.FirstOrDefaultAsync(x => model.Name.ToLower() == x.Name.ToLower() && !x.DeletionStatus);
            if (cat != null)
                return Json(new { response = false, message = "Bu kategori zaten bulunmaktadır" });
            model.CreateDate = DateTime.Now;
            model.LastDateTime = DateTime.Now;
            db.Categories.Add(model);
            db.SaveChanges();
            return Json(new { response = true });
        }

        [Route("admin/update-category/{id}")]
        [HttpGet]
        [SessionAuthorize]
        public IActionResult Update(Guid id)
        {
            if (HttpContext.Session.GetString("Role") != "ADMIN")
                return RedirectToAction("Index", "Dashboard");
            var cat = db.Categories.Find(id);
            if (cat == null)
                return RedirectToAction("Index");
            return View(cat);
        }

        [Route("admin/update-category")]
        [HttpPost]
        public async Task<JsonResult> Update(Category model)
        {
            if (HttpContext.Session.GetString("Email") == null 
                || HttpContext.Session.GetString("Role") != "ADMIN"
                || string.IsNullOrEmpty(model.Name) || model.ID == Guid.Empty)
                return Json(new { response = false, message = "Hata!" });
            var cat = await db.Categories.FirstOrDefaultAsync(x => model.Name.ToLower() == x.Name.ToLower() && !x.DeletionStatus && x.ID != model.ID);
            if (cat != null)
                return Json(new { response = false, message = "Bu kategori zaten bulunmaktadır" });
            var current = await db.Categories.FindAsync(model.ID);
            current.Name = model.Name;
            current.LastDateTime = DateTime.Now;
            db.Categories.Update(current);
            db.SaveChanges();
            return Json(new { response = true });
        }

        [Route("admin/delete-category/{id}")]
        [HttpPost]
        public async Task<JsonResult> Delete(Guid id)
        {
            if (HttpContext.Session.GetString("Email") == null 
                || HttpContext.Session.GetString("Role") != "ADMIN")
                return Json(new { response = false, message = "Hata!" });
            var current = await db.Categories.FindAsync(id);
            if (current == null)
                return Json(new { response = false, message = "Hata!" });
            current.DeletionStatus = true;
            current.LastDateTime = DateTime.Now;
            db.Categories.Update(current);
            await db.SaveChangesAsync();
            return Json(new { response = true });
        }

    }
}
