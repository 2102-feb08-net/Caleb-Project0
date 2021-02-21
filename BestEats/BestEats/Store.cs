using System;
using System.Collections;
using System.Collections.Specialized;
using System.Collections.Generic;

namespace BestEats
{
	public class Store : IValidator<Store>
	{

		private StoreNameChoice _storeLocation;
        


        public List<Order> StoreOrder { get; set; }


		public StoreNameChoice StoreLocation { get; set; }

        public bool ValidateName(Store t)
        {
            if(Enum.IsDefined(typeof(StoreNameChoice), t.StoreLocation))
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
