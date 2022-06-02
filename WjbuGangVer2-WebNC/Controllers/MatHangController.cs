using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WjbuGangVer2_WebNC.Models;

namespace WjbuGangVer2_WebNC.Controllers
{
    public class MatHangController : Controller
    {
        private QLBMTEntities db = new QLBMTEntities();

        // GET: MatHang
        public ActionResult Index()
        {
           
            var matHangs = db.MatHangs.Include(m => m.LoaiMH);
            return View(matHangs.ToList());
        }

        // GET: MatHang/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MatHang matHang = db.MatHangs.Find(id);
            if (matHang == null)
            {
                return HttpNotFound();
            }
            return View(matHang);
        }

        // GET: MatHang/Create
        [HttpGet]
        public ActionResult Create()
        {
            var list = new List<string>() { "Asus", "Acer", "Dell", "Macbook", "Msi", "CPU" };
            ViewBag.list = list;
            ViewBag.MaLoai = new SelectList(db.LoaiMHs, "MaLoai", "TenLoai");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( MatHang matHang)
        {

            string fileName = Path.GetFileNameWithoutExtension(matHang.ImageFile.FileName);
            string extension = Path.GetExtension(matHang.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            matHang.Hinh1 = "~/Content/Images/" + matHang.Hang + "/"+ fileName;
            fileName = Path.Combine(Server.MapPath("~/Content/Images/"),matHang.Hang, fileName);
            //fileName = Path.GetFullPath(fileName);
            matHang.ImageFile.SaveAs(fileName);

            System.Diagnostics.Debug.WriteLine("filename:" + fileName);

            ViewBag.MaLoai = new SelectList(db.LoaiMHs, "MaLoai", "TenLoai", matHang.MaLoai);

            if (ModelState.IsValid)
            {
                db.MatHangs.Add(matHang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ModelState.Clear();
            return View(matHang);
        }

        // GET: MatHang/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MatHang matHang = db.MatHangs.Find(id);
            if (matHang == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaLoai = new SelectList(db.LoaiMHs, "MaLoai", "TenLoai", matHang.MaLoai);
            return View(matHang);
        }

        // POST: MatHang/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaMH,MaLoai,TenMH,DonGia,MoTa,Hang,HinhChinh,Hinh1,Hinh2,Hinh3,Hinh4")] MatHang matHang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(matHang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaLoai = new SelectList(db.LoaiMHs, "MaLoai", "TenLoai", matHang.MaLoai);
            return View(matHang);
        }

        // GET: MatHang/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MatHang matHang = db.MatHangs.Find(id);
            if (matHang == null)
            {
                return HttpNotFound();
            }
            return View(matHang);
        }

        // POST: MatHang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MatHang matHang = db.MatHangs.Find(id);
            db.MatHangs.Remove(matHang);
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