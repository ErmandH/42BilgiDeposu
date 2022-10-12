using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecole42WebUI.Models;
using Ecole42Entity.Entity;
using Ecole42Entity.MainContext;

namespace Ecole42WebUI.Controllers
{
    public class ProjectController : Controller
    {
        Context db = new Context();
        [Route("/projects")]
        public async  Task<IActionResult> Index()
        {
            ProjectsViewModel pvm = new ProjectsViewModel();
            var c1 = await db.Projects
                .Include(x => x.Category)
                .Where(x => !x.DeletionStatus && x.Category.Name.ToLower() == "Birinci Halka".ToLower())
                .ToListAsync();
            var c2 = await db.Projects
               .Include(x => x.Category)
               .Where(x => !x.DeletionStatus && x.Category.Name.ToLower() == "İkinci Halka".ToLower())
               .ToListAsync();
            var c3 = await db.Projects
               .Include(x => x.Category)
               .Where(x => !x.DeletionStatus && x.Category.Name.ToLower() == "Üçüncü Halka".ToLower())
               .ToListAsync();
            var c4 = await db.Projects
               .Include(x => x.Category)
               .Where(x => !x.DeletionStatus && x.Category.Name.ToLower() == "Dördüncü Halka".ToLower())
               .ToListAsync();
            var c5 = await db.Projects
               .Include(x => x.Category)
               .Where(x => !x.DeletionStatus && x.Category.Name.ToLower() == "Beşinci Halka".ToLower())
               .ToListAsync();
            var c6 = await db.Projects
               .Include(x => x.Category)
               .Where(x => !x.DeletionStatus && x.Category.Name.ToLower() == "Altıncı Halka".ToLower())
               .ToListAsync();

            pvm.FirstCircle = c1;
            pvm.SecondCircle =  c2;
            pvm.ThirdCircle =  c3;
            pvm.FourthCircle = c4;
            pvm.FifthCircle = c5;
            pvm.SixthCircle = c6;
            return View(pvm);
        }

        [Route("/project/{id}")]
        public async Task<IActionResult> Project(Guid id) 
        {
            var proje = await db.Projects.FindAsync(id);
            if (proje == null || proje.DeletionStatus)
                return RedirectToAction("Index");
            ProjectViewModel pvm = new ProjectViewModel();
            pvm.Project = proje;
            var funcList = await db.ProjectFunctions
                .Include(x => x.Function)
                .Where(x => !x.DeletionStatus && x.ProjectID == proje.ID).ToListAsync();

            funcList.Sort((x, y) => x.Function.Name.CompareTo(y.Function.Name));
            pvm.ProjectFunctions = funcList;
            pvm.ProjectUsefulLinks = await db.ProjectUsefulLinks
                .Include(x=> x.UsefulLink)
                .Where(x => !x.DeletionStatus && x.ProjectID == proje.ID).ToListAsync();
            return View(pvm);
        }
    }
}
