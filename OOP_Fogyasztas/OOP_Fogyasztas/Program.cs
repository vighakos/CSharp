using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Fogyasztas
{
    class Program
    {
        static List<Tankolas> tankolasok = Olvas.Beolvas("fogyasztas.txt");
        static void Main(string[] args)
        {
            //Kiir();
            F1();
            F2();
            F3();
            Console.ReadKey();
        }

        private static void F3()
        {
            double max2 = tankolasok.Max(x => x.Fizet / x.Mennyiseg);
            Console.WriteLine($"3. feladat: {tankolasok.Find(x => (x.Fizet / x.Mennyiseg) == max2).Datum.ToShortDateString()} napon {max2:0.00} Ft volt az egységár.");
        }

        private static void F2()
        {
            Console.Write("2. feladat: Adj meg egy évszámot: ");
            string beker = Console.ReadLine();

            List<double> adatok = new List<double>();

            for (int i = 0; i < tankolasok.Count; i++)
            {
                if (beker == tankolasok[i].Datum.Year.ToString())
                {
                    adatok.Add(tankolasok[i].Mennyiseg / tankolasok[i].Tavolsag * 100);
                }
            }

            double atlagfogyi = adatok.Sum() / adatok.Count;

            Console.WriteLine($"\tÁtlag fogyasztás {beker} évben:{atlagfogyi: 0.00}");

        }

        private static void F1()
        {
            Console.WriteLine($"1. feladat: összesen {tankolasok.Sum(x => x.Tavolsag)} km");
        }

        private static void Kiir()
        {
            for (int i = 0; i < tankolasok.Count; i++) Console.WriteLine($"{tankolasok[i].Datum.ToShortDateString()} \t {tankolasok[i].Tavolsag} \t {tankolasok[i].Mennyiseg} \t {tankolasok[i].Fizet} \t {tankolasok[i].Azon}");
            
            Console.WriteLine(tankolasok.Count);
        }
    }
}
