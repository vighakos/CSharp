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
            //Console.WriteLine(adatok.Count);

            F1();
            F2();
            F3();
            F4();
            F5();
            F6();
            F7();
            F8();


            Console.ReadKey();
        }

        private static void F8()
        {
            List<Varos> varosok = new List<Varos>();
            varosok.Add(new Varos(adatok[0].Telepules));
            for (int i = 0; i < adatok.Count; i++)
            {
                Ellenorzes(adatok[i], varosok);
            }

            Console.WriteLine("8. feladat: Épületek száma városonként: ");

            varosok = varosok.OrderByDescending(x => x.Db).ToList();
            /*
            for (int i = 0; i < varosok.Count; i++)
			{
                for (int j = 0; j < varosok.Count; j++)
			    {
                    if (varosok[i].Db > varosok[j].Db)
	                {
                        Varos seged = varosok[i];
                        varosok[i] = varosok[j];
                        varosok[j] = seged;
	                }
			    }
			}*/

            for (int i = 0; i < varosok.Count; i++)
            {
                varosok[i].Kiir();
            }

            Console.WriteLine(varosok.Sum(x => x.Db));
        }

        private static List<Varos> Ellenorzes(Epulet epulet, List<Varos> varosok)
        {
            bool talalt = false;
            for (int i = 0; i < varosok.Count; i++)
            {
                if (varosok[i].Nev == epulet.Telepules)
                {
                    talalt = true;
                    varosok[i].Db++;
                }
            }

            if (!talalt)
            {
                varosok.Add(new Varos(epulet.Telepules));
            }

            return varosok;
        }

        private static void F7()
        {
            int db = 0;
            for (int i = 0; i < adatok.Count; i++)
            {
                if (adatok[i].Magassag != 0 && 
                    adatok[i].Emeletek != 0 &&
                    adatok[i].Ev.Kezdet != 0 &&
                    adatok[i].Ev.Veg != 0)
                {
                    db++;
                }
            }

            Console.WriteLine($"7. feladat: {db} épületről ismerünk minden adatot");
        }

        private static void F6()
        {
            string valasz = "";
            do
            {
                Console.Write("\n6. feladat: Szeretnél új épületet felvenni? (I/N) ");
                valasz = Console.ReadLine();

                if (valasz.ToLower() == "i")
                {
                    Epulet ujEpulet;
                    string str = "";

                    Console.WriteLine("\tAdd meg az épület adatait:");

                    Console.Write("\n\tNév: ");
                    str += Console.ReadLine() + ";";

                    Console.Write("\tTelepülés: ");
                    str += Console.ReadLine() + ";";

                    Console.Write("\tMagasság: ");
                    str += Console.ReadLine() + ";";

                    Console.Write("\tEmeletek: ");
                    str += Console.ReadLine() + ";";

                    Console.Write("\tÉpítés kezdete: ");
                    str += Console.ReadLine() + ";";

                    Console.Write("\tÉpítés vége: ");
                    str += Console.ReadLine();

                    ujEpulet = new Epulet(str.Split(';'));
                    adatok.Add(ujEpulet);

                    Olvas.Kiir("epuletek.csv", adatok);
                }
                else break;
            } while (valasz.ToLower() != "i");
        }

        private static void F5()
        {
            Console.Write("5. feladat: Adj meg egy évszámot: ");
            int evszam = Convert.ToInt32(Console.ReadLine());
            bool talalt = false;
            List<Epulet> egyezo = new List<Epulet>();

            for (int i = 0; i < adatok.Count; i++)
            {
                if (adatok[i].Ev.Veg == evszam || adatok[i].Ev.Kezdet == evszam)
                {
                    talalt = true;
                    egyezo.Add(adatok[i]);
                }
            }
            
            if (!talalt)
            {
                int kulonbseg = int.MaxValue;
                int ujevszam = adatok[0].Ev.Veg;
                for (int i = 0; i < adatok.Count; i++)
                {
                    if (adatok[i].Ev.Veg != 0 && adatok[i].Ev.Kezdet != 0)
                    {
                        int vegKul = Math.Abs(adatok[i].Ev.Veg - evszam);
                        int kezdKul = Math.Abs(adatok[i].Ev.Kezdet - evszam);

                        if (vegKul < kulonbseg || kezdKul < kulonbseg)
                        {
                            kulonbseg = vegKul < kezdKul ? vegKul : kezdKul;
                            ujevszam = vegKul < kezdKul ? adatok[i].Ev.Veg : adatok[i].Ev.Kezdet;
                        }
                    }
                }

                for (int i = 0; i < adatok.Count; i++)
                {
                    if (adatok[i].Ev.Veg == ujevszam || adatok[i].Ev.Kezdet == ujevszam)
                    {
                        egyezo.Add(adatok[i]);
                    }
                }
            }

            for (int i = 0; i < egyezo.Count; i++)
            {
                egyezo[i].Kiir();
            }
        }

        private static void F4()
        {
            List<Epulet> sokaig = new List<Epulet>();

            for (int i = 0; i < adatok.Count; i++)
            {
                if (adatok[i].Ev.Veg - adatok[i].Ev.Kezdet >= 50)
                {
                    sokaig.Add(adatok[i]);
                }
            }

            if (sokaig.Count != 0)
            {
                Console.WriteLine($"4. feladat: {sokaig.Count} ilyen épület található:");
                for (int i = 0; i < sokaig.Count; i++)
                {
                    sokaig[i].Kiir();
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("4. feladat: Nem volt ilyen épület");
            }
        }

        private static void F3()
        {
            List<Epulet> magasabbak = new List<Epulet>();
            double ossz = 0;

            for (int i = 0; i < adatok.Count; i++)
            {
                if (adatok[i].Magassag >= 75)
                {
                    magasabbak.Add(adatok[i]);
                    ossz += adatok[i].Magassag;
                }
            }

            Console.WriteLine($"3. feladat: 75 méternél magasabb épületek átlagmagassága: {ossz / magasabbak.Count:0.00}");
        }

        private static void F2()
        {
            double db = 0;

            for (int i = 0; i < adatok.Count; i++)
            {
                if (adatok[i].Telepules.ToLower().Contains("budapest"))
                {
                    db++;
                }
            }

            Console.WriteLine($"2. feladat: Az épületek {db * 100 / adatok.Count:0.00}%-a van Budapesten");
        }

        private static void F1()
        {
            List<string> egyediek = new List<string>();

            for (int i = 0; i < adatok.Count; i++)
            {
                if (!egyediek.Contains(adatok[i].Nev))
                {
                    egyediek.Add(adatok[i].Nev);
                }
            }

            Console.WriteLine($"1. feladat: {egyediek.Count} építmény neve egyedi");
        }
    }
}
