using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WjbuGangVer2_WebNC.Models;
namespace WjbuGangVer2_WebNC.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            using (QLBMTEntities db = new QLBMTEntities())
            {
                return View(db.Accounts.ToList());
            }
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Account userAccount)
        {
            if(ModelState.IsValid)
            {
                using (QLBMTEntities db = new QLBMTEntities())
                {
                    db.Accounts.Add(userAccount);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = userAccount.Username + "" + userAccount.Password + "Đăng ký thành công";
            }
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Login(Account userAccount)
        {
            using (QLBMTEntities db = new QLBMTEntities())
            {
                var user = db.Accounts.Single(u => u.Username == userAccount.Username && u.Password == userAccount.Password);
                if (user != null)
                {
                    Session["AccountID"] = user.AccountID.ToString();
                    Session["Username"] = user.Username.ToString();
                    return RedirectToAction("LoggedIn");
                }
                else
                {
                    ModelState.AddModelError("", "Sai tài khoản hoặc mật khẩu");
                }
            }
            return View();
        }
        public ActionResult Loggedin()
        {
            if (Session["AccountID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
    }
}