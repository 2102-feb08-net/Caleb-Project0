﻿using System;
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
       


        // CUSTOMER REPO SECTION *********

        public IEnumerable<Customer> GetCustomer(string name = null)
        {
            throw new NotImplementedException();
        }
        public BestEats.Customer GetCustomerByName(string customerName)
        {
            throw new NotImplementedException();
        }

        public BestEats.Customer GetCustomerByID(int customerID)
        {
            Customer customer = _context.Customers.Find(customerID);
            return new BestEats.Customer
            {
                CustId = customer.CustId,
                FullName = customer.FullName,
                CustPassword = customer.CustPassword
                
            };
        }
        
        public int GetCustomerIDByName(string customerName)
        {

            var idResult = _context.Customers
                .Where(n => n.FullName == customerName)
                .AsEnumerable()
                .First().CustId;

            
            return idResult;
        }
        
        public bool checkCustomerPasswordExists(string userName, string passwordInput)
        {
            bool exists = false;
            var inputCust = _context.Customers
                .Where(u => u.FullName == userName && u.CustPassword == passwordInput).ToList();


            foreach (var c in inputCust)
            {
                exists = true;
            }
            return exists;
        }

        public bool checkCustomerNameExists(string loginInput)
        {
            bool exists = false;
            var inputCust = _context.Customers
                .Where(c => string.Equals(c.FullName, loginInput)).ToList();

            foreach(var c in inputCust)
            {
                exists = true;
            }
            return exists;
        }
        public void RegisterCustomer(BestEats.Customer DBcustomer)
        {
            Customer customer = new Customer
            {
                FullName = DBcustomer.FullName,
                CustPassword = DBcustomer.CustPassword
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


        // STORE REPO SECTION ******
        public Store GetStoreByID(int storeID)
        {
            Store store = _context.Stores.Find(storeID);
            return new Store
            {
                StoreId = store.StoreId,
                StoreLocation = store.StoreLocation
            };
        }

        // PRODUCT REPO SECTION *********

        public Product GetProductByID(int productID)
        {
            Product product = _context.Products.Find(productID);
            return new Product
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                Price = product.Price,
                Orders = product.Orders
            };
        }

        public string GetItemNameByProductID(int productID)
        {

            var itemName = _context.Products
                .Where(n => n.ProductId == productID)
                .AsEnumerable()
                .First().ProductName;


            return itemName;
        }
        public int getNumberOfProductTypes()
        {
            var results = _context.Products;
            int productCount = 0;
            //List<BestEats.Product> inventories = new List<BestEats.Product>();

            foreach (var result in results)
            {
                productCount += 1;
            }
            return productCount;
        }


        // ORDER REPO SECTION **********

        public Order GetOrderByID(int orderID)
        {
            Order order = _context.Orders.Find(orderID);
            return new Order
            {
                OrderId = order.OrderId,
                ItemName = order.ItemName,
                ProductQuantity = order.ProductQuantity,
                ProductId = order.ProductId,
                CustomerId = order.CustomerId,
                StoreId = order.StoreId
            };
        }


        public void AddOrder(BestEats.Order DBorder)
        {
            Order order = new Order
            {
                OrderId = DBorder.OrderId,
                CustomerId = DBorder.CustomerId,
                StoreId = DBorder.StoreId,
                ProductId = DBorder.ProductId,
                ItemName = DBorder.ItemName,
                ProductQuantity = DBorder.ProductQuantity,
                OrderPurchaseDate = DBorder.OrderPurchaseDate
                
                
            };

            _context.Add(order);
        }

        // PACKAGE REPO SECTION

        public List<BestEats.Inventory> GetInventory()
        {
            var results = _context.Inventories;
            List<BestEats.Inventory> inventories = new List<BestEats.Inventory>();

            foreach (var result in results)
            {
                inventories.Add(new BestEats.Inventory(result.StoreId, result.ProductId, result.Amount));
            }
            return inventories;
        }



        // INVENTORY REPO SECTION

        public void Save()
        {
            _context.SaveChanges();
        }

    }
}
