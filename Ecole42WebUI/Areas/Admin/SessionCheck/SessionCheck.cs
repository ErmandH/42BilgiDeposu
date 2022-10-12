using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;

namespace Ecole42WebUI.Areas.Admin.SessionCheck
{
    public class SessionAuthorize: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var session = filterContext.HttpContext.Session;
            if (session.GetString("Email") == null)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(new {controller = "Login", action = "Index"}));
            }
        }
    } 
}