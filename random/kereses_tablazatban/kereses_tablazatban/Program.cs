using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kereses_tablazatban
{
    class Program
    {
        public static List<string> adatok = new List<string>();
        static void Main(string[] args)
        {
            BeOlvas("adatok.csv");
            BeKer();

            Console.ReadKey();
        }

        private static void BeKer()
        {
            Console.Write("Adj meg egy sort: ");
            int sor = Convert.ToInt32(Console.ReadLine());

            Console.Write("Adj meg egy oszlopot: ");
            int oszlop = Convert.ToInt32(Console.ReadLine());

            if (sor > adatok.Count)
            {
                Console.WriteLine("NEM JÓ JKSGLABGKAGKL TÚL SOKKKK");
            }
            else if (adatok[0].Split(';').Length < oszlop)
            {
                Console.WriteLine("NEM JÓ JKSGLABGKAGKL TÚL SOKKKK");
            }
            else
            {
                if (adatok[sor - 1].Split(';')[oszlop-1] != "")
                {
                    Console.WriteLine($"A kért adat: {adatok[sor - 1].Split(';')[oszlop - 1]}");
                }
                else
                {
                    Console.WriteLine("Az adott cellában nincs érték");
                }
            }

        }

        private static void BeOlvas(string fajlNev)
        {
            try
            {
                StreamReader be = new StreamReader(fajlNev);
                while (!be.EndOfStream)
                {
                    adatok.Add(be.ReadLine());
                }
                be.Close();
                Console.WriteLine($"Beolvasva {adatok.Count} sor");
            }
            catch (IOException)
            {
                Console.WriteLine("Hiba");
            }
        }
    }
}
