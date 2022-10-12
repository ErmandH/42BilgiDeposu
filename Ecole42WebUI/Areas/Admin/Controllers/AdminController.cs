using Ecole42Entity.MainContext;
using Ecole42Entity.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecole42WebUI.Areas.Admin.SessionCheck;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Ecole42WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {
        Context db = new Context();
        [Route("admin/list-user")]
        [SessionAuthorize]
        public async Task<IActionResult> Index()
        {
            string mail = HttpContext.Session.GetString("Email");
            if (mail != "ermandgs74@gmail.com")
                return RedirectToAction("Index", "Dashboard");
            var adminList = await db.Admins.Where(x => !x.DeletionStatus).ToListAsync();
            return View(adminList);
        }

        [Route("admin/add-user")]
        [HttpGet]
        [SessionAuthorize]
        public IActionResult Add()
        {
            string mail = HttpContext.Session.GetString("Email");
            if (mail != "ermandgs74@gmail.com")
                return RedirectToAction("Index", "Dashboard");
            return View();
        }
        
        [NonAction]
        private bool isAdminValid(Ecole42Entity.Entity.Admin admin, string pass, string repass)
        {
            if (string.IsNullOrEmpty(admin.Name) || string.IsNullOrEmpty(admin.Surname) 
            || string.IsNullOrEmpty(admin.Email) || string.IsNullOrEmpty(pass) || string.IsNullOrEmpty(repass))
                return false;
            return true;
        }

        [Route("admin/add-user")]
        [HttpPost]
        public JsonResult Add(Ecole42Entity.Entity.Admin admin, string pass, string repass)
        {
            if (!isAdminValid(admin, pass, repass))
                return Json(new { response = false, message = "Hata!" });
            string mail = HttpContext.Session.GetString("Email");
            if (string.IsNullOrEmpty(mail) || mail != "ermandgs74@gmail.com")
                return Json(new { response = false, message = "Hata!" });
            if (pass != repass)
                return Json(new { response = false, message = "Şifreler uyuşmamaktadır" });
            var existAdmin = db.Admins.FirstOrDefault(x => x.Email.ToLower() == admin.Email.ToLower() && !x.DeletionStatus);
            if (existAdmin != null)
                return Json(new { response = false, message = "Bu e-postaya ait kullanıcı zaten bulunmaktadır" });
            admin.Password = pass;
            admin.CreateDate = DateTime.Now;
            admin.LastDateTime = DateTime.Now;
            admin.DeletionStatus = false;
            admin.Role = "ADMIN";
            db.Admins.Add(admin);
            db.SaveChanges();
            return Json(new { response = true });
        }

        [Route("admin/update-user/{id}")]
        [HttpGet]
        [SessionAuthorize]
        public async Task<IActionResult> Update(Guid id)
        {
            string mail = HttpContext.Session.GetString("Email");
            if (mail != "ermandgs74@gmail.com")
                return RedirectToAction("Index", "Dashboard");
            var admin = await db.Admins.FindAsync(id);
            if (admin == null)
                return RedirectToAction("Index", "Error");
            return PartialView(admin);
        }

        [Route("admin/update-user")]
        [HttpPost]
        public async Task<IActionResult> Update(Ecole42Entity.Entity.Admin admin, string pass, string repass)
        {
            string mail = HttpContext.Session.GetString("Email");
            if (string.IsNullOrEmpty(mail) || mail != "ermandgs74@gmail.com")
                return Json(new { response = false, message = "Hata!" });
            if (!isAdminValid(admin, pass, repass))
                return Json(new { response = false, message = "Hata!" });
            var currentAdmin = await db.Admins.FindAsync(admin.ID);
            if (currentAdmin == null)
                return RedirectToAction("Index");
            if (pass != repass)
                return Json(new { response = false, message = "Şifre uyuşmamaktadır" });
            if (await db.Admins.FirstOrDefaultAsync(x =>
            x.Email.ToLower() == admin.Email.ToLower() && admin.Email.ToLower() != currentAdmin.Email.ToLower() && !x.DeletionStatus) != null)
                return Json(new { response = false, message = "Yeni e-posta sistemde mevcut" });
            currentAdmin.Name = admin.Name;
            currentAdmin.Surname = admin.Surname;
            currentAdmin.Email = admin.Email;
            currentAdmin.Password = pass;
            currentAdmin.LastDateTime = DateTime.Now;
            db.Admins.Update(currentAdmin);
            await db.SaveChangesAsync();
            return Json(new { response = true });
        }

        [Route("admin/delete-user/{id}")]
        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            string mail = HttpContext.Session.GetString("Email");
            if (string.IsNullOrEmpty(mail) || mail != "ermandgs74@gmail.com")
                return Json(new { response = false, message = "Hata!" });
            var admin = await db.Admins.FindAsync(id);
            if (admin == null)
                return Json(new { response = false, message = "Hata!" });
            admin.DeletionStatus = true;
            admin.LastDateTime = DateTime.Now;
            db.Admins.Update(admin);
            await db.SaveChangesAsync();
            return Json(new { response = true });
        }
    }
}
