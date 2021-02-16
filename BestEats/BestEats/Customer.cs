using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestEats
{
    public class Customer : IHistory
    {
        private string _customerFullName;
        private string _customerPassword;
        private string _customerHistory;

        // order history list?

        public Customer()
        {
        }


        public string CustomerFullName { get; set; }




        public string CustomerPassword
        {
    get { return _customerPassword; }
    set { }

        }
        public string AccessHistory()
        {
            _customerHistory = "5";  // placeholder CHANGE
            return _customerHistory;
        }


        // public class ValidateCustomer : IValidator<Customer>
        //{
        public bool ValidateName(Customer t)
        {
            if (String.IsNullOrEmpty(t.CustomerFullName))
            {
                Console.WriteLine("Please insert a Customer Name");
                return false;
            }
            if (t.CustomerFullName.Any(char.IsDigit))
            {
                Console.WriteLine("Please do not use numbers in the customer name");
                return false;
            }
            if (t.CustomerFullName.Length >= 50)
            {
                Console.WriteLine("Please use a shorter name");
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool ValidatePass(Customer t)
        {
            if (String.IsNullOrEmpty(t.CustomerPassword))
            {
                Console.WriteLine("please insert a password");
                return false;
            }
            if (t.CustomerPassword.Length < 8 || t.CustomerPassword.Length > 80)
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








