using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestEats
{
    public class Package
    {
        public int PackageId { get; set; }
        public int CustomerId { get; set; }
        public int StoreId { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }

        public Customer Customer { get; set; }
        public Order Order { get; set; }
        public Product Product { get; set; }
        public Store Store { get; set; }


    }
}
