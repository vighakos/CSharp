using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Toto
{
    class Program
    {
        static List<Toto> adatok = Beolvas.Olvas("toto.txt");
        static void Main(string[] args)
        {
            F3();
            F4();
            F5();
            F6();
            F7();

            Console.ReadKey();
        }

        private static void F7()
        {
            bool volt = false;
            for (int i = 0; i < adatok.Count; i++)
            {
                if (adatok[i].VolteDontetlen()) volt = true;
            }
            string valasz = volt ? "Volt" : "Nem volt";
            Console.WriteLine($"8. feladat: {valasz} döntetlen nélküli forduló");
        }

        private static void F6()
        {
            Console.WriteLine("6. feladat:\n\tLegnagyobb:");
            adatok.Find(x => x.Ny13p1 == adatok.Max(y => y.Ny13p1)).Kiir();
            Console.WriteLine("\n\tLegkisebb:");

            int min_nyeremeny = int.MaxValue;
            for (int i = 0; i < adatok.Count; i++)
            {
                if (min_nyeremeny > adatok[i].Ny13p1 && adatok[i].Ny13p1 > 0)
                {
                    min_nyeremeny = adatok[i].Ny13p1;
                }
            }

            for (int i = 0; i < adatok.Count; i++)
            {
                if (adatok[i].Ny13p1 == min_nyeremeny)
                {
                    adatok[i].Kiir();
                    break;
                }
            }
        }

        private static void F5()
        {
            long ossz = 0;
            for (int i = 0; i < adatok.Count; i++)
            {
                if (adatok[i].T13p1 > 0 && adatok[i].Ny13p1 > 0)
                {
                    ossz += adatok[i].T13p1 * adatok[i].Ny13p1;
                }
            }
            Console.WriteLine($"5. feladat: Átlag: {ossz / adatok.Count} Ft");
        }

        private static void F4()
        {
            Console.WriteLine($"4. feladat: Telitalálatos szelvények száma: {adatok.Sum(x => x.T13p1)} db");
        }

        private static void F3()
        {
            Console.WriteLine($"3. feladat: Az állományban {adatok.Count} forduló adatai találhatók");
        }
    }
}
