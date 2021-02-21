using System;
using BestEats;

namespace BestEats
{
    class UserMenu : IUserInput
    {

        
        string IUserInput.GetInput()
        {
            return Console.ReadLine();
        }
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
        public void StartMenuInput()
        {
            string menuInput = Console.ReadLine();
            
            switch(int.Parse(menuInput))
            {
                case 1:
                    
                    RegisterUser();
                    break;
                case 2:
                    SignInUser();
                    break;
                case 9:
                    System.Environment.Exit(1);
                    break;

                default:
                    Console.WriteLine("There was an error with the menu. Shutting off.");
                    break;
            }
        }
        public void StoreMenuInput()
        {
            bool checkRegistering = false;
            int fallBack = 5;
            int count = 0;

            // object likely passed in run function rather than made here
            Store newStore = new Store();

            Console.WriteLine("insert the number by your choice;   1: Northerville  --  2:Westerville  --  3: Southerville  --  4: Easterville ");
            string menuInput = Console.ReadLine();

            while ((checkRegistering == false) && (count <= fallBack))
            {
                // this should test a number of choice not an enum. dummy :(

                //newStore.StoreName = (StoreNameChoice) Enum.Parse(typeof(StoreNameChoice), newStore.StoreName, true);
                checkRegistering = newStore.ValidateName(newStore);
                count++;
            }

            switch (int.Parse(menuInput))
            {
                case 1:
                    if(newStore.StoreLocation.Equals(StoreNameChoice.Northerville))
                    {
                        Console.WriteLine("selected Northerville");
                    }
                    break;

                default:
                    Console.WriteLine("Error with input, shutting off");
                    break;
            }


        }
        public void RegisterUser()
        {
            bool checkRegistering = false;
            int fallBack = 5;
            int count = 0;
            
            // object likely passed in run function rather than made here
            Customer newCustomer = new Customer();

            Console.WriteLine("Please enter your full name.");
            while ((checkRegistering == false) && (count <= fallBack))
            {
                newCustomer.CustomerFullName = Console.ReadLine();
                checkRegistering = newCustomer.ValidateName(newCustomer);
                count++;
            }
            Console.WriteLine("Please enter a password at least 8 characters long");
            count = 0;
            checkRegistering = false;
            while(( checkRegistering == false) && (count <= fallBack))
            {
                newCustomer.CustomerPassword = Console.ReadLine();
                checkRegistering = newCustomer.ValidatePass(newCustomer);
                count++;
            }
        }
        public void SignInUser()
        {
            // check file for user name and password
        }

        public void OrderingMenu()
        {
            Console.WriteLine("Please select an action for your account: ");
            Console.WriteLine("To check your order history, please press,    3");
            Console.WriteLine("To make a new order, please press,    4");
            Console.WriteLine("To delete one of your orders please press,    5");
            Console.WriteLine("To exit,                     please press,    9");
        }

            



    }
}
