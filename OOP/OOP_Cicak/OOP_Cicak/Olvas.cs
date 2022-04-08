using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace OOP_Cicak
{
    class Olvas
    {
        public static List<Cica> Beolvas(string fajlNev)
        {
            List<Cica> adatok = new List<Cica>();

            try
            {
                StreamReader be = new StreamReader(fajlNev);
                be.ReadLine();

                while (!be.EndOfStream)
                {
                    adatok.Add(new Cica(be.ReadLine().Split(';')));
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
