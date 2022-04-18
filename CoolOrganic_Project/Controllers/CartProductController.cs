using CoolOrganic_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CoolOrganic_Project.Models.Entity;

namespace CoolOrganic_Project.Controllers
{
    public class CartProductController : Controller
    {
        QLThucPham_DBContext db = new QLThucPham_DBContext();
        //Lấy ra giỏ hàng
        public Cart GetCart()
        {
            Cart cart = Session["Cart"] as Cart;
            if(cart == null || Session["Cart"] == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }
       //thêm vào giỏ hàng
       public ActionResult AddToCart(int id)
        {
            var product = db.tblProducts.SingleOrDefault(s => s.MaSanPham == id);
            if(product != null)
            {
                GetCart().Add(product);
            }
            return RedirectToAction("ShowToCart", "CartProduct");
        }
        //Hiện sản phẩm lên giỏ hàng 
        public ActionResult ShowToCart()
        {
            if (Session["Cart"] == null) return RedirectToAction("ShowToCart", "CartProduct");
            Cart cart = Session["Cart"] as Cart;
            return View(cart);
        }
        //Cập nhật số lượng của sản phẩm
        public ActionResult Update_Quantity_Cart(FormCollection form)
        {
            Cart cart = Session["Cart"] as Cart;
            int id_product = int.Parse(form["idProduct"]);
            int quantity = int.Parse(form["quantity"]);
            cart.Update_Quantity_Shopping(id_product, quantity);
            return RedirectToAction("ShowToCart", "CartProduct");
        }
        //Xoá sản phẩm trong giỏ hàng
       public ActionResult RemoveCart(int id)
        {
            Cart cart = Session["Cart"] as Cart;
            cart.Remove_CartItem(id);
            return RedirectToAction("ShowToCart", "CartProduct");
        }

        public PartialViewResult BagCart()
        {
            int total_item = 0;
            Cart cart = Session["Cart"] as Cart;
            if(cart != null)
            {
                total_item = cart.Total_Quantity();
            }
            ViewBag.infoCart = total_item;
            return PartialView("BagCart");
        }

        public ActionResult Shopping_Success()
        {
            return View();
        }

        public ActionResult CheckOut()
        {
            Cart cart = Session["Cart"] as Cart;
            //thêm đơn hàng
            tblBill bill = new tblBill();

            cart.ClearCart();
            return RedirectToAction("Shopping_Success", "CartProduct");
        }
       
    }
}