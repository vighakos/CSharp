using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fajlba_ir3_folytonos
{
    class Program
    {
        static List<int> szamok = new List<int>();
        static void Main(string[] args)
        {
            // szám bekér 0 végjelig, megadott számokat adjuk össze
            // és az összeget írjuk ki
            // biztosítsuk, hogy program újbóli futása esetén az előző adatok ne vesszenek el

            ElozetesBeolvas();
            Beker();
            Kiir();

            Console.ReadKey();
        }

        private static void Kiir()
        {
            try
            {
                StreamWriter ki = new StreamWriter("ki.txt");

                for (int i = 0; i < szamok.Count; i++)
                {
                    ki.WriteLine(szamok[i]);
                }
                ki.WriteLine(szamok.Sum());
                ki.Close();
            }
            catch (IOException)
            {
                Console.WriteLine("hiba");
            }
        }

        private static void ElozetesBeolvas()
        {
            try
            {
                StreamReader be = new StreamReader("ki.txt");

                while (!be.EndOfStream)
                {
                    szamok.Add(Convert.ToInt32(be.ReadLine()));
                }
                be.Close();
                szamok.RemoveAt(szamok.Count - 1);
            }
            catch (IOException)
            {
                
            }
        }

        private static void Beker()
        {
            Console.WriteLine("Add meg a számokat");
            int szam = 0;
            do
            {
                szam = Convert.ToInt32(Console.ReadLine());
                if (szam != 0)
                {
                    szamok.Add(szam);
                }
            } while (szam != 0);
        }
    }
}
