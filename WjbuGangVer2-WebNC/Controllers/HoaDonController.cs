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
            HoaDon hoadon=Session["HoaDon"] as HoaDon;
            int id_pro = int.Parse(form["Ma_MH"]);
            int quantity = int.Parse(form["Quantity"]);
            hoadon.Update_Quantity_Shopping(id_pro, quantity);
            return RedirectToAction("ShowToCart", "HoaDon");
        }
    }
}