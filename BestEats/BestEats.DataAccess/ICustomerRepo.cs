using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;


namespace BestEats.DataAccess
{
    public interface ICustomerRepo
    {
        IEnumerable<Customer> GetCustomers(string name = null);

        Customer GetCustomerID(int CustomerID);

        void RegisterCustomer(BestEats.Customer customer);

        void UnregisterCustomer(int CustomerID);

        void UpdateCustomer(Customer customer);

        void Save();
    }
}
