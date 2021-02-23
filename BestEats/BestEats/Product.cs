﻿using System;

namespace BestEats
{
    public class Product
    {

        // item description?
        // product history? perhaps last time purchased?



        public Product(int _itemCost, ItemNameEnum _productName)
        {
            this.ItemCost = _itemCost;
            this.ProductName = _productName;
        }

        public int ProductId { get; set; }
        public ItemNameEnum ProductName { get; set; }
        public decimal ItemCost { get; set; }
    }

    public enum ItemNameEnum
    {
        Apple,
        Orange,
        Banana
    }
}
