using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CoolOrganic_Project.Models.Entity;
using CoolOrganic_Project.Models;
namespace CoolOrganic_Project.Areas.Admin.Controllers
{
    public class BillDetailController : Controller
    {
        // GET: Admin/BillDetail
        private QLThucPham_DBContext db = new QLThucPham_DBContext();
        // GET: BillDetail
        public ActionResult Index(int SoHD)
        {
            List<tblCustomer> customer = db.tblCustomers.ToList();
            List<tblProduct> product = db.tblProducts.ToList();
            List<tblShippingUnit> transport = db.tblShippingUnits.ToList();
            List<tblBill> bill = db.tblBills.ToList();
            List<tblBillDetail> billdetail = db.tblBillDetails.ToList();
            var inforheader = from p in bill
                              join q in customer on p.MaKhachHang equals q.MaKhachHang
                              where (p.SoHD == SoHD)
                              select new ViewModel()
                              {
                                  customer = q,
                                  bill = p
                              };
            var inforcontent = from p in product
                               join q in billdetail on p.MaSanPham equals q.MaSanPham
                               join k in bill on q.SoHD equals k.SoHD
                               join l in customer on k.MaKhachHang equals l.MaKhachHang
                               where (q.SoHD == SoHD)
                               select new ViewModel()
                               {
                                   product = p,
                                   billdetails = q,
                                   customer = l,
                                   TongTien = Convert.ToDouble(p.DonGiaban * q.SoLuongBan) * Convert.ToDouble(q.KhuyenMai)
                               };

            //Truyền hai đối tượng sang view thông qua ViewBag
            ViewBag.inforheader = inforheader;
            ViewBag.inforcontent = inforcontent;
            return View();
        }
    }
}