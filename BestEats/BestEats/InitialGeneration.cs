using System.Collections.Generic;
using System;
using System.IO;
using System.Reflection;
using System.Linq;

namespace BestEats
{
    class InitialGeneration
    {
       

        public void GenerateNorthStock()
        {

            /* List northStock = new List<ItemNameEnum> {};
            string filename_north = "Northerville.txt";
            int lineEntries = 2;
            */

            //C: \Users\piran\revature\Caleb - Project0\MunitionsR_Us\MunitionsR_Us\logs\Northerville.txt
            //string path = C:\Users\piran\revature\Caleb - Project0\MunitionsR_Us\MunitionsR_Us\logs\Northerville.txt;

            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"logs\Northerville.txt");
            string[] Files = File.ReadAllLines(path);


            // writing to file

               // ItemNameEnum[] itemNames = (ItemNameEnum[])Enum.GetValues(typeof(ItemNameEnum));
                

                string[] itemNames1 = (string[])Enum.GetNames(typeof(ItemNameEnum));

            using StreamWriter fileWriter = new(path, append: true);
            {
            }

                // check text file for object enum name and object amount
                // create missing items to text file


                /*
                Console.WriteLine(Files.Length);
                for (int t = 0; t < Files.Length; t++)   // line by line
                {

                
                    for (int x = 0; x < lineEntries; x++)   // lines will only have 2 entries, name and amount
                    {
                        Console.WriteLine(itemNames1[x]);
                        if (Files[x].Contains(itemNames1[x]))
                        {
                            fileWriter.WriteLine(itemNames[x]);
                        }

                    }
                }
            }
                */

                /*
                foreach (var item in Files)
            {
                Console.WriteLine(item.ToString());
            }

            //Console.WriteLine(Files);
            
            
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
