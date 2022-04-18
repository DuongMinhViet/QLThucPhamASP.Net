namespace CoolOrganic_Project.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblBillDetail
    {
        public int? SoHD { get; set; }

        public int? MaSanPham { get; set; }

        public int? MaDonVi { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SoLuongBan { get; set; }

        public double? KhuyenMai { get; set; }

        public virtual tblBill tblBill { get; set; }

        public virtual tblProduct tblProduct { get; set; }

        public virtual tblShippingUnit tblShippingUnit { get; set; }
    }
}
