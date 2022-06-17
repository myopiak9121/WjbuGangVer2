using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WjbuGangVer2_WebNC.Controllers
{
    public class BaseController : Controller    
    {
        // GET: Admin/Base
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            if (Session["Admin_username"].Equals("") && Session["Admin_ID"].Equals(""))
            {
                RouteValueDictionary route = new RouteValueDictionary(new { Controller = "Account", Action = "AccountLogic" });
                filterContext.Result = new RedirectToRouteResult(route);
                return;
            }
        }
    }
}