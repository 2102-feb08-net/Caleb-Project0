using System.Collections.Generic;
using System;
using System.IO;
using System.Reflection;

namespace MunitionsR_Us
{
    class InitialGeneration
    {

        public void GenerateNorthStock()
        {

            // List northStock = new List<ItemNameEnum> {};
            string filename_north = "Northerville.txt";


            //C: \Users\piran\revature\Caleb - Project0\MunitionsR_Us\MunitionsR_Us\logs\Northerville.txt
            //string path = C:\Users\piran\revature\Caleb - Project0\MunitionsR_Us\MunitionsR_Us\logs\Northerville.txt;

            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"logs\Northerville.txt");
            string[] Files = File.ReadAllLines(path);


            foreach(var item in Files)
            {
                Console.WriteLine(item.ToString());
            }
            //Console.WriteLine(Files);
            
            /*
            List<string> fileParsed = new List<string>();

            using (StreamReader readNorth = new StreamReader(@filename_north))
            {
                string fileContent;
                while((fileContent = readNorth.ReadLine()) != null)
                {
                    Console.WriteLine(fileContent);
                }
            }
            */

            // using(StreamWriter genNorth = new StreamWriter("Northerville.txt"))

        }
        


    }
}
