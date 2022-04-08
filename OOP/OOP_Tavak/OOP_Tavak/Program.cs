using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Tavak
{
    class Program
    {
        static List<Tavak> adatok = Olvas.Beolvas("alloviz.txt");
        static void Main(string[] args)
        {
            F1();
            F2();
            F3();
            F4();
            F5();

            Console.ReadKey();
        }

        private static void F5()
        {
            List<Tipusok> tipusok = new List<Tipusok>();

            for (int i = 0; i < adatok.Count; i++)
            {
                if (adatok[i].Tipus != "0")
                {
                    tipusok = Ellenoriz(tipusok, adatok[i].Tipus, adatok[i].Vizgyujto);
                }
            }

            tipusok.OrderBy(x => x.Meret / x.Db).ToList();

            Console.WriteLine("5. feladat: típus szerinti átlagok:");
            for (int i = 0; i < tipusok.Count; i++)
            {
                Console.WriteLine($"\t{tipusok[i].Nev} - {tipusok[i].Meret / tipusok[i].Db}");
            }

        }

        private static List<Tipusok> Ellenoriz(List<Tipusok> tipusok, string tipus, int vizgyujto)
        {
            for (int i = 0; i < tipusok.Count; i++)
            {
                if (tipusok[i].Nev == tipus)
                {
                    tipusok[i].Meret += vizgyujto;
                    tipusok[i].Db++;
                    return tipusok;
                }
            }
            tipusok.Add(new Tipusok(tipus));
            tipusok[tipusok.Count - 1].Meret = vizgyujto;
            return tipusok;
        }

        private static void F4()
        {
            List<Tavak> tavak = new List<Tavak>();

            for (int i = 0; i < adatok.Count; i++)
            {
                if (adatok[i].Nev.ToLower().Contains("tó"))
                {
                    tavak.Add(adatok[i]);
                }
            }

            Console.WriteLine($"4. feladat: {tavak.Sum(x => x.Terulet) * 100 / 93036:0.00}%-át teszik ki");
        }

        private static void F3()
        {
            List<Tavak> legnagyobbak = new List<Tavak>();

            for (int i = adatok.Count-1; i > 0; i--)
            {
                if (!adatok[i].Nev.ToLower().Contains("balaton"))
                {
                    legnagyobbak.Add(adatok[i]);
                }
                if (legnagyobbak.Count == 3) break;
            }

            Console.WriteLine($"3. feladat: 3 legnagyobb vízfelület átlaga: {legnagyobbak.Sum(x => x.Terulet) / 3:0.00}");
        }

        private static void F2()
        {
            double kulonbseg = int.MaxValue;
            Tavak to1 = adatok[0];
            Tavak to2 = adatok[1];

            for (int i = adatok.Count-1; i >= 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (adatok[j].Terulet > adatok[i].Terulet)
                    {
                        Tavak seged = adatok[j];
                        adatok[j] = adatok[i];
                        adatok[i] = seged;

                    }
                }
            }

            for (int i = 0; i < adatok.Count-1; i++)
            {
                if (adatok[i+1].Terulet - adatok[i].Terulet < kulonbseg && adatok[i].Terulet != 0 && adatok[i+1].Terulet != 0)
                {
                    kulonbseg = adatok[i + 1].Terulet - adatok[i].Terulet;
                }
            }

            for (int i = 0; i < adatok.Count-1; i++)
            {
                if (adatok[i].Terulet + kulonbseg == adatok[i+1].Terulet)
                {
                    adatok[i].Egyedi = false;
                    adatok[i + 1].Egyedi = false;
                }
            }

            int osszeg = 0;
            for (int i = 0; i < adatok.Count; i++)
            {
                if (!adatok[i].Egyedi)
                {
                    osszeg++;
                }
            }

            Console.WriteLine($"2. feladat: {osszeg} ilyen tó van");
        }

        private static void F1()
        {
            double osszes = adatok.Sum(x => x.Terulet);
            Console.WriteLine($"1. feladat: A Balaton {(adatok.Find(x => x.Nev == "Balaton").Terulet / osszes) * 100:0.00}%-át teszi ki az összes vízfelületnek");
        }
    }
}
