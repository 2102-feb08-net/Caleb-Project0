using System;

namespace MunitionsR_Us
{
    class runProgram
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            InitialGeneration genObj = new InitialGeneration();

            genObj.GenerateNorthStock();

        }
    }
}
