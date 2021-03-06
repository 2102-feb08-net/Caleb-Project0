﻿using System;
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
            Console.WriteLine("\nIf you are a new customer, Please register by pressing,         1)");
            Console.WriteLine("If you are an existing customer, Please sign in by entering,    2)");
            Console.WriteLine("If you wish to exit at any time, please enter,                  9)");
        }
        public void StoreMenu()
        {
            Console.WriteLine("Please choose the store location you wish to order from:");
        }

        /// <summary>
        /// runs the RegisterUser, SignInUser methods based on the console print statements from startmenu
        /// </summary>
        /// <param name="baseRepo">DB context query object</param>
        /// <returns> takes username from SignInUser and returns to runUI </returns>
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
        /// <summary>
        /// get the store location of choice. Is also called when you want a change of location
        /// </summary>
        /// <param name="baseRepo">DB Context query object</param>
        /// <returns> number of store location choice, which is the same as the storeID</returns>
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
                    Console.WriteLine("\nselected Northerville");
                    return 1;
                case 2:
                    Console.WriteLine("\nselected Westerville");
                    return 2;
                case 3:
                    Console.WriteLine("\nselected Southerville");
                    return 3;
                case 4:
                    Console.WriteLine("\nselected Easterville");
                    return 4;
                default:
                    Console.WriteLine("\nError with input, shutting off");
                    System.Environment.Exit(-1);
                    return 0;
            }
        }

        /// <summary>
        /// enter a full name/username and a password and save to DB
        /// </summary>
        /// <param name="baseRepo">DB context query object</param>
        public void RegisterUser(BaseRepo baseRepo)
        {
            bool checkRegistering = false;
            int fallBack = 5;
            int count = 0;
            
            Customer newCustomer = new Customer();
            Console.WriteLine("\nPlease enter your full name.");
            while ((checkRegistering == false) && (count <= fallBack))
            {
                newCustomer.FullName = Console.ReadLine();
                checkRegistering = newCustomer.ValidateName(newCustomer);
                count++;
            }
            Console.WriteLine("\nPlease enter a password at least 8 characters long");
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
        /// <summary>
        /// Check if customer name and password exist and match
        /// </summary>
        /// <param name="baseRepo"> db context object</param>
        /// <returns> the user's username </returns>
        public string SignInUser(BaseRepo baseRepo)
        {
            Console.WriteLine("\nTo sign in, Please enter your full name");
            string customerName = Console.ReadLine();
            
            while(baseRepo.checkCustomerNameExists(customerName) == false)
            {
                Console.WriteLine("\nname not found, please enter a valid name or escape with 9");
                customerName = Console.ReadLine();
                if(customerName.StartsWith("9"))
                {
                    System.Environment.Exit(1);
                }
            }

            Console.WriteLine("\nPlease enter your password");
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

        /// <summary>
        /// does the building of an order through user input and saves to DB
        /// </summary>
        /// <param name="baseRepo"> dbcontext point</param>
        /// <param name="storeLocation"> store location that is originally created from StoreMenuInput switch returns </param>
        /// <param name="userName"> user's username that is originally created from the SignInUser method </param>
        public void OrderInput(BaseRepo baseRepo, int storeLocation, string userName)
        {
            int maxProductTypes = 3;
            int maxProductAmount = 100;
            Order placedOrder = new Order();

            placedOrder.CustomerId = baseRepo.GetCustomerIDByName(userName);
            placedOrder.StoreId = storeLocation;
            Console.WriteLine("Please select a number for which item you wish to purchase");
            Console.WriteLine(" 1: Apple ($0.80 each)\n2: Orange ($1.00 each)\n3: Banana ($0.30 each");
            
            string productInput = Console.ReadLine();
            while (productInput.Any(char.IsLetter) || int.Parse(productInput) < 0 || int.Parse(productInput) > maxProductTypes)
            {
                Console.WriteLine("\nPlease insert a valid number choice");
                productInput = Console.ReadLine();
            }
            int productSelect = int.Parse(productInput);
            placedOrder.ProductId = productSelect;
            placedOrder.ItemName = baseRepo.GetItemNameByProductID(placedOrder.ProductId);


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
        /// <summary>
        /// displays menu to place new orders or change stores to order from. has method calls for order input
        /// </summary>
        /// <param name="baseRepo">DB context query object</param>
        /// <param name="storeSelection"> store location created originally from StoreMenuInput</param>
        /// <param name="userName">user's username created originally from SignInUser</param>
        public void OrderingMenu(BaseRepo baseRepo, int storeSelection, string userName)
        {
            
            Console.WriteLine("\nPlease select an action for your account: ");
            Console.WriteLine("To check your package of items,              press,  3)");
            Console.WriteLine("To add an item to your package,              press,  4)");
            Console.WriteLine("To check available inventory from store,     press,  5)");
            Console.WriteLine("To order from a different store,             press,  6)");
            Console.WriteLine("To exit,                                     press,  9)");

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
                    OrderingMenu(baseRepo, storeSelection, userName);
                    break;

                case 5:
                    var storeInventory = baseRepo.GetInventory();
                    Console.WriteLine("Store Inventories:\n");

                    Console.WriteLine($"Store Name: {baseRepo.GetStoreByID(storeSelection).StoreLocation}");

                    for (int a = 0; a < baseRepo.getNumberOfProductTypes(); a++)
                    {
                        Console.WriteLine($"Item: {baseRepo.GetItemNameByProductID(storeInventory[a].ProductId)}" +
                                $"  {storeInventory[a].Amount}");
                    }
                    //storeInventory[storeSelection]
                    /*
                        Console.WriteLine($"Store Name: {baseRepo.GetStoreByID(storeinv.StoreId)}");
                        Console.WriteLine($"Item: {baseRepo.GetItemNameByProductID(storeinv.ProductId)}" +
                            $"  {storeInventory.Amount}");
                    */


                    break;
                    

                case 6:
                    storeSelection = StoreMenuInput(baseRepo);
                    OrderInput(baseRepo, storeSelection, userName);
                    OrderingMenu(baseRepo, storeSelection, userName);
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
