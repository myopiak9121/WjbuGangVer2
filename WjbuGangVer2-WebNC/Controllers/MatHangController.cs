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
            var listHang = new List<string>() { "Asus", "Acer", "Dell", "Macbook", "Msi" };
            var listRam = new List<string>() { "8gb", "16gb", "32gb", "64gb" };
            var listHdd = new List<string>() { "128gb", "256gb", "512gb", "1tb" };
            var listHdh = new List<string>() { "Mac", "Linus", "Window 10 64 bit" };

            ViewBag.listHang = listHang;
            ViewBag.listRam = listRam;
            ViewBag.listHdd = listHdd;
            ViewBag.listHdh = listHdh;
            ViewBag.MaLoai = new SelectList(db.LoaiMHs, "MaLoai", "TenLoai");

            MatHang matHang = new MatHang();
            return View(matHang);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MatHang matHang)
        {

            string fileName = Path.GetFileNameWithoutExtension(matHang.ImageFile.FileName);
            string fileName1 = Path.GetFileNameWithoutExtension(matHang.ImageFile1.FileName);
            string fileName2 = Path.GetFileNameWithoutExtension(matHang.ImageFile2.FileName);
            string fileName3 = Path.GetFileNameWithoutExtension(matHang.ImageFile3.FileName);
            string fileName4 = Path.GetFileNameWithoutExtension(matHang.ImageFile4.FileName);



            string extension = Path.GetExtension(matHang.ImageFile.FileName);
            string extension1 = Path.GetExtension(matHang.ImageFile1.FileName);
            string extension2 = Path.GetExtension(matHang.ImageFile2.FileName);
            string extension3 = Path.GetExtension(matHang.ImageFile3.FileName);
            string extension4 = Path.GetExtension(matHang.ImageFile4.FileName);




            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            fileName1 = fileName1 + DateTime.Now.ToString("yymmssfff") + extension1;
            fileName2 = fileName2 + DateTime.Now.ToString("yymmssfff") + extension2;
            fileName3 = fileName3 + DateTime.Now.ToString("yymmssfff") + extension3;
            fileName4 = fileName4 + DateTime.Now.ToString("yymmssfff") + extension4;

            matHang.HinhChinh = "~/Content/Images/" + matHang.Hang + "/" + fileName;
            matHang.Hinh1 = "~/Content/Images/" + matHang.Hang + "/" + fileName1;
            matHang.Hinh2 = "~/Content/Images/" + matHang.Hang + "/" + fileName2;
            matHang.Hinh3 = "~/Content/Images/" + matHang.Hang + "/" + fileName3;
            matHang.Hinh4 = "~/Content/Images/" + matHang.Hang + "/" + fileName4;

            fileName = Path.Combine(Server.MapPath("~/Content/Images/"), matHang.Hang, fileName);
            fileName1 = Path.Combine(Server.MapPath("~/Content/Images/"), matHang.Hang, fileName1);
            fileName2 = Path.Combine(Server.MapPath("~/Content/Images/"), matHang.Hang, fileName2);
            fileName3 = Path.Combine(Server.MapPath("~/Content/Images/"), matHang.Hang, fileName3);
            fileName4 = Path.Combine(Server.MapPath("~/Content/Images/"), matHang.Hang, fileName4);

            matHang.ImageFile.SaveAs(fileName);
            matHang.ImageFile1.SaveAs(fileName1);
            matHang.ImageFile2.SaveAs(fileName2);
            matHang.ImageFile3.SaveAs(fileName3);
            matHang.ImageFile4.SaveAs(fileName4);


            //fileName = Path.GetFullPath(fileName);


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
            var listHang = new List<string>() { "Asus", "Acer", "Dell", "Macbook", "Msi" };
            var listRam = new List<string>() { "8gb", "16gb", "32gb", "64gb" };
            var listHdd = new List<string>() { "128gb", "256gb", "512gb", "1tb" };
            var listHdh = new List<string>() { "Mac", "Linus", "Window 10 64 bit" };

            ViewBag.listHang = listHang;
            ViewBag.listRam = listRam;
            ViewBag.listHdd = listHdd;
            ViewBag.listHdh = listHdh;

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
            var listHang = new List<string>() { "Asus", "Acer", "Dell", "Macbook", "Msi" };
            var listRam = new List<string>() { "8gb", "16gb", "32gb", "64gb" };
            var listHdd = new List<string>() { "128gb", "256gb", "512gb", "1tb" };
            var listHdh = new List<string>() { "Mac", "Linus", "Window 10 64 bit" };

            ViewBag.listHang = listHang;
            ViewBag.listRam = listRam;
            ViewBag.listHdd = listHdd;
            ViewBag.listHdh = listHdh;

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