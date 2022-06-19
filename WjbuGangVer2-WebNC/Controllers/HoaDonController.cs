using System;
using System.Linq;
using System.Web.Mvc;
using WjbuGangVer2_WebNC.Models;

namespace WjbuGangVer2_WebNC.Controllers
{
    public class HoaDonController : Controller
    {
        QLBMTEntities _db = new QLBMTEntities();
        // GET: 
        public HoaDon GetHoaDon()
        {
            HoaDon hoadon = Session["HoaDon"] as HoaDon;
            if (hoadon == null)
            {
                hoadon = new HoaDon();
                Session["HoaDon"] = hoadon;
            }
            return hoadon;
        }

        //Phương thức add item
        public ActionResult AddToCart(int id)
        {
            var pro = _db.MatHangs.SingleOrDefault(s => s.MaMH == id);
            if (pro != null)
            {
                GetHoaDon().Add(pro);
            }
            return RedirectToAction("Details","Product", new { id = id});
        }
        public ActionResult CreateOrder(int id)
        {
            var pro = _db.MatHangs.SingleOrDefault(s => s.MaMH == id);
            if (pro != null)
            {
                GetHoaDon().Add(pro);
            }
            //return RedirectToAction("Details", "Product", new { id = id});
            return RedirectToAction("ShowToCart");
        }
        //Trang giỏ hàng
        public ActionResult ShowToCart()
        {
            if (Session["HoaDon"] == null)
                return RedirectToAction("Index", "Product");
            return View(Session["HoaDon"]);
        }
        public ActionResult Update_Quantity_Cart(FormCollection form)
        {
            HoaDon hoadon = Session["HoaDon"] as HoaDon;
            int id_pro = int.Parse(form["Ma_MH"]);
            int quantity = int.Parse(form["Quantity"]);
            hoadon.Update_Quantity_Shopping(id_pro, quantity);
            return RedirectToAction("ShowToCart", "HoaDon");
        }
        public ActionResult RemoveCart(int id)
        {
            HoaDon hoadon = Session["HoaDon"] as HoaDon;
            hoadon.Remove_CartItem(id);
            return RedirectToAction("ShowToCart", "HoaDon");
        }
        public PartialViewResult BagCart()
        {
            int _t_item = 0;
            HoaDon hoadon = Session["HoaDon"] as HoaDon;
            if (hoadon != null)
            {
                _t_item = hoadon.Total_Quantity();
            }
            ViewBag.infoCart = _t_item;
            return PartialView("BagCart");
        }

        public ActionResult ThanhToan()
        {
            return View(Session["HoaDon"]);
        }

        [HttpPost]
        public ActionResult ThanhToan(FormCollection frc)
        {
            QLBMTEntities db = new QLBMTEntities();
            HoaDon _hoadon = new HoaDon();

            var _total = frc["totalprice"];
            var _quantity = frc["quantity"];
            _hoadon.Ngay = DateTime.Now;
            _hoadon.SoLuong = Convert.ToInt32(_quantity);
            _hoadon.TongTien = Convert.ToInt32(_total);
            _hoadon.MaPT = 1;
            _hoadon.AccountID = 1;

            db.HoaDons.Add(_hoadon);
            db.SaveChanges();

            Session["HoaDon"] = null;

            return RedirectToAction("Index", "Product");
        }

        //phương thức thanh toán
        //public ActionResult CheckOut(FormCollection form)
        //{
            //try
            //{
                //HoaDon hoadon = Session["HoaDon"] as HoaDon;
                //HoaDonDetail _other =new HoaDon();
                //_other.Ngay = DateTime.Now;
                //foreach(var item in hoadon.Items)
                //{
                   //HoaDon 
                //}    
            //}
        //}
    }
}