using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WjbuGangVer2_WebNC.Models;

namespace WjbuGangVer2_WebNC.Controllers
{
    public class AdminController : Controller
    {
        QLBMTEntities cs = new QLBMTEntities();

        public ActionResult Adminlogin()
        {
            if (Session["u"] != null)
            {
                return RedirectToAction("Dashboard");
            }
            else
            {
                return View();
            }

        }
        [HttpPost]
        public ActionResult Adminlogin(Admin admin)
        {
            var x = cs.Admins.Where(a => a.Username == admin.Username && a.Password == admin.Password).FirstOrDefault();
            if (x != null)
            {
                Session["u"] = admin.Username;
                return RedirectToAction("Dashboard");
            }
            else
            {
                ViewBag.m = "Sai tài khoản hoặc mật khẩu";
            }
            return View();
        }
        [HttpGet]
        public ActionResult Dashboard()
        {
            return View();
        }
    }
}