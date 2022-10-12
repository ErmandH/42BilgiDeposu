using Microsoft.AspNetCore.Mvc;
using Ecole42Entity.Entity;
using Ecole42Entity.MainContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Ecole42WebUI.Controllers
{
    public class ArticleController : Controller
    {
        Context db = new Context();
        [Route("/articles")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("/article/{id}")]
        public async Task<IActionResult> Article(Guid id) 
        {
            var article = await db.Articles.FindAsync(id);
            if (article == null || article.DeletionStatus == true)
                return RedirectToAction("Index", "Error", new { Area = "Admin" });
            return View(article);
        }

        [Route("/articles/get-articles")]
        [HttpGet]
        public async Task<JsonResult> getArticles() 
        {
            List<Article> articles = new List<Article>();
            articles = await db.Articles.Where(x => !x.DeletionStatus).ToListAsync();

            var query = new 
            {
               result = from obj in articles
                select new
                {
                    Title = $"<a href='/article/{obj.ID}' >{obj.Title}</a>",
                    Author = obj.AuthorName + " " + obj.AuthorSurname,
                    Date = obj.CreateDate
                }
            };

            return Json(query);
        }


    }
}
