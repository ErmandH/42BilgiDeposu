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
    public class QuestionController : Controller
    {
        Context db = new Context();

        [SessionAuthorize]
        [Route("admin/list-question")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            Guid adminID = new Guid(HttpContext.Session.GetString("ID"));
            Task<List<Question>> questions;
            
            if (HttpContext.Session.GetString("Role") == "ADMIN")
                questions = db.Questions.Include(x=> x.Admin).Include(x=>x.User).Where(x => !x.DeletionStatus).ToListAsync();
            else
                questions = db.Questions.Include(x=> x.Admin).Include(x=>x.User).Where(x => !x.DeletionStatus && x.UserID == adminID).ToListAsync();
            var ret = await questions;
            return View(ret);
        }

        [SessionAuthorize]
        [Route("admin/add-question")]
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [Route("admin/add-question")]
        [HttpPost]
        public async Task<IActionResult> Add(Question model)
        {
            if (HttpContext.Session.GetString("Email") == null || string.IsNullOrEmpty(model.Title)
            || model.Title.Length > 100 || string.IsNullOrEmpty(model.Description))
                return Json( new {response = false});
            Guid userID = new Guid(HttpContext.Session.GetString("ID"));
            if (HttpContext.Session.GetString("Role") == "ADMIN")
            {
                model.AdminID = userID;
                model.UserID = db.Users.FirstOrDefault(x=> x.Name == "Admin").ID;
            }
                
            if (HttpContext.Session.GetString("Role") == "USER")
            {
                model.UserID = userID;
                model.AdminID = db.Admins.FirstOrDefault(x=> x.Email == "ermandgs74@gmail.com").ID;
            }
            model.CreateDate = DateTime.Now;
            model.LastDateTime = DateTime.Now;
            await db.Questions.AddAsync(model);
            await db.SaveChangesAsync();
            return Json(new {response = true } );
        }

        [Route("admin/update-question/{id}")]
        [HttpGet]
        [SessionAuthorize]
        public async Task<IActionResult> Update(Guid id)
        {
            var question = await db.Questions.FindAsync(id);
            if (question == null)
                return RedirectToAction("Index");
            Guid adminID = new Guid(HttpContext.Session.GetString("ID"));
            if (adminID != question.UserID 
                && HttpContext.Session.GetString("Role") != "ADMIN")
                  return RedirectToAction("Index");
            return View(question);
        }

        [Route("admin/question/get-description/{id}")]
        [HttpGet]
        public string getDescription(Guid id)
        {
            if (HttpContext.Session.GetString("Email") == null)
                return null;
            Guid adminID = new Guid(HttpContext.Session.GetString("ID"));
            string desc = "";
            var question = db.Questions.FirstOrDefault(x => x.ID == id);
            if (question == null || (question.UserID != adminID && HttpContext.Session.GetString("Role") != "ADMIN"))
                return desc;
            desc = question.Description;
            return desc;
        }

        [Route("admin/update-question")]
        [HttpPost]
        public IActionResult Update(Question model)
        {
            if (HttpContext.Session.GetString("Email") == null || string.IsNullOrEmpty(model.Title)
            || model.Title.Length > 100 || string.IsNullOrEmpty(model.Description) || model.ID == Guid.Empty)
                return Json(new {response = false});
            Guid adminID = new Guid(HttpContext.Session.GetString("ID"));
            var question = db.Questions.FirstOrDefault(x => !x.DeletionStatus && x.ID == model.ID);
            if (question == null || (question.UserID != adminID && HttpContext.Session.GetString("Role") != "ADMIN") )
                return Json(new { response = false, message = "Sistemde hata oluştu sorunun devam etmesi halinde yetkiliye başvurun" });
            question.LastDateTime = DateTime.Now;
            question.Description = model.Description;
            question.Title = model.Title;
            db.Questions.Update(question);
            db.SaveChanges();
            return Json(new { response = true });
        }

        [Route("admin/delete-question/{id}")]
        [HttpPost]
        public async Task<IActionResult> Delete(Guid id) 
        {
            if (HttpContext.Session.GetString("Email") == null)
                return Json(new { response = false });
            Guid adminID = new Guid(HttpContext.Session.GetString("ID"));
            var data = await db.Questions.FindAsync(id);
            if (data == null || (data.UserID != adminID && HttpContext.Session.GetString("Role") != "ADMIN"))
                return Json(new { response = false });
            var answerQuestions = await db.AnswerQuestions.Where(x=> x.QuestionID == data.ID).ToListAsync();
            if (answerQuestions.Count() > 0)
            {
                foreach (var item in answerQuestions)
                {
                    Guid answerID = (Guid)item.AnswerID;
                    db.AnswerQuestions.Remove(item);
                    await db.SaveChangesAsync();
                    db.Answers.Remove(db.Answers.SingleOrDefault(x=>x.ID == answerID));                
                    await db.SaveChangesAsync();
                }
                db.Questions.Remove(data);
                await db.SaveChangesAsync();
            }      
            return Json(new { response = true });
        }
    }
}
