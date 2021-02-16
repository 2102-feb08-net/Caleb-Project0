using System;

namespace BestEats
{
    public class Product
    {
        private ItemNameEnum _productName;
        private decimal _itemCost;       // use 0.00m to avoid extra decimals


        // item description?
        // product history? perhaps last time purchased?



        public Product(int _itemCost, ItemNameEnum _productName)
        {
            this.ItemCost = _itemCost;
            this.ProductName = _productName;
        }

        public ItemNameEnum ProductName { get; set; }
        public decimal ItemCost { get; set; }
    }

    public enum ItemNameEnum
    {
        Fighter_Jet,
        Flak_Vest,
        Missile,
        Pistol,
        Pistol_Ammunition,
        Rifle,
        Rifle_ammunition,
        Tank,
        Tank_Shell
    }
}
