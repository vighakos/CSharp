using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Cicak
{
    class Program
    {
        public static List<Cica> cicak = Olvas.Beolvas("cica.txt");
        static void Main(string[] args)
        {
            //Console.WriteLine(cicak.Count);

            F1();
            F2();
            F3();
            F5();
            F6();
            F7();
            F8();
            F9();
            F10();
            F11();

            Console.ReadKey();
        }

        private static void F11()
        {
            Console.WriteLine("\n11. feladat:");
            List<Foglalkozas> foglalkozasok = new List<Foglalkozas>();
            bool talalt = false;

            for (int i = 0; i < cicak.Count; i++)
            {
                for (int j = 0; j < foglalkozasok.Count; j++)
                {
                    if (cicak[i].Foglalkozas == foglalkozasok[j].Nev)
                    {
                        talalt = true;
                        foglalkozasok[j].Db++;
                    }
                }

                if (!talalt)
                {
                    foglalkozasok.Add(new Foglalkozas(cicak[i].Foglalkozas));
                }
            }

            for (int i = 0; i < foglalkozasok.Count; i++)
            {
                if (foglalkozasok[i].Db == 1)
                {
                    for (int j = 0; j < cicak.Count; j++)
                    {
                        if (cicak[j].Foglalkozas == foglalkozasok[i].Nev)
                        {
                            cicak[j].Kiir();
                        }
                    }
                }
            }

            
        }

        private static void F10()
        {
            Console.WriteLine("\n10. feladat:");
            string valasz = "";

            do
            {
                Console.Write("\tAdj meg egy nevet: ");
                valasz = Console.ReadLine();

                if (Ellenoriz(valasz))
                {
                    for (int i = 0; i < cicak.Count; i++)
                    {
                        if (cicak[i].Nev == valasz)
                        {
                            cicak[i].Kiir();
                        }
                    }
                }

            } while (!Ellenoriz(valasz));
        }

        private static bool Ellenoriz(string valasz)
        {
            for (int i = 0; i < cicak.Count; i++)
            {
                if (cicak[i].Nev == valasz)
                {
                    return true;
                }
            }

            return false;
        }

        private static void F9()
        {
            List<Kilencedik> fajtak = new List<Kilencedik>();
            for (int i = 0; i < cicak.Count; i++)
            {
                bool belepteme = false;
                for (int j = 0; j < fajtak.Count; j++)
                {
                    if (cicak[i].Fajta == fajtak[j].Fajta)
                    {
                        fajtak[j].Db++;
                        belepteme = true;
                        break;
                    }
                }

                if (!belepteme)
                {
                    fajtak.Add(new Kilencedik(cicak[i].Fajta, 1));
                }
            }

            double min = fajtak[0].Db;
            int index = 0;
            for (int i = 0; i < fajtak.Count; i++)
            {
                if (min > fajtak[i].Db)
                {
                    min = fajtak[i].Db;
                    index = i;
                }
            }

            Console.WriteLine($"\n9. feladat: \n\tA cicák {min * 100 / cicak.Count:0.00}%-a {fajtak[index].Fajta}");
        }

        private static void F8()
        {
            double igen = 0,
                nem = 0;

            for (int i = 0; i < cicak.Count; i++)
            {
                if (cicak[i].Ivar) igen++;
                else nem++;
            }

            Console.WriteLine($"\n7. feladat: \n\tA cicák {igen * 100 / cicak.Count:0.00}%-a ivartalanított, {nem * 100 / cicak.Count:0.00}%-a nem");
        }

        private static void F7()
        {
            Console.WriteLine("=^..^=");
        }

        private static void F6()
        {
            double ossz = 0;
            for (int i = 0; i < cicak.Count; i++)
            {
                if (cicak[i].Foglalkozas == "Informatikus")
                {
                    ossz++;
                }
            }
            Console.WriteLine($"\n6. feladat: \n\t{ossz * 100 / cicak.Count:0.00}%-át teszik ki");
        }

        private static void F5()
        {
            Console.WriteLine($"\n5. feladat: \n\tÁtlag életkor: {cicak.Sum(x => x.Kor) / cicak.Count:0} nap");
        }

        private static void F3()
        {
            Cica min = cicak[0];
            Cica max = cicak[0];

            for (int i = 0; i < cicak.Count; i++)
            {
                if (min.Suly > cicak[i].Suly)
                {
                    min = cicak[i];
                }

                if (max.Suly < cicak[i].Suly)
                {
                    max = cicak[i];
                }
            }
            Console.WriteLine("\n2. feladat: Legkönnyebb és legnagyobb macska adatai: ");
            min.Kiir();
            max.Kiir();
        }

        private static void F2()
        {
            Cica min = cicak[0];
            Cica max = cicak[0];

            for (int i = 0; i < cicak.Count; i++)
            {
                if (min.Kor > cicak[i].Kor)
                {
                    min = cicak[i];
                }

                if (max.Kor < cicak[i].Kor)
                {
                    max = cicak[i];
                }
            }
            Console.WriteLine("\n2. feladat: Legfiatalabb és legöregebb macska adatai: ");
            min.Kiir();
            max.Kiir();
        }

        private static void F1()
        {
            Console.WriteLine($"1. feladat: {cicak.Count} cicussal fogunk megismerkedni");
        }
    }
}
