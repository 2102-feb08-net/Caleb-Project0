using System;
using System.Collections.Generic;

#nullable disable

namespace BestEats.DataAccess
{
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
            Packages = new HashSet<Package>();
        }

        public int CustId { get; set; }
        public string FullName { get; set; }
        public string CustPassword { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Package> Packages { get; set; }
    }
}
