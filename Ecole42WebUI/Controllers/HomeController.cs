using Ecole42Entity.Entity;
using Ecole42Entity.MainContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Ecole42WebUI.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            return View();
        }
        private Context db = new Context();

        
        [NonAction]
        private void addProjects(IEnumerable<Project> projects, List<string> list)
        {
            foreach (var project in projects)
            {
                string text = $"<a href=\"/project/{project.ID}\" >{project.Title}</a>";
                list.Add(text);
            }
        }
        
        [NonAction]
        private void addArticles(IEnumerable<Article> articles, List<string> list)
        {
            foreach (var article in articles)
            {
                string text = $"<a href=\"/article/{article.ID}\" >{article.Title}</a>";
                list.Add(text);
            }
        }

        [NonAction]
        private void addQuestions(IEnumerable<Question> questions, List<string> list)
        {
            foreach (var question in questions)
            {
                string text = $"<a href=\"/question/{question.ID}\" >{question.Title}</a>";
                list.Add(text);
            }
        }

        [Route("/search")]
        [HttpGet]
        public async Task<JsonResult> getSearchValues(string query)
        {
            var projects = await db.Projects.Where(x=> x.Title.ToLower().Contains(query) && !x.DeletionStatus).ToListAsync();
            var articles = await db.Articles.Where(x=> x.Title.ToLower().Contains(query)).ToListAsync();
            var questions = await db.Questions.Where(x=> x.Title.ToLower().Contains(query)).ToListAsync();

            List<string> responseList = new List<string>();
            if (projects.Count() > 0)
                addProjects(projects, responseList);
            if (articles.Count() > 0)
                addArticles(articles, responseList);
            if (questions.Count() > 0)
                addQuestions(questions, responseList);
            return Json(responseList);
        }

    }
}
