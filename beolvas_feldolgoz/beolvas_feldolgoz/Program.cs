using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace beolvas_feldolgoz
{
    class Program
    {
        static List<string> nevek = new List<string>();
        static List<double> eredmenyek = new List<double>();
        static void Main(string[] args)
        {
            BeOlvas();

            //6ározzuk meg, hogy a versenyen hányan indultak
            ElsoFeladat();  
            
            //6ározzuk meg a legmagasabb %-ot elért versenyző nevét és eredményét
            MasodikFeladat();

            //top3 versenyző neve és eredménye
            HarmadikFeladat();

            //név bekér, megnéz létezik-e, milyen eredmény
            NegyedikFeladat();

            Console.ReadKey();
        }

        private static void NegyedikFeladat()
        {
            Console.Write("4. feladat: Adj meg egy nevet: ");
            string nev = Console.ReadLine();
            bool indult = false;

            for (int i = 0; i < nevek.Count; i++)
            {
                if (nev == nevek[i])
                {
                    Console.WriteLine($"\t{nev} indult a versenyen, eredménye: {eredmenyek[i]}");
                    indult = true;
                }
            }

            if (!indult)
            {
                Console.WriteLine($"\t{nev} nem indult a versenyen");
            }


        }

        private static void HarmadikFeladat()
        {
            eredmenyek.Sort();

            Console.WriteLine($"{eredmenyek[641]}, {eredmenyek[640]}, {eredmenyek[639]}");
        }

        private static void MasodikFeladat()
        {
            double maxEredmeny = eredmenyek.Max();
            Console.Write("2. feladat: ");
            for (int i = 0; i < nevek.Count; i++)
            {
                if (eredmenyek[i] == maxEredmeny)
                {
                    Console.WriteLine($"A legtöbb pontot {nevek[i]} érte el, ami {eredmenyek[i]}%");
                }
            }
        }

        private static void ElsoFeladat()
        {
            Console.WriteLine($"1. feladat: A versenyen {nevek.Count} db versenyző indult");
        }

        private static void BeOlvas()
        {
            try
            {
                StreamReader be = new StreamReader("adatok.csv", Encoding.Default);
                be.ReadLine();
                while (!be.EndOfStream)
                {
                    SorFeltores(be.ReadLine());
                }
                be.Close();
                //Kiir();
            }
            catch (IOException)
            {
                Console.WriteLine("Hiba");
            }
        }

        private static void SorFeltores(string sor)
        {
            if (sor.Split(';')[0].Length > 2 && !sor.Split(';')[0].Contains(" "))
            {
                nevek.Add(sor.Split(';')[0]);
                eredmenyek.Add(Convert.ToDouble(sor.Split(';')[1]));
            }
        }

        private static void Kiir()
        {
            Console.WriteLine("A fájl tartalma:\n------------------------");
            for (int i = 0; i < nevek.Count; i++)
            {
                Console.WriteLine($"{nevek[i]}, {eredmenyek[i]}");
            }
        }
    }
}
