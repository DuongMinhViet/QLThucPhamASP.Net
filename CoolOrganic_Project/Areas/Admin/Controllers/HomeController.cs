using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CoolOrganic_Project.Models.Entity;

namespace CoolOrganic_Project.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Admin/Home
        public QLThucPham_DBContext db = new QLThucPham_DBContext();
        public ActionResult Index()
        {
            if (Session["idAdmin"] != null) { return View(); }
            else
            {
                return RedirectToAction("Login");
            }
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string Username, string Password)
        {
            if (ModelState.IsValid)
            {
                var data = (from p in db.tblAdmins
                            where p.Username.Equals(Username) && p.Password.Equals(Password)
                            select p).ToList();
                if (data.Count() > 0)
                {
                    //add session
                    Session["idAdmin"] = data.FirstOrDefault().idAdmin;
                    Session["Username"] = data.FirstOrDefault().Username;
                    Session["Password"] = data.FirstOrDefault().Password;
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Đănh nhập thất bại";
                    return RedirectToAction("Login");
                }
            }
            return View();
        }
    }
}