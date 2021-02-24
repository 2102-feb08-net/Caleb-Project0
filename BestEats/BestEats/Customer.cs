using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestEats
{
    public class Customer : IValidator<Customer>
    {


        public Customer()
        {
            Orders = new HashSet<Order>();

        }

        public int CustId { get; set; }
        public string FullName { get; set; }
        public string CustPassword { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

        /// <summary>
        /// checks Customer name for null, digit, length of 50 or bigger
        /// </summary>
        /// <param name="t"> takes in Customer Object t</param>
        /// <returns></returns>
        public bool ValidateName(Customer t)
        {
            if (String.IsNullOrEmpty(t.FullName))
            {
                Console.WriteLine("Please insert a Customer Name");
                return false;
            }
            if (t.FullName.Any(char.IsDigit))
            {
                Console.WriteLine("Please do not use numbers in the customer name");
                return false;
            }
            if (t.FullName.Length >= 50)
            {
                Console.WriteLine("Please use a shorter name");
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// checks Customer password for Null and length of 8 - 80
        /// </summary>
        /// <param name="t"> takes in Customer Object, t </param>
        /// <returns></returns>
        public bool ValidatePass(Customer t)
        {
            if (String.IsNullOrEmpty(t.CustPassword))
            {
                Console.WriteLine("please insert a password");
                return false;
            }
            if (t.CustPassword.Length < 8 || t.CustPassword.Length > 80)
            {
                Console.WriteLine("your password should be at least 8 characters and less than 80");
                return false;
            }
            else
            {
                return true;
            }
        }
        // }
    }
}








