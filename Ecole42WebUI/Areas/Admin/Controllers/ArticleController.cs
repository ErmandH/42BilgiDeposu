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
    public class ArticleController : Controller
    {
        Context db = new Context();
        [Route("admin/list-article")]
        [HttpGet]
        [SessionAuthorize]
        public async Task<IActionResult> Index()
        {
            Guid adminID = new Guid(HttpContext.Session.GetString("ID"));
            Task<List<Article>> articles;
            
            if (HttpContext.Session.GetString("Role") == "ADMIN")
                articles = db.Articles.Where(x => !x.DeletionStatus).ToListAsync();
            else
                articles = db.Articles.Where(x => !x.DeletionStatus && x.UserID == adminID).ToListAsync();
            return View(await articles);
        }

        [Route("admin/add-article")]
        [HttpGet]
        [SessionAuthorize]
        public IActionResult Add() 
        {
            return View();
        }
        
        [NonAction]
        private bool isArticleValid(Article model)
        {
            if (string.IsNullOrEmpty(model.Title) || model.Title.Length > 100 || string.IsNullOrEmpty(model.Description))
                return false;
            return true;
        }

        [Route("admin/add-article")]
        [HttpPost]
        public async Task<IActionResult> Add(Article model)
        {
            if (HttpContext.Session.GetString("Email") == null)
                return Json(new { response = false, message = "Hata!" });
            if (!isArticleValid(model))
                return Json(new { response = false, message = "Lütfen verileri doğru girdiğinize emin olun" });
            Guid userID = new Guid(HttpContext.Session.GetString("ID"));
            if (await db.Admins.FindAsync(userID) != null)
                model.AdminID = userID;
            if (await db.Users.FindAsync(userID) != null)
                model.UserID = userID;
            model.AuthorName = HttpContext.Session.GetString("Name");
            model.AuthorSurname = HttpContext.Session.GetString("Surname");
            model.CreateDate = DateTime.Now;
            model.LastDateTime = DateTime.Now;
            db.Articles.Add(model);
            db.SaveChanges();
            return Json(new {response = true } );
        }

        [Route("admin/update-article/{id}")]
        [HttpGet]
        [SessionAuthorize]
        public IActionResult Update(Guid id)
        {
            var article = db.Articles.Find(id);
            if (article == null)
                return RedirectToAction("Index");
            Guid adminID = new Guid(HttpContext.Session.GetString("ID"));
            if (adminID != article.AdminID && adminID != article.UserID 
                && HttpContext.Session.GetString("Role") != "ADMIN")
                  return RedirectToAction("Index");
            return View(article);
        }

        [Route("admin/article/get-description/{id}")]
        [HttpGet]
        public string getDescription(Guid id) 
        {
            if (HttpContext.Session.GetString("Email") == null)
                return null;
            Guid adminID = new Guid(HttpContext.Session.GetString("ID"));
            string desc = "";
            var article = db.Articles.FirstOrDefault(x => x.ID == id);
            if (adminID == article.UserID 
                || HttpContext.Session.GetString("Role") == "ADMIN")
                desc = article.Description;
            return desc;
        }

        [Route("admin/update-article")]
        [HttpPost]
        public JsonResult Update(Article model)
        {
            
            if (HttpContext.Session.GetString("Email") == null)
                return Json(new { response = false, message = "Hata!" });

            if (!isArticleValid(model) || model.ID == Guid.Empty)
                return Json(new { response = false, message = "Lütfen verileri doğru girdiğinize emin olun" });

            Guid adminID = new Guid(HttpContext.Session.GetString("ID"));
            var article = db.Articles.FirstOrDefault(x => !x.DeletionStatus && x.ID == model.ID);
            if (article == null || (article.UserID != adminID && HttpContext.Session.GetString("Role") == "USER"))
                return Json(new { response = false, message = "Sistemde hata oluştu sorunun devam etmesi halinde yetkiliye başvurun" });
            article.LastDateTime = DateTime.Now;
            article.Description = model.Description;
            article.Title = model.Title;
            db.Articles.Update(article);
            db.SaveChanges();
            return Json(new { response = true });
        }


        [Route("admin/delete-article/{id}")]
        [HttpPost]
        public async Task<JsonResult> Delete(Guid id) 
        {
            if (HttpContext.Session.GetString("Email") == null)
                return Json(new { response = false });
            Guid adminID = new Guid(HttpContext.Session.GetString("ID"));
            var data = await db.Articles.FindAsync(id);
            if (data == null || (data.UserID != adminID 
            && HttpContext.Session.GetString("Role") == "USER"))
                return Json(new { response = false });
            db.Articles.Remove(data);
            await db.SaveChangesAsync();
            return Json(new { response = true });
        }
    }
}
