using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace OOP_Epuletek
{
    class Olvas
    {
        public static List<Epulet> Beolvas(string fileName)
        {
            List<Epulet> adatok = new List<Epulet>();

            try
            {
                StreamReader be = new StreamReader(fileName);
                be.ReadLine();

                while (!be.EndOfStream)
                {
                    adatok.Add(new Epulet(be.ReadLine().Split(';')));
                }

                be.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return adatok;
        }

        public static void Kiir(string fileName, List<Epulet> adatok)
        {
            try
            {
                StreamWriter ki = new StreamWriter(fileName);
                for (int i = 0; i < adatok.Count; i++)
                {
                    ki.WriteLine(adatok[i].String());
                }
                ki.Close();
                Console.WriteLine("\n\tAdatok fájlba írva");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
