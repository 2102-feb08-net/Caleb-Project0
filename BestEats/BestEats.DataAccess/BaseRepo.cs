using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using BestEats;

namespace BestEats.DataAccess
{
    public class BaseRepo : ICustomerRepo
    {
        private readonly DB_BestEatsContext _context;
        
        public BaseRepo(DB_BestEatsContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
       


        ///<remark> Customer Related Repos </remark>
        public IEnumerable<Customer> GetCustomers(string name = null)
        {
            throw new NotImplementedException();
        }

        
        public Customer GetCustomerID(int CustomerID)
        {
            throw new NotImplementedException();
        }

        public void RegisterCustomer(BestEats.Customer DBcustomer)
        {
            Customer customer = new Customer
            {
                FullName = DBcustomer.CustomerFullName,
                CustPassword = DBcustomer.CustomerPassword
            };

            _context.Add(customer);
        }

        public void UnregisterCustomer(int customerID)
        {
            Customer customer = _context.Customers.Find(customerID);
            _context.Remove(customer);
        }

        public void UpdateCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// 
        /// </summary>




        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
