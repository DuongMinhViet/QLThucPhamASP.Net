namespace CoolOrganic_Project.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblPagination")]
    public partial class tblPagination
    {
        [Key]
        [StringLength(50)]
        public string keyword { get; set; }

        public int? value { get; set; }
    }
}
