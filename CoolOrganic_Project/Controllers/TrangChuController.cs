using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using CoolOrganic_Project.Models.Entity;

namespace CoolOrganic_Project.Controllers
{
    public class TrangChuController : Controller
    {
        QLThucPham_DBContext db = new QLThucPham_DBContext();
        //// GET: TrangChu
        public ActionResult Index()
        {
            if (Session["MaKhachHang"] != null)
            {
                List<tblProductCategory> list_productcategory = db.tblProductCategories.ToList();
                var product = from p in db.tblProducts
                              where p.MaDanhMuc == 1
                              select p;
                ViewBag.product = product;
                return View("Index",list_productcategory);
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        // GET: Register
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(tblCustomer customer)
        {
            if (ModelState.IsValid)
            {
                var check = db.tblCustomers.FirstOrDefault(s => s.Email == customer.Email);
                if (check == null)
                {
                    customer.Pass = GetMD5(customer.Pass);
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.tblCustomers.Add(customer);
                    db.SaveChanges();
                    return RedirectToAction("Index", "TrangChu");
                }
                else
                {
                    ViewBag.Message = "Email đã tồn tại";
                    return View();
                }
            }
            return View();
        }

        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string email, string pass)
        {
            if (ModelState.IsValid)
            {
                var f_password = GetMD5(pass);
                var data = db.tblCustomers.Where(s => s.Email.Equals(email) && s.Pass.Equals(f_password)).ToList();
                if (data.Count() > 0)
                {
                    //add session
                    Session["TenKhachHang"] = data.FirstOrDefault().TenKhachHang;
                    Session["Email"] = data.FirstOrDefault().Email;
                    Session["MaKhachHang"] = data.FirstOrDefault().MaKhachHang;
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Login failed";
                    return RedirectToAction("Login");
                }
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index");

        }
        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }

        public ActionResult RenderProdcutByID(int CatID)
        {
            QLThucPham_DBContext db = new QLThucPham_DBContext();
            List<tblProduct> list_product = db.tblProducts.Where(x => x.MaDanhMuc == CatID).ToList();
            return PartialView("LoadProductByID", list_product);
        }
        public ActionResult Nav_ProductCategory()
        {
            QLThucPham_DBContext qLThucPham = new QLThucPham_DBContext();
            List<tblProductCategory> list_productcategory = qLThucPham.tblProductCategories.ToList();
            return PartialView("Header", list_productcategory);
        }
    }
}