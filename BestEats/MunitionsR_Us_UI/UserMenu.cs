using System;

namespace BestEats
{
    class UserMenu : IUserInput
    {

        
        string IUserInput.GetInput()
        {
            return Console.ReadLine();
        }
        public static void StartMenu()
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
                    break;


                default:
                    Console.WriteLine("There was an error with the menu. Shutting off.");
                    break;
            }
        }

        public void registerUser()
        {

        }

        public void signInUser()
        {

        }

            



    }
}
