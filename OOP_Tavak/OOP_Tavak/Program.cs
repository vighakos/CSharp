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

            Console.ReadKey();
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
                    to1 = adatok[i];
                    to2 = adatok[i + 1];
                }
            }

            if (kulonbseg == 0)
            {
                for (int i = 0; i < adatok.Count; i++)
                {

                }
            }

            Console.WriteLine($"2. feladat: {to1.Nev} és {to2.Nev}\n\tKülönbség: {kulonbseg}");
        }

        private static void F1()
        {
            double osszes = adatok.Sum(x => x.Terulet);
            Console.WriteLine($"1. feladat: A Balaton {(adatok.Find(x => x.Nev == "Balaton").Terulet / osszes) * 100:0.00}%-át teszi ki az összes vízfelületnek");
        }
    }
}
