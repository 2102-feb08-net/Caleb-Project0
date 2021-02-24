using System;

namespace BestEats
{
	public class Order
	{

		private string _purchasedByCustomerName;

		public int OrderId { get; set; }
		public int CustomerId { get; set; }
		public int StoreId { get; set; }
		public int ProductId { get; set; }
		public string ItemName { get; set; }
		public int ProductQuantity { get; set; }
		public DateTimeOffset OrderPurchaseDate { get; set; }

		public virtual Customer Customer { get; set; }
		public virtual Product Product { get; set; }
		public virtual Store Store { get; set; }



	}
}
