using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WjbuGangVer2_WebNC.Models;

namespace WjbuGangVer2_WebNC.Controllers
{
    public class GiohangController : Controller
    {
        QLBMTEntities _db = new QLBMTEntities();
        // GET: Giohang
        public HoaDon GetHoaDon()
        {
            HoaDon hoadon=Session["Cart"] as HoaDon;
            if (hoadon == null || Session["Cart"]==null)
            {
                hoadon = new HoaDon();
                Session["Cart"]=hoadon;
            }
            return hoadon;
        }
        //Phương thức add item
        public ActionResult AddtoCart(int id)
        {
            var pro = _db.MatHangs.SingleOrDefault(s => s.MaMH == id);
            if (pro == null)
            {
                GetHoaDon().Add(pro);
            }    
            return RedirectToAction("ShowToCart", "Cart");
        }
        //Trang giỏ hàng
        public ActionResult ShowToCart()
        {
            if (Session["Cart"] == null)
                return RedirectToAction("ShowToCart", "Cart");
            HoaDon giohang=Session["Cart"] as HoaDon ;
            return View(giohang);
        }
    }
}