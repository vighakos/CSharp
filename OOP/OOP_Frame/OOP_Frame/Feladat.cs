using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Frame
{
    class Feladat
    {
        public static List<Frame> adatok = Muvelet.Beolvas("adatok.csv");
        public Feladat()
        {
            /*
             * Feladat1: Hány sor van a csv-ben?

                Feladat2: Hány darab framenek NINCS Prime változata?

                Feladat3: Meik framenek van a legtöbb Healt Pointja?

                Feladat4: Meik framenek van a legkevesebb Shield-je és legyen is

                Feladat5: mennyi az átlagos energy pont?

                Feladat6: Hány napig tartana minden framet elkészíteni napokba?

                Feladt 7???:: bekér armor értéket és 
                       írjuk ki az összes aadato ahol nem prime
             */
            _1();
            _2();
            _3();
            _4();
            _5();
            _6();
            _7();
            _8();
        }

        private void _8()
        {
            
        }

        private void _7()
        {
            Console.Write("\n7. feladat: Adj meg egy armor értéket: ");
            int armor = Convert.ToInt32(Console.ReadLine());
            bool talalt = false;

            foreach (Frame item in adatok)
                if (item.Armor == armor && !item.Nev.Contains("Prime"))
                {
                    talalt = true;
                    item.Kiir();
                }

            if (!talalt) Console.WriteLine("\tNem található ilyen jkasél");
        }

        private void _6()
        {
            Console.WriteLine($"\n6. feladat: \n\tMinden frémet {adatok.Sum(x => x.TimeToCraft) / 24} napba kerülne elékszíteni");
        }

        private void _5()
        {
            Console.WriteLine($"\n5. feladat: \n\tÁtlagos energy pont: {adatok.Average(x => x.Energy):0.00}");
        }

        private void _4()
        {
            int min = int.MaxValue,
                index = 0;

            for (int i = 0; i < adatok.Count; i++)
            {
                if (min > adatok[i].Shield && adatok[i].Shield != 0)
                {
                    min = adatok[i].Shield;
                    index = i;
                }
            }
            Console.WriteLine("\n4. feladat:");
            adatok[index].Kiir();
        }

        private void _3()
        {
            Console.WriteLine("\n3. feladat:");
            adatok.Find(x => x.Health == adatok.Max(y => y.Health)).Kiir();
        }

        private void _2()
        {
            int db = adatok.Count - (adatok.Count(x => x.Nev.Contains("Prime")) * 2);

            Console.WriteLine($"2. feladat: \n\t{db} cuccnak nincs prime változata");
        }

        private void _1()
        {
            Console.WriteLine($"1. feladat: \n\t{adatok.Count} adat van");
        }
    }
}
