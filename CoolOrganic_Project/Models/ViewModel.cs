using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using CoolOrganic_Project.Models.Entity;

namespace CoolOrganic_Project.Models
{
    public class ViewModel
    {
        public tblCustomer customer { get; set; }
        public tblBill bill { get; set; }
        public tblProduct product { get; set; }
        public tblShippingUnit transport { get; set; }
        public tblBillDetail billdetails { get; set; }
        public double TongTien { get; set; }
    }
}