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


        public void StartMenuInput(BaseRepo baseRepo)
        {
            string menuInput = Console.ReadLine();
            while(menuInput.Any(char.IsLetter))
            {
                Console.WriteLine("insert a valid number choice");
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
                    break;
                case 9:
                    Console.WriteLine("\nShutting Down");
                    System.Environment.Exit(1);
                    break;

                default:
                    
                    Console.WriteLine("Not a valid choice. program ending.");
                    break;
            }
        }
        public void StoreMenuInput(BaseRepo baseRepo)
        {
            bool checkRegistering = false;
            int fallBack = 5;
            int count = 0;

            // object likely passed in run function rather than made here
            Store newStore = new Store();

            Console.WriteLine("insert the number by your choice;   1: Northerville  --  2:Westerville  --  3: Southerville  --  4: Easterville ");
            string menuInput = Console.ReadLine();

            /*
            while ((checkRegistering == false) && (count <= fallBack))
            {
                // this should test a number of choice not an enum. dummy :(

                //newStore.StoreName = (StoreNameChoice) Enum.Parse(typeof(StoreNameChoice), newStore.StoreName, true);
                checkRegistering = newStore.ValidateName(newStore);
                count++;
            }
            */

            while (menuInput.Any(char.IsLetter))
            {
                Console.WriteLine("insert a valid number choice");
                menuInput = Console.ReadLine();
            }

            //if(newStore.StoreLocation.Equals(StoreNameChoice.Northerville)) { Console.WriteLine("selected Northerville"); }
            switch (int.Parse(menuInput))
            {
                case 1:
                    Console.WriteLine("selected Northerville");
                    OrderingMenu(1);                                          
                    break;
                case 2:
                    Console.WriteLine("selected Westerville");
                    OrderingMenu(2);
                    break;
                case 3:
                    Console.WriteLine("selected Southerville");
                    OrderingMenu(3);
                    break;
                case 4:
                    Console.WriteLine("selected Easterville");
                    OrderingMenu(4);
                    break;
                default:
                    Console.WriteLine("Error with input, shutting off");
                    break;
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
            int escape = 0;
            Console.WriteLine("To sign in, Please enter your full name");
            string customerName = Console.ReadLine();
            
            while(baseRepo.checkCustomerNameExists(customerName) == false)
            {
                Console.WriteLine("name not found, please enter a valid name or escape with 9");
                customerName = Console.ReadLine();
                if(escape == 9)
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
                if (escape == 9)
                {
                    System.Environment.Exit(1);
                }
            }

            return customerName;


            //IQueryable<BestEats.DataAccess.Customer> currentUser = baseRepo.GetCustomerByName(customerName);

            /*

            while (currentUser.Equals(false))
            {
                Console.WriteLine("name not found, re-enter a registered name, or press 9 to exit");
                customerName = Console.ReadLine();
                currentUser = baseRepo.GetCustomerByName(customerName);

            }

            Console.WriteLine("Please enter your password");
            string customerPassword = Console.ReadLine();
            currentUser = baseRepo.GetCustomerByPassword(customerPassword);

            while (currentUser == null)
            {

                Console.WriteLine("name not found, re-enter a registered name, or press 9 to exit");
                customerPassword = Console.ReadLine();
                currentUser = baseRepo.GetCustomerByPassword(customerPassword);

            }
            return customerName;

            */

        }

        public void OrderingMenu(int storeSelection)
        {
            Console.WriteLine("Please select an action for your account: ");
            //Console.WriteLine("To check your order history, please press,    3");
            Console.WriteLine("To make a new order, please press,    4");
            Console.WriteLine("To delete one of your orders please press,    5");
            Console.WriteLine("To exit,                     please press,    9");
        }

            



    }
}
