using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WjbuGangVer2_WebNC.Models;

namespace WjbuGangVer2_WebNC.Controllers
{
    public class LoaiMHController : Controller
    {
        private QLBMTEntities db = new QLBMTEntities();

        // GET: LoaiMH
        public ActionResult Index()
        {
            return View(db.LoaiMHs.ToList());
        }

        // GET: LoaiMH/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiMH loaiMH = db.LoaiMHs.Find(id);
            if (loaiMH == null)
            {
                return HttpNotFound();
            }
            return View(loaiMH);
        }

        // GET: LoaiMH/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LoaiMH/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaLoai,TenLoai")] LoaiMH loaiMH)
        {
            if (ModelState.IsValid)
            {
                db.LoaiMHs.Add(loaiMH);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(loaiMH);
        }

        // GET: LoaiMH/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiMH loaiMH = db.LoaiMHs.Find(id);
            if (loaiMH == null)
            {
                return HttpNotFound();
            }
            return View(loaiMH);
        }

        // POST: LoaiMH/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaLoai,TenLoai")] LoaiMH loaiMH)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loaiMH).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(loaiMH);
        }

        // GET: LoaiMH/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiMH loaiMH = db.LoaiMHs.Find(id);
            if (loaiMH == null)
            {
                return HttpNotFound();
            }
            return View(loaiMH);
        }

        // POST: LoaiMH/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LoaiMH loaiMH = db.LoaiMHs.Find(id);
            db.LoaiMHs.Remove(loaiMH);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
