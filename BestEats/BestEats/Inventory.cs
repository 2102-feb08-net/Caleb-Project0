using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestEats
{
    public class Inventory
    {
        public Inventory(int storeId, int productId, int amount)
        {
            StoreId = storeId;
            ProductId = productId;
            Amount = amount;
        }

        public int StoreId { get; set; }
        public int ProductId { get; set; }
        public int Amount { get; set; }

        public Product Product { get; set; }
        public Store Store { get; set; }

    }
}
