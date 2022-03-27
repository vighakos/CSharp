using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Muzsika
{
    class Feladat
    {
        public static List<Zene> list = Muvelet.Zenek("file.csv");
        public static void _1()
        {
            //1. feladat: írjuk le a teljes lejatszási időt óó:pp:ss formátumban.
            int h = 0,
                m = 0,
                s = 0,
                tS = 0;
            for (int i = 0; i < list.Count; i++)
            {
                tS += list[i].Ido.Mp + (list[i].Ido.Perc * 60);
            }

            h = tS / 60 / 60;
            m = (tS / 60) - h * 60;
            s = tS -( h * 60 * 60) - m * 60;
            Console.WriteLine($"1. feladat: {h: 00}: {m: 00}:{s: 00}");
        }
        public static void _2()
        {
            //2. feladat: melyik zene a legnépszerűbb? Írjuk ki a címet és az előadót
            int max = 0;
            List<Zene> legnagyobb = new List<Zene>();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Nepszeruseg > max)
                {
                    max = list[i].Nepszeruseg;
                }
            }
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Nepszeruseg == max)
                {
                    legnagyobb.Add(list[i]);
                }
            }
            Console.WriteLine($"2. feladat: a legnépszerűbb zene:\n\t{legnagyobb[0].Eloado} - {legnagyobb[0].Cim}");
            Console.WriteLine();
        }
        public static void _3()
        {
            //3. feladat: készítsünk statisztikát, melyik felhasználó
            //hány százalékban járult hozzá a listában?
            //Készítsünk oszlopdiagramot
            //pl:
            //felhasználó 1. 40% **************
            //felhasználó 2. 60% ****************
            Console.WriteLine("3. feladat:");
            List<string> felhasznalok = new List<string>();
            for (int i = 0; i < list.Count; i++)
            {
                if (!felhasznalok.Contains(list[i].Felhasznalo))
                {
                    felhasznalok.Add(list[i].Felhasznalo);
                }
            }
            double[] csillagok = new double[felhasznalok.Count];
            for (int i = 0; i < felhasznalok.Count; i++)
            {
                int db = 0;
                for (int g = 0; g < list.Count; g++)
                {
                    if (list[g].Felhasznalo == felhasznalok[i])
                    {
                        db++;
                    }
                }
                double esely = 100 * db / list.Count * 0.2;
                csillagok[i] = esely;
            }
            for (int i = 0; i < csillagok.Length; i++)
            {
                string oszlop = oszlopD(csillagok[i]);
                Console.WriteLine($"\t{felhasznalok[i]} {csillagok[i]/0.2}% - {oszlop}");
            }
        }
        public static void _4()
        {
            Console.WriteLine("4. feladat:");
            Console.Write("\tAdj meg egy időt! (start) ");
            Ido start = new Ido(Console.ReadLine().Split(':'));

            Console.Write("\tAdj meg egy időt! (end) ");
            Ido end = new Ido(Console.ReadLine().Split(':'));

            int db = 0;

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Ido.Teljes >= start.Teljes && list[i].Ido.Teljes <= end.Teljes)
                {
                    db++;
                }
            }

            Console.WriteLine($"\n\tÖsszesen {db} db szám van.");
        }
        public static void _5()
        {
            Zene ujzene;
            string sor = "";
            Console.WriteLine("5. feladat:");

            Console.Write("\tAdd meg az előadót: ");
            sor += Console.ReadLine() + ";";

            Console.Write("\tAdd meg a zene címét: ");
            sor += Console.ReadLine() + ";";

            Console.Write("\tAdd meg az album nevét: ");
            sor += Console.ReadLine() + ";";

            Console.Write("\tAdd meg a zene hosszát: ");
            sor += Console.ReadLine() + ";";

            Console.Write("\tAdd meg a felhasználót: ");
            sor += Console.ReadLine() + ";";

            Console.Write("\tAdd meg a népszerűségét: ");
            sor += Console.ReadLine();

            ujzene = new Zene(sor.Split(';'));

            list.Add(ujzene);

            Muvelet.Kiir("file.csv", list);
        }
        public static void _6()
        {
            //HF: Írjuk ki, hány zene albumjában/címében szerepel a Remaster szó
            int db = 0;

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Cim.ToLower().Contains("remaster") || list[i].Album.ToLower().Contains("remaster"))
                {
                    db++;
                }
            }

            Console.WriteLine($"6. feladat: {db} db zenében szerepel a remaster szó");
        }
        private static string oszlopD(double szazalek)
        {
            string s = "";
            for (int i = 0; i < Math.Round(szazalek); i++)
            {
                s += "*";
            }
            return s;
        }
        public Feladat()
        {
            _1();
            _2();
            _3();
            _4();
            _5();
            _6();
        }
    }
}
