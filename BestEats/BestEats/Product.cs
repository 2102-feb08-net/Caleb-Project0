using System;
using System.Collections.Generic;

namespace BestEats
{
    public class Product
    {

        public Product(int _itemCost, ItemNameEnum _productName)
        {
            
            Orders = new HashSet<Order>();
        }

        public int ProductId { get; set; }
        public ItemNameEnum ProductName { get; set; }
        public decimal ItemCost { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }

    public enum ItemNameEnum
    {
        Apple,
        Orange,
        Banana
    }
}
