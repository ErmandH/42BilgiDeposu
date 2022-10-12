using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Ecole42Entity.Entity;
using Ecole42Entity.MainContext;
using Ecole42WebUI.Areas.Admin.SessionCheck;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Ecole42WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AnswerController : Controller
    {
 
        private Context db = new Context();

   
        [Route("admin/answer/get-description/{id}")]
        [HttpGet]
        public string getDescription(Guid id)
        {
            if (HttpContext.Session.GetString("Email") == null)
                return null;
            Guid adminID = new Guid(HttpContext.Session.GetString("ID"));
            string desc = "";
            var answer = db.Answers.FirstOrDefault(x => x.ID == id);
            if (answer == null || (answer.UserID != adminID && HttpContext.Session.GetString("Role") != "ADMIN"))
                return desc;
            desc = answer.Description;
            return desc;
        }

        [Route("admin/update-answer")]
        [HttpPost]
        public IActionResult Update(Answer model)
        {
            if (HttpContext.Session.GetString("Email") == null 
            || string.IsNullOrEmpty(model.Description) || model.ID == Guid.Empty)
                return Json(new {response = false});
            Guid adminID = new Guid(HttpContext.Session.GetString("ID"));
            var answer = db.Answers.FirstOrDefault(x => !x.DeletionStatus && x.ID == model.ID);
            if (answer == null || (answer.UserID != adminID && HttpContext.Session.GetString("Role") != "ADMIN") )
                return Json(new { response = false, message = "Sistemde hata oluştu sorunun devam etmesi halinde yetkiliye başvurun" });
            answer.LastDateTime = DateTime.Now;
            answer.Description = model.Description;
            db.Answers.Update(answer);
            db.SaveChanges();
            return Json(new { response = true });
        }


        [Route("admin/delete-answer/{id}")]
        [HttpPost]
        public async Task<IActionResult> Delete(Guid id) 
        {
            if (HttpContext.Session.GetString("Email") == null)
                return Json(new { response = false });
            Guid adminID = new Guid(HttpContext.Session.GetString("ID"));
            var data = await db.Answers.FindAsync(id);
            if (data == null || (data.UserID != adminID && HttpContext.Session.GetString("Role") != "ADMIN"))
                return Json(new { response = false });
            var answerQuestion = await db.AnswerQuestions.FirstOrDefaultAsync(x=> x.AnswerID == id);
            db.AnswerQuestions.Remove(answerQuestion);
            await db.SaveChangesAsync();
            db.Answers.Remove(data);
            await db.SaveChangesAsync();
            return Json(new { response = true });
        }

    }
}