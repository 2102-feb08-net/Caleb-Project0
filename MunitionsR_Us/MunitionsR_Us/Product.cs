using System;

public class Product
{
    private string _productName;
    private decimal _itemCost;       // use 0.00m to avoid extra decimals
	// item description?
	// product history? perhaps last time purchased?


	public Product()
	{
	}

    public string ProductName { get; set; }
	public decimal ItemCost { get; set; }




}
