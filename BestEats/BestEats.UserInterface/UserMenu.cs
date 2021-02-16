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

        public void configInput()
        {
            string menuInput = Console.ReadLine();
            
            switch(Int32.Parse(menuInput))
            {
                case 1:
                    Console.WriteLine("Please enter your full name.");
                    RegisterUser();



                    break;


                default:
                    Console.WriteLine("There was an error with the menu. Shutting off.");
                    break;
            }
        }
        public void RegisterUser()
        {
            bool checkRegistering = false;
            int fallBack = 5;
            int count = 0;
            Customer newCustomer = new Customer();
            
            while ((checkRegistering == false) && (count <= fallBack))
            {
                newCustomer.CustomerFullName = Console.ReadLine();
                count++;
                checkRegistering = newCustomer.ValidateName(newCustomer); 
                Console.WriteLine(checkRegistering);
                Console.WriteLine(count);

            }
        }

        public void signInUser()
        {

        }

            



    }
}
