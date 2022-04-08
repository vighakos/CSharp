using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace OOP_Tavak
{
    class Olvas
    {
        static public List<Tavak> Beolvas(string fajlNev)
        {
            List<Tavak> adatok = new List<Tavak>();

            try
            {
                StreamReader be = new StreamReader(fajlNev);
                be.ReadLine();

                while (!be.EndOfStream)
                {
                    adatok.Add(new Tavak(be.ReadLine()));
                }
                be.Close();
            }
            catch (IOException)
            {
                Console.WriteLine("nem jó");
            }

            return adatok;
        }
    }
}
