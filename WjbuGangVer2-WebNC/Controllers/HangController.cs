using PagedList;
using PagedList.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WjbuGangVer2_WebNC.Models;

namespace WjbuGangVer2_WebNC.Controllers
{
    public class HangController : Controller
    {
        QLBMTEntities db = new QLBMTEntities();
        // GET: Hang
        public ActionResult Index(string id)
        {
            var ds = db.MatHangs.Where(x => x.Hang == id);
            return View(ds);
        }
    }
}