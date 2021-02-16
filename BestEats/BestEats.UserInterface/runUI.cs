using System;

namespace BestEats
{
    class runUI
    {
        static void Main(string[] args)
        {

            Console.WriteLine("keep the debugger from yelling at me for not having a main in UI!");

            UserMenu newMenu = new UserMenu();

            newMenu.StartMenu();
            newMenu.configInput();
            


        }
    }
}
