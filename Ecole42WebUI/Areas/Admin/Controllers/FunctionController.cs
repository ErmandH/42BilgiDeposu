using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ecole42Entity.Entity;
using Ecole42Entity.MainContext;
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
    public class FunctionController : Controller
    {
        Context db = new Context();

        [Route("admin/list-function")]
        [HttpGet]
        [SessionAuthorize]
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("Role") != "ADMIN")
                return RedirectToAction("Index", "Dashboard");
            var projectFunction = await db.ProjectFunctions
                .Include(x => x.Function)
                .Include(x => x.Project)
                .Where(x => !x.DeletionStatus).ToListAsync();
            return View(projectFunction);
        }

        [Route("admin/add-function")]
        [HttpGet]
        [SessionAuthorize]
        public async Task<IActionResult> Add() 
        {
            if (HttpContext.Session.GetString("Role") != "ADMIN")
                return RedirectToAction("Index", "Dashboard");
            var projectList = await db.Projects.Where(x => !x.DeletionStatus).ToListAsync();
            return View(projectList);
        }


        [NonAction]
        private bool isFunctionValid(Function f)
        {
            if (string.IsNullOrEmpty(f.Name) || f.Name.Length > 100
            || string.IsNullOrEmpty(f.Description) || f.ID == Guid.Empty)
                return false;
            return true;
        }

        [Route("admin/add-function")]
        [RequestFormLimits(MultipartBodyLengthLimit = 209715200)]
        [HttpPost]
        public async Task<IActionResult> Add(Function f, Guid projectID)
        {
            if (HttpContext.Session.GetString("Email") == null 
                || HttpContext.Session.GetString("Role") != "ADMIN" || !isFunctionValid(f))
                return Json(new { response = false, message = "Hata" });
            var exist = await db.Functions.FirstOrDefaultAsync(x => x.Name.ToLower() == f.Name.ToLower() && !x.DeletionStatus);
            if (exist != null)
                return Json(new { response = false, message = "Bu fonksiyona ait kayıt zate bulunmamaktadır" });

            f.CreateDate = DateTime.Now;
            f.LastDateTime = DateTime.Now;
            db.Functions.Add(f);
            await db.SaveChangesAsync();
            ProjectFunction projectFunction = new ProjectFunction();
            projectFunction.FunctionID = f.ID;
            projectFunction.ProjectID = projectID;
            projectFunction.CreateDate = DateTime.Now;
            projectFunction.LastDateTime = DateTime.Now;
            db.ProjectFunctions.Add(projectFunction);
            await db.SaveChangesAsync();
            return Json(new { response = true });
        }

        [Route("admin/function/get-description/{id}")]
        [HttpGet]
        public string getDescription(Guid id)
        {
            if (HttpContext.Session.GetString("Email") == null 
                || HttpContext.Session.GetString("Role") != "ADMIN")
                return null;
            string desc = "";
            var func = db.Functions.Find(id);
            if (func != null)
                desc = func.Description;
            return desc;
        }

        [Route("admin/update-function/{id}")]
        [HttpGet]
        [SessionAuthorize]
        public async Task<IActionResult> Update(Guid id) 
        {
            if (HttpContext.Session.GetString("Role") != "ADMIN")
                return RedirectToAction("Index", "Dashboard");
            FunctionViewModel fvm = new FunctionViewModel();
            fvm.Projects = await db.Projects.Where(x => !x.DeletionStatus).ToListAsync();
            fvm.ProjectFunction = await db.ProjectFunctions.FindAsync(id);
            fvm.ProjectFunction.Function = await db.Functions.FindAsync(fvm.ProjectFunction.FunctionID);
            if (fvm.ProjectFunction == null)
                return RedirectToAction("Index", "Error");         
            return View(fvm);
        }

        [Route("admin/update-function")]
        [RequestFormLimits(MultipartBodyLengthLimit = 209715200)]
        [HttpPost]
        public async Task<JsonResult> Update(Function f, Guid projectID)
        {
            if (HttpContext.Session.GetString("Email") == null 
                || HttpContext.Session.GetString("Role") != "ADMIN"
                || !isFunctionValid(f))
                return Json(new { response = false, message = "Hata" });
            var func = await db.Functions.FindAsync(f.ID);
            if (func == null)
                return Json(new { response = false, message = "Hata" });
            func.Name = f.Name;
            func.Description = f.Description;
            func.LastDateTime = DateTime.Now;
            db.Functions.Update(func);
            await db.SaveChangesAsync();
            var projectFunction = await db.ProjectFunctions.FirstOrDefaultAsync(x=> x.FunctionID == func.ID);
            projectFunction.ProjectID = projectID;
            db.ProjectFunctions.Update(projectFunction);
            await db.SaveChangesAsync();
            return Json(new { response = true });
        }

        [Route("admin/delete-function/{id}")]
        [HttpPost]
        public async Task<JsonResult> Delete(Guid id)
        {
            if (HttpContext.Session.GetString("Email") == null
                || HttpContext.Session.GetString("Role") != "ADMIN")
                return Json(new { response = false, message = "Hata" });
            var func = await db.Functions.FindAsync(id);
            if (func == null)
                return Json(new { response = false, message = "Hata" });
            func.LastDateTime = DateTime.Now;
            func.DeletionStatus = true;
            db.Functions.Update(func);
            await db.SaveChangesAsync();
            var projectFunction = await db.ProjectFunctions.FirstOrDefaultAsync(x => x.FunctionID == func.ID);
            projectFunction.DeletionStatus = true;
            db.ProjectFunctions.Update(projectFunction);
            await db.SaveChangesAsync();
            return Json(new { response = true });
        }

    }
}
