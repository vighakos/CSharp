using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Foci
{
    class Program
    {
        static List<Jatekos> jatekosok = Olvas.Beolvas("foci.txt");
        static void Main(string[] args)
        {
            /*ElsoFeladat();
            MasodikFeladat();
            HarmadikFeladat();
            OtodikFeladat();*/
            HatodikFeladat();

            Console.ReadKey();
        }

        private static void HatodikFeladat()
        {
            Console.WriteLine("\n6. feladat:");
            Median();
            Modusz();
        }

        private static void Modusz()
        {
            int[] szamok = new int[jatekosok.Max(x => x.Eletkor) + 1];

            for (int i = 0; i < jatekosok.Count; i++)
            {
                for (int j = 0; j < szamok.Length; j++)
                {
                    if (jatekosok[i].Eletkor == j) szamok[j]++;
                }
            }

            //for (int i = 0; i < szamok.Length; i++) Console.WriteLine($"\t{i} - {szamok[i]}");

            Console.WriteLine($"\n\tMódusz életkor: {szamok.ToList().IndexOf(szamok.Max())}");
        }

        private static void Median()
        {
            RendezKor();
            double median = 0;

            if (jatekosok.Count % 2 == 0) median = jatekosok[jatekosok.Count / 2].Eletkor;
            else median = (jatekosok[jatekosok.Count / 2].Eletkor + jatekosok[(jatekosok.Count / 2) + 1].Eletkor) / 2;

            Console.WriteLine($"\tMedián életkor: {median}");

            for (int i = 0; i < jatekosok.Count; i++)
            {
                if (jatekosok[i].Eletkor == median)
                {
                    Console.WriteLine($"\t{jatekosok[i].Nev}");
                }
            }
        }

        private static void RendezKor()
        {
            for (int i = 0; i < jatekosok.Count; i++)
            {
                for (int j = i; j < jatekosok.Count; j++)
                {
                    if (jatekosok[i].Eletkor > jatekosok[j].Eletkor)
                    {
                        Jatekos seged = jatekosok[i];
                        jatekosok[i] = jatekosok[j];
                        jatekosok[j] = seged;
                    }
                }
            }
        }

        private static void OtodikFeladat()
        {
            Rendezes();

            Console.Write("\n5. feladat: Adj meg egy betűt: ");
            char kezdoBetu = Convert.ToChar(Console.ReadLine().ToUpper());
            int kezdo = -1, 
                vege = -1;

            for (int i = 0; i < jatekosok.Count; i++)
            {
                if (kezdo == -1 && jatekosok[i].Nev[0] == kezdoBetu)
                {
                    kezdo = i;
                    vege = i;
                }
                else if (jatekosok[i].Nev[0] == kezdoBetu) vege = i;
            }
            Console.WriteLine(kezdo == -1 ? "\tNincs ilyen karakterrel kezdődő játékos" : $"\tÖsszesen {vege - kezdo + 1} ilyen játékos van, kezdő index: {kezdo + 1} - {vege + 1}");

        }

        private static void Rendezes()
        {
            for (int i = 0; i < jatekosok.Count; i++)
            {
                for (int j = i; j < jatekosok.Count; j++)
                {
                    if (jatekosok[i].Nev[0] > jatekosok[j].Nev[0])
                    {
                        Jatekos seged = jatekosok[i];
                        jatekosok[i] = jatekosok[j];
                        jatekosok[j] = seged;
                    }
                }
            }
        }

        private static void HarmadikFeladat()
        {
            Console.WriteLine("\n3. feladat: Csapatonkénti játékosok száma: ");

            List<Klub> klubok = new List<Klub>();

            for (int i = 0; i < jatekosok.Count; i++)
            {
                klubok = Tartalmazza(jatekosok[i].Klub, klubok);
            }

            for (int i = 0; i < klubok.Count; i++)
            {
                klubok[i].Jatekosszam = JatekosSzamolo(klubok[i].Nev);
            }

            for (int i = 0; i < klubok.Count; i++)
            {
                Console.WriteLine($"\t{klubok[i].Nev}: {klubok[i].Jatekosszam} fő");
            }
            NegyedikFeladat(klubok);
        }

        private static void NegyedikFeladat(List<Klub> klubok)
        {
            int jatekosokOssz = klubok.Sum(x => x.Jatekosszam);
           
            Console.WriteLine($"\n4. feladat: Összesen {klubok.Count} klubban {jatekosokOssz} játékos");
        }

        private static int JatekosSzamolo(string klubNev)
        {
            int db = 0;
            for (int i = 0; i < jatekosok.Count; i++)
            {
                if (jatekosok[i].Klub.Nev == klubNev) db++;
            }

            return db;
        }

        private static List<Klub> Tartalmazza(Klub klub, List<Klub> klubok)
        {
            bool tartalmazza = false;
            for (int i = 0; i < klubok.Count; i++)
            {
                if (klub.Nev == klubok[i].Nev)
                {
                    tartalmazza = true;
                    break;
                }
            }
            if (!tartalmazza) klubok.Add(klub);
            return klubok;
        }

        private static void MasodikFeladat()
        {
            Console.Write($"\n2. feladat: Adj meg egy kort: ");

            int eletkor = Convert.ToInt32(Console.ReadLine());
            int ossz = 0;

            for (int i = 0; i < jatekosok.Count; i++)
            {
                if (jatekosok[i].Eletkor == eletkor) ossz++;
            }

            Console.WriteLine($"\t{ossz} játékos ennyi idős");
        }

        private static void ElsoFeladat()
        {
            Console.WriteLine($"1. feladat: a fájl {jatekosok.Count} játékost tartalmaz.");
        }
    }
}
