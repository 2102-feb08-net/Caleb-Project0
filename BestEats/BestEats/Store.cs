using System;
using System.Collections;
using System.Collections.Specialized;

namespace BestEats
{
	public class Store : IValidator<Store>
	{

		private StoreNameChoice _storeName;
        struct StoreProduct
		{
			public Product item;
			public int stock;
		};

		public StoreNameChoice StoreName { get; set; }

        public bool ValidateName(Store t)
        {
            if(Enum.IsDefined(typeof(StoreNameChoice), t.StoreName))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ValidatePass(Store t)
        {
            throw new NotImplementedException();
        }


        // list of products ---stock
        // store specific order history


    }

	public enum StoreNameChoice
    {
		Northerville,
		Westerville,
		Southerville,
		Easterville
    }
}
