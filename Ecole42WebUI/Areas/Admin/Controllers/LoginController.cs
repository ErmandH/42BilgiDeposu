using Microsoft.AspNetCore.Mvc;
using Ecole42Entity.Entity;
using Microsoft.EntityFrameworkCore;
using Ecole42Entity.MainContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Localization;
using Ecole42WebUI.Areas.Admin.IntraHelper;

namespace Ecole42WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoginController : Controller
    {
        Context db = new Context();
        [Route("admin/login")]
        [HttpGet]
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("Email") != null)
                return RedirectToAction("Index", "Dashboard");
            return View();
        }

        [Route("admin/login")]
        [HttpPost]
        public async Task<IActionResult> Index(string Email, string Password)
        {
            if (Email == null || Password == null)
                return Json(new { response = false, message = "Hata!" });
            var data = await db.Admins.Where(x => x.Email.ToUpper().ToLower() == Email.ToUpper().ToLower() && x.Password == Password && !x.DeletionStatus).ToListAsync();
            if (data.Count() == 0)
                return Json(new { response = false, message = "E-Posta veya Şifre Hatalı" });
            else if (data.Count() > 1)
                return Json(new { response = false, message = "Sistemde bir hata meydana geldi. Devam etmesi durumunda yetkili bir kişiye başvurunuz" });
            
            HttpContext.Session.SetString("ID",  data.FirstOrDefault().ID.ToString());
            HttpContext.Session.SetString("Email", data.FirstOrDefault().Email);
            HttpContext.Session.SetString("Password", data.FirstOrDefault().Password);
            HttpContext.Session.SetString("Name", data.FirstOrDefault().Name);
            HttpContext.Session.SetString("Surname", data.FirstOrDefault().Surname);
            HttpContext.Session.SetString("CreateDate", data.FirstOrDefault().CreateDate.ToString());
            HttpContext.Session.SetString("LastDateTime", data.FirstOrDefault().LastDateTime.ToString());
            HttpContext.Session.SetString("Role", data.FirstOrDefault().Role);           
            HttpContext.Session.SetString("intraID", (-1).ToString());           
            HttpContext.Session.SetString("Image", "ADMIN");   

            return Json(new { response = true });
        }


        [Route("admin/logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return Redirect("~/");
        }

        private IntraWorker worker = new IntraWorker();

        [Route("admin/intra-login")]
        [HttpGet]
        public async Task<IActionResult> IntraLogin(string code)
        {
            if (code == null)
                return RedirectToAction("Index");
            string access_token = await worker.GetAccessTokenAsync(code);
            JObject userData = await worker.GetIntraUserAsync(access_token);   
            int intraID = userData["id"].Value<int>();
            JArray coalitionData = await worker.GetCoalitionAsync(intraID, access_token);
            var intraUser = await db.Users.Where(x=> x.intraID == intraID && !x.DeletionStatus).ToListAsync();
            if (intraUser.Count() == 0){
                User user = await worker.addIntraUser(userData, intraID);

                HttpContext.Session.SetString("ID",  user.ID.ToString());
                HttpContext.Session.SetString("Email", user.Email);
                HttpContext.Session.SetString("Name", user.Name);
                HttpContext.Session.SetString("Surname", user.Surname);
                HttpContext.Session.SetString("CreateDate", user.CreateDate.ToString());
                HttpContext.Session.SetString("LastDateTime", user.LastDateTime.ToString());
                HttpContext.Session.SetString("Role",user.Role);
                HttpContext.Session.SetString("Image",user.ImageUrl);
                HttpContext.Session.SetString("intraID", user.intraID.ToString());
            }
            else
            {
                HttpContext.Session.SetString("ID",  intraUser.FirstOrDefault().ID.ToString());
                HttpContext.Session.SetString("Email", intraUser.FirstOrDefault().Email);
                HttpContext.Session.SetString("Name", intraUser.FirstOrDefault().Name);
                HttpContext.Session.SetString("Surname", intraUser.FirstOrDefault().Surname);
                HttpContext.Session.SetString("CreateDate", intraUser.FirstOrDefault().CreateDate.ToString());
                HttpContext.Session.SetString("LastDateTime", intraUser.FirstOrDefault().LastDateTime.ToString());
                HttpContext.Session.SetString("Role", intraUser.FirstOrDefault().Role);
                HttpContext.Session.SetString("Image",intraUser.FirstOrDefault().ImageUrl);
                HttpContext.Session.SetString("intraID", intraUser.FirstOrDefault().intraID.ToString());  
            }
            HttpContext.Session.SetString("Token", access_token);
            HttpContext.Session.SetString("Campus", userData["campus"][0]["name"].ToString());
            HttpContext.Session.SetString("Level", userData["cursus_users"][1]["level"].ToString());
            HttpContext.Session.SetString("Wallet", userData["wallet"].Value<string>());   
            HttpContext.Session.SetString("Evaluation", userData["correction_point"].Value<string>());
            HttpContext.Session.SetString("Date", userData["cursus_users"][1]["blackholed_at"].ToString());
            HttpContext.Session.SetString("Username", userData["login"].ToString());
            HttpContext.Session.SetString("CoalitionName", coalitionData[0]["name"].ToString());       
            HttpContext.Session.SetString("CoalitionBackground", coalitionData[0]["cover_url"].ToString());
            HttpContext.Session.SetString("CoalitionLogo", coalitionData[0]["image_url"].ToString());
            HttpContext.Session.SetString("CoalitionColor", coalitionData[0]["color"].ToString());
            return RedirectToAction("Index", "Dashboard");
        }
    }
}
