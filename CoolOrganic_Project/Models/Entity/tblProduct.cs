namespace CoolOrganic_Project.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblProduct")]
    public partial class tblProduct
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblProduct()
        {
            tblBillDetails = new HashSet<tblBillDetail>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaSanPham { get; set; }

        public int? MaDanhMuc { get; set; }

        [Required]
        [StringLength(100)]
        public string TenSanPham { get; set; }

        [Column(TypeName = "money")]
        public decimal DonGiaban { get; set; }

        public int SoLuong { get; set; }

        [Required]
        [StringLength(30)]
        public string DonViTinh { get; set; }

        public string Anh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblBillDetail> tblBillDetails { get; set; }

        public virtual tblProductCategory tblProductCategory { get; set; }
    }
}
