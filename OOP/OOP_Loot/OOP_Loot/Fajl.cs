using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace OOP_Loot
{
    class Fajl
    {
        public static List<Loot> Beolvas(string fileName)
        {
            List<Loot> adatok = new List<Loot>();

            try
            {
                StreamReader be = new StreamReader(fileName);
                be.ReadLine();

                while (!be.EndOfStream)
                {
                    adatok.Add(new Loot(be.ReadLine()));
                }

                be.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return adatok;
        }
    }
}
