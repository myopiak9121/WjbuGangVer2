using PagedList;
using PagedList.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WjbuGangVer2_WebNC.Models;

namespace WjbuGangVer2_WebNC.Controllers
{
    public class ProductController : Controller
    {
        QLBMTEntities db = new QLBMTEntities();
        // GET: Product
        public ActionResult Index(int page = 1, int pagesize = 16)
        {
            var list = db.MatHangs.ToList().ToPagedList(page, pagesize);
            return View(list);
        }

        // GET: ProductNSX
        public ActionResult IndexNSX(string name)
        {
            var list = db.MatHangs.Where(x => x.Hang == name).ToList();
            Session["nsxbanner"] = "/Content/Images/Banner/" + name + "banner.jpg";
            Session["nsxbannerleft"] = "/Content/Images/Banner/" + name + "left.jpg";
            Session["nsxbannerright"] = "/Content/Images/Banner/" + name + "right.jpg";
            Session["nsxbannerright1"] = "/Content/Images/Banner/" + name + "right1.jpg";
            Session["nsxbannerright2"] = "/Content/Images/Banner/" + name + "right2.jpg";
            return View(list);
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            MatHang chitiet = db.MatHangs.Find(id);
            return View(chitiet);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
