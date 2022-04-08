using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Epuletek
{
    class Program
    {
        public static List<Epulet> adatok = Olvas.Beolvas("epuletek.csv");
        static void Main(string[] args)
        {
            F1(); //1. Hány épületről ismerünk minden adatot?
            F2(); //2. Hány olyan épület van, aminek nem ismétlődik a neve?
            F3(); //3. Az épületek hány százaléka van Budapesten?
            F4(); //4. Írd ki a 75, vagy annál magasabb épületek átlagos magasságát!
            F5(); //5. Volt-e olyan épület, amit 50 évig, vagy annál tovább építettek? Írd ki az adatait/adataikat!
            F6(); //6. Kérj be egy évszámot a felhasználótól! Írd ki az abban, vagy a legközelebbi évben épült épületek adatait! (hibakezelés nem kell)
            F7(); //7. Írd ki városonként az épületek számát! Rendezz csökkenő sorrendben DB szerint!
            F8(); //8. HF: Kérd be egy új épület adatait a felhasználótól és add hozzá az "epuletek.csv" fájlhoz!

            Console.ReadKey();
        }

        private static void F8()
        {
            
        }

        private static void F7()
        {
            List<Varos> varosonkent = new List<Varos>();
            Console.WriteLine("7. feladat: Városonkénti épületek száma:");
            for (int i = 0; i < adatok.Count; i++)
            {
                varosonkent = Ellenoriz(varosonkent, adatok[i]);
            }

            for (int i = 0; i < varosonkent.Count; i++)
            {
                for (int j = i; j < varosonkent.Count; j++)
                {
                    if (varosonkent[j].Db > varosonkent[i].Db)
                    {
                        Varos seged = varosonkent[i];
                        varosonkent[i] = varosonkent[j];
                        varosonkent[j] = seged;
                    }
                }
            }

            for (int i = 0; i < varosonkent.Count; i++)
            {
                varosonkent[i].Kiir();
            }
        }

        private static List<Varos> Ellenoriz(List<Varos> varosonkent, Epulet epulet)
        {
            bool talalt = false;
            for (int i = 0; i < varosonkent.Count; i++)
            {
                if (varosonkent[i].Nev == epulet.Telepules)
                {
                    talalt = true;
                    varosonkent[i].Db++;
                }
            }

            if (!talalt)
            {
                varosonkent.Add(new Varos(epulet.Telepules));
            }

            return varosonkent;
        }

        private static void F6()
        {
            Console.Write("6. feladat: Adj meg egy évszámot! ");
            int evszam = Convert.ToInt32(Console.ReadLine());

            List<Epulet> egyezok = new List<Epulet>();
            bool talalt = false;

            for (int i = 0; i < adatok.Count; i++)
            {
                if (adatok[i].Ev.Kezdo == evszam || adatok[i].Ev.Veg == evszam)
                {
                    talalt = true;
                    egyezok.Add(adatok[i]);
                }
            }

            if (!talalt)
            {
                int kulonbseg = int.MaxValue;
                int ujevszam = adatok[0].Ev.Kezdo;

                for (int i = 0; i < adatok.Count; i++)
                {
                    if (adatok[i].Ev.Kezdo != 0 || adatok[i].Ev.Veg != 0)
                    {
                        int kezdKul = Math.Abs(adatok[i].Ev.Kezdo - evszam);
                        int vegKul = Math.Abs(adatok[i].Ev.Veg - evszam);

                        if (kezdKul < kulonbseg || vegKul < kulonbseg)
                        {
                            kulonbseg = kezdKul < vegKul ? kezdKul : vegKul;
                            ujevszam = kezdKul < vegKul ? adatok[i].Ev.Kezdo : adatok[i].Ev.Veg;
                        }
                    }
                }

                for (int i = 0; i < adatok.Count; i++)
                {
                    if (adatok[i].Ev.Kezdo == ujevszam || adatok[i].Ev.Veg == ujevszam)
                    {
                        egyezok.Add(adatok[i]);
                    }
                }
            }

            for (int i = 0; i < egyezok.Count; i++)
            {
                egyezok[i].Kiir();
            }
        }

        private static void F5()
        {
            Console.WriteLine("5. feladat:");
            for (int i = 0; i < adatok.Count; i++)
            {
                if (adatok[i].Ev.Veg - adatok[i].Ev.Kezdo >= 50)
                {
                    adatok[i].Kiir();
                }
            }
        }

        private static void F4()
        {
            List<Epulet> magasabbak = new List<Epulet>();

            for (int i = 0; i < adatok.Count; i++)
            {
                if (adatok[i].Magassag >= 75)
                {
                    magasabbak.Add(adatok[i]);
                }
            }

            double ossz = 0;
            for (int i = 0; i < magasabbak.Count; i++)
            {
                ossz += magasabbak[i].Magassag;
            }

            Console.WriteLine($"4. feladat: 75 méternél magasabb épületek átlaga: {ossz / magasabbak.Count:0.00}m");
        }

        private static void F3()
        {
            double ossz = 0;
            for (int i = 0; i < adatok.Count; i++)
            {
                if (adatok[i].Telepules.Contains("Budapest"))
                {
                    ossz++;
                }
            }

            Console.WriteLine($"3. feladat: Az épületek {ossz * 100 / adatok.Count}%-a van Budapesten");
        }

        private static void F2()
        {
            int db = 0;
            
            for (int i = 0; i < adatok.Count; i++)
            {
                bool talalat = false;
                for (int j = 0; j < adatok.Count; j++)
                {
                    if (adatok[i].Nev == adatok[j].Nev && i!=j)
                    {
                        talalat = true;
                    }
                }

                if (!talalat)
                {
                    db++;
                }
            }

            Console.WriteLine($"2. feladat: {db} egyedi nevű épület van");
        }

        private static void F1()
        {
            int db = 0;

            for (int i = 0; i < adatok.Count; i++)
            {
                if (adatok[i].Magassag != 0 && 
                    adatok[i].Emeletek != 0 && 
                    adatok[i].Ev.Kezdo != 0 && 
                    adatok[i].Ev.Veg != 0)
                {
                    db++;
                }
            }

            Console.WriteLine($"1. feladat: {db} épületről ismerünk minden adatot"); //végeredmény: 15
        }
    }
}
