using System;

namespace BestEats
{
    public class Customer : IHistory
    {
        private string _customerFirstName;
        private string _customerLastName;
        private string _customerPassword;
        private string _customerHistory;

        // order history list?

        public Customer()
        {
        }

        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }    // restrictions on set for names
        public string CustomerPassword
        {
            set
            {
                _customerPassword = value;
            }
        }
        public string AccessHistory()
        {
            _customerHistory = "5";  // placeholder CHANGE
            return _customerHistory;
        }

    }
}







