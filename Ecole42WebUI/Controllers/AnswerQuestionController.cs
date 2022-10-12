using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Ecole42Entity.Entity;
using Ecole42Entity.MainContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Logging;

namespace Ecole42WebUI.Controllers
{
    public class AnswerQuestionController : Controller
    {
        private Context db = new Context();

        [Route("/questions")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("/question/{id}")]
        public async Task<IActionResult> Question(Guid id) 
        {
            var question = await db.Questions.Include(x=>x.Admin).Include(x=> x.User).Where(x=> x.ID == id).FirstOrDefaultAsync();
            if (question == null || question.DeletionStatus == true)
                return RedirectToAction("Index", "Error", new { Area = "Admin" });
            var answerQuestions = await db.AnswerQuestions
            .Include(x=> x.Answer)
            .Include(x=>x.Answer.Admin)
            .Include(x=> x.Answer.User)
            .Where(x=> x.QuestionID == question.ID && !x.DeletionStatus).ToListAsync();
            answerQuestions.Sort((x, y) => DateTime.Compare((DateTime)x.CreateDate, (DateTime)y.CreateDate));
            Tuple<IEnumerable<AnswerQuestion>, Question> tuple = new Tuple<IEnumerable<AnswerQuestion>, Question>(answerQuestions, question);
            return View(tuple);
        }

        [NonAction]
        private int getAnswers(Question q)
        {
            var answerQuestions = db.AnswerQuestions.Where(x=> x.QuestionID == q.ID);
            return answerQuestions.Count();
        }

        [NonAction]
        private string getAuthor(Question q)
        {
            if (q.User.Name == "Admin")
                return q.Admin.Name + " " + q.Admin.Surname;
            return q.User.Name + " " + q.User.Surname;
        }

        [Route("/questions/get-questions")]
        [HttpGet]
        public async Task<JsonResult> getQuestions() 
        {
            List<Question> questions = new List<Question>();
            questions = await db.Questions.Include(x=> x.User).Include(x=> x.Admin).Where(x => !x.DeletionStatus).ToListAsync();

            var query = new 
            {
               result = from obj in questions
                select new
                {
                    title = $"<a href='/question/{obj.ID}' >{obj.Title}</a>",
                    author = getAuthor(obj),
                    answers = getAnswers(obj),
                    date = obj.CreateDate
                }
            };
            return Json(query);
        }

        [Route("/question/add-answer/{id}")]
        [HttpPost]
        public async Task<JsonResult> addAnswer(Answer answer, Guid id) // id = questionId
        {
            answer.ID = new Guid();
            if (HttpContext.Session.GetString("Email") == null)
                return Json(new {response = false, message= "Doğrulama hatası"});
            var question = await db.Questions.FirstOrDefaultAsync(x=> x.ID == id && !x.DeletionStatus);
            if (question == null || string.IsNullOrEmpty(answer.Description))
                return Json(new {response = false, message= "Doğrulama hatası"});
            Guid userID = new Guid(HttpContext.Session.GetString("ID"));
            if (await db.Admins.FindAsync(userID) != null)
            {
                answer.AdminID = userID;
                answer.UserID = db.Users.FirstOrDefault(x=> x.Name == "Admin").ID;
            }
            else
            {
                answer.AdminID = db.Admins.FirstOrDefault(x=> x.Email == "ermandgs74@gmail.com").ID;
                answer.UserID = userID;
            }
            answer.CreateDate = DateTime.Now;
            answer.LastDateTime = DateTime.Now;
            await db.Answers.AddAsync(answer);
            await db.SaveChangesAsync();
            AnswerQuestion answerQuestion = new AnswerQuestion()
            {
                AnswerID = answer.ID,
                QuestionID = question.ID,
                CreateDate = DateTime.Now,
                LastDateTime = DateTime.Now
            };
            await db.AnswerQuestions.AddAsync(answerQuestion);
            await db.SaveChangesAsync();
            return Json(new {response = true});
        }
    }
}