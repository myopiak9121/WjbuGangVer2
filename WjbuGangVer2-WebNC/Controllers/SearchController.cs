using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WjbuGangVer2_WebNC.Models;

namespace WjbuGangVer2_WebNC.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection frc)
        {
            QLBMTEntities db = new QLBMTEntities();
            var _searchstring = frc["searchstring"];
            var searchlist = db.MatHangs.Where(x => x.TenMH.Contains(_searchstring)).ToList();
            return View(searchlist);
        }
    }
}