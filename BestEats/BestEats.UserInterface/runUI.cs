using System;
using BestEats.DataAccess;

namespace BestEats.UserInterface
{
    class runUI
    {
        static void Main(string[] args)
        {
            // logger?
            UserMenu newMenu = new UserMenu();

            using var depend = new ContextDepend();

            BaseRepo baseRepo = depend.CreateBaseRepo();


            // pass object through parameters instead
            newMenu.StartMenu();
            newMenu.StartMenuInput(baseRepo);
            
            newMenu.StoreMenu();
            newMenu.StoreMenuInput(baseRepo);

           

        }
    }
}
