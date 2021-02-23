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
        IEnumerable<Customer> GetCustomer(string name = null);

        BestEats.Customer GetCustomerByID(int customerID);

        BestEats.Customer GetCustomerByName(string customerName);
        void RegisterCustomer(BestEats.Customer customer);

        void UnregisterCustomer(int customerID);

        void UpdateCustomer(Customer customer);

        void Save();
    }
}
