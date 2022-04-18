using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CoolOrganic_Project.Models.Entity;
namespace CoolOrganic_Project.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult getRauCu()
        {
            QLThucPham_DBContext db = new QLThucPham_DBContext();
            var product = from p in db.tblProducts
                          where p.MaDanhMuc == 1
                          select p;
            ViewBag.product = product;
            return View();
        }
        public ActionResult getHoaQua()
        {
            QLThucPham_DBContext db = new QLThucPham_DBContext();
            var product = from p in db.tblProducts
                          where p.MaDanhMuc == 2
                          select p;
            ViewBag.product = product;
            return View();
        }
        public ActionResult getHaiSan()
        {
            QLThucPham_DBContext db = new QLThucPham_DBContext();
            var product = from p in db.tblProducts
                          where p.MaDanhMuc == 3
                          select p;
            ViewBag.product = product;
            return View();
        }
        public ActionResult getCacLoaiHat()
        {
            QLThucPham_DBContext db = new QLThucPham_DBContext();
            var product = from p in db.tblProducts
                          where p.MaDanhMuc == 4
                          select p;
            ViewBag.product = product;
            return View();
        }
        public ActionResult getThucPhamTuoiSong()
        {
            QLThucPham_DBContext db = new QLThucPham_DBContext();
            var product = from p in db.tblProducts
                          where p.MaDanhMuc == 5
                          select p;
            ViewBag.product = product;
            return View();
        }

        public ActionResult RauCuASC()
        {
            QLThucPham_DBContext db = new QLThucPham_DBContext();
            List<tblProduct> list_ASC = db.tblProducts.Where(x => x.MaDanhMuc == 1).OrderBy(x => x.DonGiaban).ToList();
            return PartialView("ProductFilter", list_ASC);
        }
        public ActionResult RauCuDESC()
        {
            QLThucPham_DBContext db = new QLThucPham_DBContext();
            List<tblProduct> list_ASC = db.tblProducts.Where(x => x.MaDanhMuc == 1).OrderByDescending(x => x.DonGiaban).ToList();
            return PartialView("ProductFilter", list_ASC);
        }
        public ActionResult HoaQuaASC()
        {
            QLThucPham_DBContext db = new QLThucPham_DBContext();
            List<tblProduct> list_ASC = db.tblProducts.Where(x => x.MaDanhMuc == 2).OrderBy(x => x.DonGiaban).ToList();
            return PartialView("ProductFilter", list_ASC);
        }
        public ActionResult HoaQuaDESC()
        {
            QLThucPham_DBContext db = new QLThucPham_DBContext();
            List<tblProduct> list_ASC = db.tblProducts.Where(x => x.MaDanhMuc == 2).OrderByDescending(x => x.DonGiaban).ToList();
            return PartialView("ProductFilter", list_ASC);
        }
        public ActionResult HaiSanASC()
        {
            QLThucPham_DBContext db = new QLThucPham_DBContext();
            List<tblProduct> list_ASC = db.tblProducts.Where(x => x.MaDanhMuc == 3).OrderBy(x => x.DonGiaban).ToList();
            return PartialView("ProductFilter", list_ASC);
        }
        public ActionResult HaiSanDESC()
        {
            QLThucPham_DBContext db = new QLThucPham_DBContext();
            List<tblProduct> list_ASC = db.tblProducts.Where(x => x.MaDanhMuc == 3).OrderByDescending(x => x.DonGiaban).ToList();
            return PartialView("ProductFilter", list_ASC);
        }
        public ActionResult CacLoaiHatASC()
        {
            QLThucPham_DBContext db = new QLThucPham_DBContext();
            List<tblProduct> list_ASC = db.tblProducts.Where(x => x.MaDanhMuc == 4).OrderBy(x => x.DonGiaban).ToList();
            return PartialView("ProductFilter", list_ASC);
        }
        public ActionResult CacLoaiHatDESC()
        {
            QLThucPham_DBContext db = new QLThucPham_DBContext();
            List<tblProduct> list_ASC = db.tblProducts.Where(x => x.MaDanhMuc == 4).OrderByDescending(x => x.DonGiaban).ToList();
            return PartialView("ProductFilter", list_ASC);
        }
        public ActionResult ThucPhamTuoiSongASC()
        {
            QLThucPham_DBContext db = new QLThucPham_DBContext();
            List<tblProduct> list_ASC = db.tblProducts.Where(x => x.MaDanhMuc == 5).OrderBy(x => x.DonGiaban).ToList();
            return PartialView("ProductFilter", list_ASC);
        }
        public ActionResult ThucPhamTuoiSongDESC()
        {
            QLThucPham_DBContext db = new QLThucPham_DBContext();
            List<tblProduct> list_ASC = db.tblProducts.Where(x => x.MaDanhMuc == 5).OrderByDescending(x => x.DonGiaban).ToList();
            return PartialView("ProductFilter", list_ASC);
        }
    }
}