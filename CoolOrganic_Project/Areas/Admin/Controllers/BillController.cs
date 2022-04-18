using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CoolOrganic_Project.Models.Entity;
using CoolOrganic_Project.Models;
namespace CoolOrganic_Project.Areas.Admin.Controllers
{
    public class BillController : Controller
    {
        private QLThucPham_DBContext db = new QLThucPham_DBContext();
        // GET: Bill
        //Danh sách hoá đơn bán
        public ActionResult Index()
        {
            var obj = from p in db.tblBills
                      join q in db.tblCustomers on p.MaKhachHang equals q.MaKhachHang
                      join k in db.tblBillDetails on p.SoHD equals k.SoHD
                      join l in db.tblShippingUnits on k.MaDonVi equals l.MaDonVi
                      select new _Bill()
                      {
                          tmpBill = p,
                          tmpCustomer = q,
                          tmpTransport = l
                      };
            return View("Index", obj.ToList());
        }

    }
}