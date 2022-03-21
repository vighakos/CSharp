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
            //F4();
            F4_2();
            F5();
            Console.ReadKey();
        }

        private static void F5()
        {
            int elteres = Kivonas(tankolasok[1].Datum, tankolasok[0].Datum);
            int index = 0;
            for (int i = 1; i < tankolasok.Count; i++)
            {
                if (elteres < Kivonas(tankolasok[i].Datum, tankolasok[i - 1].Datum))
                {
                    elteres = Kivonas(tankolasok[i].Datum, tankolasok[i - 1].Datum);
                    index = i;
                }
            }

            Console.WriteLine($"5. feladat:");
            tankolasok[index].Kiir();
            tankolasok[index - 1].Kiir();
            Console.WriteLine($"\tEltelt napok: {elteres}");
        }

        private static int Kivonas(DateTime mibol, DateTime mit)
        {
            int kulonbseg = 0;
            if (mibol.Year != mit.Year)
            {
                DateTime seged = new DateTime(mit.Year, 12, 31);
                kulonbseg = seged.DayOfYear - mit.DayOfYear;
                kulonbseg += mibol.DayOfYear;
            }
            else
            {
                kulonbseg = mibol.DayOfYear - mit.DayOfYear;
            }

            return kulonbseg;
        }

        private static void F4_2()
        {
            List<Kut> benzinkutak = new List<Kut>();

            for (int i = 0; i < tankolasok.Count; i++)
            {
                benzinkutak = Ellenorzes(benzinkutak, tankolasok[i]);
            }
            Console.WriteLine($"4. feladat: {benzinkutak.Find(x => x.Osszeg == benzinkutak.Max(y => y.Osszeg)).Azon} benzinkúton {benzinkutak.Max(x => x.Osszeg):0 000 000} Ft");
            
        }

        private static List<Kut> Ellenorzes(List<Kut> benzinkutak, Tankolas tankolas)
        {
            bool talalat = false;
            for (int i = 0; i < benzinkutak.Count; i++)
            {
                if (benzinkutak[i].Azon == tankolas.Azon)
                {
                    benzinkutak[i].HozzaAd(tankolas.Fizet);
                    talalat = true;
                    break;
                }
            }

            if (!talalat) benzinkutak.Add(new Kut(tankolas.Azon, tankolas.Fizet));

            return benzinkutak;
        }

        private static void F4()
        {
            List<string> benzinkutak = new List<string>();
            for (int i = 0; i < tankolasok.Count; i++)
            {
                if (!benzinkutak.Contains(tankolasok[i].Azon))
                {
                    benzinkutak.Add(tankolasok[i].Azon);
                }
            }
            int[] szamok = new int[benzinkutak.Count];

            for (int i = 0; i < tankolasok.Count; i++)
            {
                for (int j = 0; j < benzinkutak.Count; j++)
                {
                    if (tankolasok[i].Azon.Equals(benzinkutak[j]))
                    {
                        szamok[j] += tankolasok[i].Fizet;
                    }
                }
            }

            Console.WriteLine($"4. feladat: Legtöbb pénz: {benzinkutak[szamok.ToList().IndexOf(szamok.Max())]}, {szamok.Max()} Ft");
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
