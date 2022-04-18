using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CoolOrganic_Project.Models.Entity;

namespace CoolOrganic_Project.Areas.Admin.Controllers
{
    public class ManageController : ApiController
    {
        private QLThucPham_DBContext db = new QLThucPham_DBContext();
        /*--------------------------------------------  PRODUCT  --------------------------------------------*/
        //0. lấy ra mã sản phẩm cuối cùng hiện có 
        [Route("GetLastProduct")]
        [HttpGet]
        public int LastMaProduct()
        {
            return int.Parse(db.tblProducts.OrderByDescending(x => x.MaSanPham).FirstOrDefault().MaSanPham.ToString());
        }
        //1.Lấy danh sách sản phẩm
        [Route("ListProduct/{Page}")]
        [HttpGet]
        public List<tblProduct> ListProduct(int Page)
        {
            int pageSize = int.Parse((db.tblPaginations.SingleOrDefault(x => x.keyword == "So dong moi trang").value).ToString());
            var product = (from p in db.tblProducts
                           select p).ToList();
            var product_current = product.Skip((Page - 1) * pageSize).Take(pageSize);
            return product_current.ToList();
        }
        //2.Lấy ra sản phẩm theo mã 
        [Route("GetProduct/{MaSanPham}")]
        [HttpGet]
        public tblProduct ThucPham(int MaSanPham)
        {
            return db.tblProducts.FirstOrDefault(x => x.MaSanPham == MaSanPham);
        }
        //3.Lấy danh mục sản phẩm
        [Route("ListCategory")]
        [HttpGet]
        public List<tblProductCategory> ListTheLoai()
        {
            var category = from p in db.tblProductCategories
                           select p;
            return category.ToList();
        }
        //4.Lấy mã danh mục theo tên
        [Route("GetIdCategory/{TenDanhMuc}")]
        [HttpGet]
        public string MaDanhMuc(string TenDanhMuc)
        {
            string s = db.tblProductCategories.SingleOrDefault(x => x.TenDanhMuc == TenDanhMuc).MaDanhMuc.ToString();
            return s;
        }
        //5.Thêm mới một sản phẩm
        [HttpPost]
        public bool InsertNewProduct(int MaSanPham, int MaDanhMuc, string TenSanPham, int DonGiaban, int SoLuong, string DonViTinh, string Anh)
        {
            try
            {
                tblProduct product = new tblProduct();
                product.MaSanPham = MaSanPham;
                product.MaDanhMuc = MaDanhMuc;
                product.TenSanPham = TenSanPham;
                product.DonGiaban = DonGiaban;
                product.SoLuong = SoLuong;
                product.DonViTinh = DonViTinh;
                product.Anh = Anh;
                db.tblProducts.Add(product);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        //6.Sửa thông tin một sản phẩm
        [HttpPut]
        public bool UpdateProduct(int MaSanPham, int MaDanhMuc, string TenSanPham, int DonGiaban, int SoLuong, string DonViTinh, string Anh)
        {
            try
            {
                tblProduct product = db.tblProducts.FirstOrDefault(x => x.MaSanPham == MaSanPham);
                if (product == null) return false;
                else
                {
                    product.MaDanhMuc = MaDanhMuc;
                    product.TenSanPham = TenSanPham;
                    product.DonGiaban = DonGiaban;
                    product.SoLuong = SoLuong;
                    product.DonViTinh = DonViTinh;
                    product.Anh = Anh;
                    db.SaveChanges();
                    return true;
                }
            }
            catch { return false; }
        }
        //7.Xoá thông tin một sản phẩm
        [Route("DeleteProduct/{MaSanPham}")]
        [HttpDelete]
        public bool DeleteProduct(int MaSanPham)
        {
            try
            {
                tblProduct product = db.tblProducts.FirstOrDefault(x => x.MaSanPham == MaSanPham);
                if (product == null) return false;
                else
                {
                    db.tblProducts.Remove(product);
                    db.SaveChanges();
                    return true;
                }
            }
            catch { return false; }
        }
        //8. Tìm kiếm một sản phẩm theo tên gần đúng
        [Route("SearchProduct/{TenSanPham}/{Page}")]
        [HttpGet]
        public List<tblProduct> SearchProduct(string TenSanPham, int Page)
        {
            int pageSize = int.Parse((db.tblPaginations.SingleOrDefault(x => x.keyword == "So dong moi trang").value).ToString());
            var product = (from p in db.tblProducts
                           where p.TenSanPham.Contains(TenSanPham)
                           select p).ToList();
            var product_current = product.Skip((Page - 1) * pageSize).Take(pageSize);
            return product_current.ToList();
        }



        /*--------------------------------------------  TRANSPORT  --------------------------------------------*/
        [Route("GetLastTransPort")]
        [HttpGet]
        public int LastMaTransport()
        {
            return int.Parse(db.tblShippingUnits.OrderByDescending(x => x.MaDonVi).FirstOrDefault().MaDonVi.ToString());
        }
        //9. Lấy ra danh sách các đơn vị vận chuyển
        [Route("Transport")]
        [HttpGet]
        public List<tblShippingUnit> Transport()
        {
            return db.tblShippingUnits.ToList();
        }
        [Route("ListTransport/{Page}")]
        [HttpGet]
        public List<tblShippingUnit> ListTransport(int Page)
        {
            int pageSize = int.Parse((db.tblPaginations.SingleOrDefault(x => x.keyword == "So dong moi trang").value).ToString());
            var table = (from p in db.tblShippingUnits
                         select p).ToList();
            var table_current = table.Skip((Page - 1) * pageSize).Take(pageSize);
            return table_current.ToList();
        }
        // Lấy ra mã đơn vị vận chuyển qua tên
        [Route("GetIdTransport/{TenDonVi}")]
        [HttpGet]
        public string MaDonVi(string TenDonVi)
        {
            string s = db.tblShippingUnits.SingleOrDefault(x => x.TenDonVi == TenDonVi).MaDonVi.ToString();
            return s;
        }
        //10.Lấy thông tin đơn vị thông qua mã 
        [Route("GetTransport/{MaDonVi}")]
        [HttpGet]
        public tblShippingUnit DonVi(int MaDonVi)
        {
            return db.tblShippingUnits.FirstOrDefault(x => x.MaDonVi == MaDonVi);
        }
        //11. Thêm một đơn vị vận chuyển
        [HttpPost]
        public bool InsertNewTransport(int MaDonVi, string TenDonVi)
        {
            try
            {
                tblShippingUnit obj = new tblShippingUnit();
                obj.MaDonVi = MaDonVi;
                obj.TenDonVi = TenDonVi;
                db.tblShippingUnits.Add(obj);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        //12. Chỉnh sửa đơn vị vận chuyển
        [HttpPut]
        public bool UpdateTransport(int MaDonVi, string TenDonVi)
        {
            try
            {
                tblShippingUnit obj = db.tblShippingUnits.FirstOrDefault(x => x.MaDonVi == MaDonVi);
                if (obj == null)
                {
                    return false;
                }
                else
                {
                    obj.TenDonVi = TenDonVi;
                    db.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        //13. Xoá thông tin một đơn vị vận chuyển
        [Route("DeleteTransport/{MaDonVi}")]
        [HttpDelete]
        public bool DeleteTransport(int MaDonVi)
        {
            try
            {
                tblShippingUnit obj = db.tblShippingUnits.FirstOrDefault(x => x.MaDonVi == MaDonVi);
                db.tblShippingUnits.Remove(obj);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }


        ///*--------------------------------------------  CUSTOMER  --------------------------------------------*/
        [Route("GetLastCustomer")]
        [HttpGet]
        public int LastMaCustomer()
        {
            return int.Parse(db.tblCustomers.OrderByDescending(x => x.MaKhachHang).FirstOrDefault().MaKhachHang.ToString());
        }
        //14. Lấy danh sách khách hàng
        [Route("ListCustomer/{Page}")]
        [HttpGet]
        public List<tblCustomer> ListCustomer(int Page)
        {
            int pageSize = int.Parse((db.tblPaginations.SingleOrDefault(x => x.keyword == "So dong moi trang").value).ToString());
            var obj = (from p in db.tblCustomers
                       select p).ToList();
            var table_current = obj.Skip((Page - 1) * pageSize).Take(pageSize);
            return table_current.ToList();
        }
        //15.Lấy thông tin khách hàng qua mã 
        [Route("GetCustomer/{MaKhachHang}")]
        [HttpGet]
        public tblCustomer GetCustomer(int MaKhachHang)
        {
            return db.tblCustomers.FirstOrDefault(x => x.MaKhachHang == MaKhachHang);
        }
        //16. Thêm thông tin khách hàng
        [HttpPost]
        public bool InsertNewCustomer(int MaKhachHang,string TenkhachHang, string SoDienThoai, string Email, string Pass, string DiaChi)
        {
            try
            {
                tblCustomer obj = new tblCustomer();
                obj.MaKhachHang = MaKhachHang;
                obj.TenKhachHang = TenkhachHang;
                obj.SoDienThoai = SoDienThoai;
                obj.Email = Email;
                obj.Pass = Pass;
                obj.DiaChi = DiaChi;
                db.tblCustomers.Add(obj);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        //17. Chỉnh sửa thông tin khách hàng
        [HttpPut]
        public bool UpdateCustomer(int MaKhachHang, string TenkhachHang, string SoDienThoai, string Email, string Pass, string DiaChi)
        {
            try
            {
                tblCustomer obj = db.tblCustomers.FirstOrDefault(x => x.MaKhachHang == MaKhachHang);
                if (obj == null)
                {
                    return false;
                }
                obj.TenKhachHang = TenkhachHang;
                obj.SoDienThoai = SoDienThoai;
                obj.Email = Email;
                obj.Pass = Pass;
                obj.DiaChi = DiaChi;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        //18. Xoá thông tin khách hàng
        [Route("DeleteCustomer/{MaKhachHang}")]
        [HttpDelete]
        public bool DeleteCustomer(int MaKhachHang)
        {
            try
            {
                tblCustomer obj = db.tblCustomers.FirstOrDefault(x => x.MaKhachHang == MaKhachHang);
                if (obj == null) { return false; }
                else
                {
                    db.tblCustomers.Remove(obj);
                    db.SaveChanges();
                    return true;
                }
            }
            catch { return false; }
        }
        //19. Tìm kiếm thông tin khách hàng thông qua tên gần đúng
        [Route("SearchCustomer/{TenKhachHang}/{Page}")]
        [HttpGet]
        public List<tblCustomer> SearchCustomer(string TenKhachHang, int Page)
        {
            int pageSize = int.Parse((db.tblPaginations.SingleOrDefault(x => x.keyword == "So dong moi trang").value).ToString());
            var obj = (from p in db.tblCustomers
                       where p.TenKhachHang.Contains(TenKhachHang)
                       select p).ToList();
            var obj_current = obj.Skip((Page - 1) * pageSize).Take(pageSize);
            return obj_current.ToList();
        }


        /*--------------------------------------------  Product Category  --------------------------------------------*/
        [Route("GetLastCategory")]
        [HttpGet]
        public int LastMaCategory()
        {
            return int.Parse(db.tblProductCategories.OrderByDescending(x => x.MaDanhMuc).FirstOrDefault().MaDanhMuc.ToString());
        }
        //9. Lấy ra danh sách các đơn vị vận chuyển
        [Route("ListCategory/{Page}")]
        [HttpGet]
        public List<tblProductCategory> ListCategory(int Page)
        {
            int pageSize = int.Parse((db.tblPaginations.SingleOrDefault(x => x.keyword == "So dong moi trang").value).ToString());
            var table = (from p in db.tblProductCategories
                         select p).ToList();
            var table_current = table.Skip((Page - 1) * pageSize).Take(pageSize);
            return table_current.ToList();
        }
        //10.Lấy thông tin đơn vị thông qua mã 
        [Route("GetCategory/{MaDanhMuc}")]
        [HttpGet]
        public tblProductCategory DanhMuc(int MaDanhMuc)
        {
            return db.tblProductCategories.FirstOrDefault(x => x.MaDanhMuc == MaDanhMuc);
        }
        //11. Thêm một đơn vị vận chuyển
        [HttpPost]
        public bool InsertNewCategory(int MaDanhMuc, string TenDanhmuc)
        {
            try
            {
                tblProductCategory obj = new tblProductCategory();
                obj.MaDanhMuc = MaDanhMuc;
                obj.TenDanhMuc = TenDanhmuc;
                db.tblProductCategories.Add(obj);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        //12. Chỉnh sửa đơn vị vận chuyển
        [HttpPut]
        public bool UpdateCategory(int MaDanhMuc, string TenDanhMuc)
        {
            try
            {
                tblProductCategory obj = db.tblProductCategories.FirstOrDefault(x => x.MaDanhMuc == MaDanhMuc);
                if (obj == null)
                {
                    return false;
                }
                else
                {
                    obj.TenDanhMuc = TenDanhMuc;
                    db.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        //13. Xoá thông tin một đơn vị vận chuyển
        [Route("DeleteCategory/{MaDanhMuc}")]
        [HttpDelete]
        public bool DeleteCategory(int MaDanhMuc)
        {
            try
            {
                tblProductCategory obj = db.tblProductCategories.FirstOrDefault(x => x.MaDanhMuc == MaDanhMuc);
                db.tblProductCategories.Remove(obj);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /*--------------------------------------------  Bill  --------------------------------------------*/
        //Last bill
        [Route("GetLastBill")]
        [HttpGet]
        public int LastMaBill()
        {
            if (db.tblBills.FirstOrDefault() == null)
            {
                return 1;
            }
            return int.Parse(db.tblBills.OrderByDescending(x => x.SoHD).FirstOrDefault().SoHD.ToString());
        }
    }
}
