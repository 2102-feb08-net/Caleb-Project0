using System;
using System.Collections.Generic;

#nullable disable

namespace BestEats.DataAccess
{
    public partial class Package
    {
        public int PackageId { get; set; }
        public int CustomerId { get; set; }
        public int StoreId { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
        public virtual Store Store { get; set; }
    }
}
