using System;

namespace BestEats
{
    class runProgram
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Hello World!");

            Product testItem1 = new Product(100, ItemNameEnum.Rifle);

            Console.WriteLine(testItem1.ItemCost);


            /*
            InitialGeneration genObj = new InitialGeneration();
            genObj.GenerateNorthStock();
            */


        }
    }
}
