using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WjbuGangVer2_WebNC.Models;

namespace WjbuGangVer2_WebNC.Controllers
{
    public class AccountController : Controller
    {
        QLBMTEntities cs = new QLBMTEntities();
        // GET: Account
        public ActionResult AccountLogic()
        {
            if (Session["User_username"] != null)
            {
                return RedirectToAction("Index");
            }
            else if (Session["Admin_username"] != null)
            {
                return RedirectToAction("Dashboard");
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult AccountLogic(Account account)
        {
            var y = cs.Accounts.Where(a => a.Username == account.Username && a.Password == account.Password && a.Role == "User").FirstOrDefault();
            var x = cs.Accounts.Where(a => a.Username == account.Username && a.Password == account.Password && a.Role == "Admin").FirstOrDefault();
            if (y != null)
            {
                Session["User_ID"] = y.AccountID;
                Session["User_username"] = y.Username;
                Session["User_Name"] = y.HoTen;
                ViewBag.User_Name = Session["User_Name"];
                return RedirectToAction("Index", "Home");

            }
            else if (x != null)
            {
                Session["Admin_ID"] = x.AccountID;
                Session["Admin_username"] = x.Username;
                Session["Admin_Name"] = x.HoTen;
                ViewBag.Admin_name = Session["Admin_Name"];
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
        public ActionResult AdminLogout()
        {
            Session["Admin_ID"] = null;
            Session["Admin_username"] = null;
            Session["Admin_Name"] = null;
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Userlogout()
        {
            Session["User_ID"] = null;
            Session["User_username"] = null;
            Session["User_Name"] = null;
            return RedirectToAction("Index", "Home");
        }
    }
}