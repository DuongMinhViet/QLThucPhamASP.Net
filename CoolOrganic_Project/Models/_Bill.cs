using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CoolOrganic_Project.Models.Entity;

namespace CoolOrganic_Project.Models
{
    public class _Bill
    {
        public tblBill tmpBill { get; set; }
        public tblCustomer tmpCustomer { get; set; }
        public tblShippingUnit tmpTransport { get; set; }
    }
}