using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace CoolOrganic_Project.Models.Entity
{
    public partial class QLThucPham_DBContext : DbContext
    {
        public QLThucPham_DBContext()
            : base("name=QLThucPham_DBContext")
        {
            this.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<tblAdmin> tblAdmins { get; set; }
        public virtual DbSet<tblBill> tblBills { get; set; }
        public virtual DbSet<tblCustomer> tblCustomers { get; set; }
        public virtual DbSet<tblProduct> tblProducts { get; set; }
        public virtual DbSet<tblProductCategory> tblProductCategories { get; set; }
        public virtual DbSet<tblShippingUnit> tblShippingUnits { get; set; }
        public virtual DbSet<tblBillDetail> tblBillDetails { get; set; }
        public virtual DbSet<tblPagination> tblPaginations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tblProduct>()
                .Property(e => e.DonGiaban)
                .HasPrecision(19, 4);
        }
    }
}
