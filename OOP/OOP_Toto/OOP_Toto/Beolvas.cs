using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace OOP_Toto
{
    class Beolvas
    {
        static public List<Toto> Olvas(string fajlNev)
        {
            List<Toto> adatok = new List<Toto>();

            try
            {
                StreamReader be = new StreamReader(fajlNev);
                be.ReadLine();

                while (!be.EndOfStream)
                {
                    adatok.Add(new Toto(be.ReadLine()));
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
