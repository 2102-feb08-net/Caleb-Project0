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

            int storeSelection = 0;
            string username;


            // pass object through parameters instead
            newMenu.StartMenu();
            username = newMenu.StartMenuInput(baseRepo);
            
            newMenu.StoreMenu();
            storeSelection = newMenu.StoreMenuInput(baseRepo);
            newMenu.OrderingMenu(storeSelection);

           

        }
    }
}
