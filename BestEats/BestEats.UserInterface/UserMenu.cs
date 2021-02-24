using System;
using System.Collections.Generic;
using System.Linq;
using BestEats;
using BestEats.DataAccess;


namespace BestEats.UserInterface
{
    class UserMenu
    {

        public void StartMenu()
        {
            Console.WriteLine("Welcome to Best Eats! The tastiest eats you ever ate!");
            Console.WriteLine("If you are a new customer, Please register by pressing,      1");
            Console.WriteLine("If you are an existing customer, Please sign in by entering, 2");
            Console.WriteLine("If you wish to exit at any time, please enter,               9");
        }
        public void StoreMenu()
        {
            Console.WriteLine("Please choose the store location you wish to order from:");
        }

        public string StartMenuInput(BaseRepo baseRepo)
        {
            string menuInput = Console.ReadLine();
            while(menuInput.Any(char.IsLetter))
            {
                Console.WriteLine("Please insert a valid number choice");
                menuInput = Console.ReadLine();
            }

            switch(int.Parse(menuInput))
            {
                case 1:
                    
                    RegisterUser(baseRepo);
                    Console.WriteLine("\nRegistration successful");
                    goto case 2;
                case 2:
                    string username = SignInUser(baseRepo);
                    Console.WriteLine("\n{0}  Signed in.", username );
                    return username;
                case 9:
                    Console.WriteLine("\nShutting Down");
                    System.Environment.Exit(0);
                    return "";
                default:
                    Console.WriteLine("Not a valid choice. program ending.");
                    System.Environment.Exit(1);
                    return "";
                    
            }
        }
        public int StoreMenuInput(BaseRepo baseRepo)
        {

            Console.WriteLine("insert the number by your choice;   1: Northerville  --  2:Westerville  --  3: Southerville  --  4: Easterville ");
            string menuInput = Console.ReadLine();


            while (menuInput.Any(char.IsLetter))
            {
                Console.WriteLine("Please insert a valid number choice");
                menuInput = Console.ReadLine();
            }

            switch (int.Parse(menuInput))
            {
                case 1:
                    Console.WriteLine("selected Northerville");
                    return 1;
                case 2:
                    Console.WriteLine("selected Westerville");
                    return 2;
                case 3:
                    Console.WriteLine("selected Southerville");
                    return 3;
                case 4:
                    Console.WriteLine("selected Easterville");
                    return 4;
                default:
                    Console.WriteLine("Error with input, shutting off");
                    System.Environment.Exit(-1);
                    return 0;
            }
        }


        public void RegisterUser(BaseRepo baseRepo)
        {
            bool checkRegistering = false;
            int fallBack = 5;
            int count = 0;
            
            // object likely passed in run function rather than made here
            Customer newCustomer = new Customer();
            Console.WriteLine("Please enter your full name.");
            while ((checkRegistering == false) && (count <= fallBack))
            {
                newCustomer.FullName = Console.ReadLine();
                checkRegistering = newCustomer.ValidateName(newCustomer);
                count++;
            }
            Console.WriteLine("Please enter a password at least 8 characters long");
            count = 0;
            checkRegistering = false;
            while(( checkRegistering == false) && (count <= fallBack))
            {
                newCustomer.CustPassword = Console.ReadLine();
                checkRegistering = newCustomer.ValidatePass(newCustomer);
                count++;
            }
            baseRepo.RegisterCustomer(newCustomer);
            baseRepo.Save();

        }
        public string SignInUser(BaseRepo baseRepo)
        {
            Console.WriteLine("To sign in, Please enter your full name");
            string customerName = Console.ReadLine();
            
            while(baseRepo.checkCustomerNameExists(customerName) == false)
            {
                Console.WriteLine("name not found, please enter a valid name or escape with 9");
                customerName = Console.ReadLine();
                if(customerName.StartsWith("9"))
                {
                    System.Environment.Exit(1);
                }
            }

            Console.WriteLine("Please enter your password");
            string customerPassword = Console.ReadLine();

            while (baseRepo.checkCustomerPasswordExists(customerName, customerPassword) == false)
            {
                Console.WriteLine("invalid password, please enter a valid name or escape with 9");
                customerPassword = Console.ReadLine();
                if (customerPassword.StartsWith("9"))
                {
                    System.Environment.Exit(1);
                }
            }
            return customerName;


        }

        public void OrderInput(BaseRepo baseRepo, int storeLocation, string userName)
        {
            int maxProductTypes = 3;
            int maxProductAmount = 100;
            Order placedOrder = new Order();

            placedOrder.CustomerId = baseRepo.GetCustomerIDByName(userName);
            placedOrder.StoreId = storeLocation;
            Console.WriteLine("Please select a number for which item you wish to purchase");
            Console.WriteLine(" 1: Apple ($0.80 each) --- 2: Orange ($1.00 each) --- 3: Banana ($0.30 each");
            
            string productInput = Console.ReadLine();
            while (productInput.Any(char.IsLetter) || int.Parse(productInput) < 0 || int.Parse(productInput) > maxProductTypes)
            {
                Console.WriteLine("\nPlease insert a valid number choice");
                productInput = Console.ReadLine();
            }
            int productSelect = int.Parse(productInput);
            placedOrder.ProductId = productSelect;
            placedOrder.ItemName = baseRepo.GetItemNameByOProductID(placedOrder.ProductId);


            Console.WriteLine("Please select a quantity for the item selected.");
            string pQuantityInput = Console.ReadLine();
            while (pQuantityInput.Any(char.IsLetter) || int.Parse(pQuantityInput) < 0 || int.Parse(pQuantityInput) > maxProductAmount)
            {
                Console.WriteLine("\nPlease insert a valid number choice");
                pQuantityInput = Console.ReadLine();
            }
            int pQuantitySelect = int.Parse(pQuantityInput);
            placedOrder.ProductQuantity = pQuantitySelect;

            baseRepo.AddOrder(placedOrder);
            baseRepo.Save();




        }
        public void OrderingMenu(BaseRepo baseRepo, int storeSelection, string userName)
        {
            
            Console.WriteLine("Please select an action for your account: ");
            //Console.WriteLine("To check your order history, please press,    3");
            Console.WriteLine("To make a new order,            please press,  4");
            Console.WriteLine("To delete one of your orders    please press,  5");
            Console.WriteLine("To order from a different store please press,  6");
            Console.WriteLine("To exit,                        please press,  9");

            string menuInput = Console.ReadLine();
            while (menuInput.Any(char.IsLetter))
            {
                Console.WriteLine("\n Please insert a valid number choice");
                menuInput = Console.ReadLine();
            }
            int menuSelect = int.Parse(menuInput);

            switch (int.Parse(menuInput))
            {
                case 4:
                    Console.WriteLine("Making new order\n");
                    OrderInput(baseRepo, storeSelection, userName);
                    break;

                case 9:
                    Console.WriteLine("\nExiting Program.");
                    System.Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("error with menu selection, exiting");
                    break;
            }


        }


    }
}
