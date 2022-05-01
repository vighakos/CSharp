using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace OOP_Berek
{
    class Fajl
    {
        public static List<Ber> Beolvas(string fileName)
        {
            List<Ber> adatok = new List<Ber>();

            try
            {
                StreamReader be = new StreamReader(fileName);
                be.ReadLine();

                while (!be.EndOfStream)
                {
                    adatok.Add(new Ber(be.ReadLine().Split(';')));
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
