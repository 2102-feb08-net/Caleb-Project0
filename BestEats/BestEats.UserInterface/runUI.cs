using System;
using BestEats.DataAccess;

namespace BestEats.UserInterface
{
    class RunUI
    {
        static void Main(string[] args)
        {
            
            UserMenu newMenu = new UserMenu();
            using var depend = new ContextDepend();
            BaseRepo baseRepo = depend.CreateBaseRepo();

            int storeSelection = 0;
            string username;

            newMenu.StartMenu();
            username = newMenu.StartMenuInput(baseRepo);
            
            newMenu.StoreMenu();
            storeSelection = newMenu.StoreMenuInput(baseRepo);
            
            newMenu.OrderingMenu(baseRepo, storeSelection, username);

           

        }
    }
}
