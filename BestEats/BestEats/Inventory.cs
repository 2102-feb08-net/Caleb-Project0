using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestEats
{
    class Inventory
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
