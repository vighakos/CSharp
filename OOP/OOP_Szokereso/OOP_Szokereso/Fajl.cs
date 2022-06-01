using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace OOP_Szokereso
{
    class Fajl
    {
        public static List<string> Beolvas(string fajlNev)
        {
            List<string> adatok = new List<string>();

            try
            {
                StreamReader be = new StreamReader(fajlNev, Encoding.Default);

                while (!be.EndOfStream)
                {
                    adatok.Add(be.ReadLine());
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
