using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Nyelvvizsga
{
    class Feladat
    {
        private static List<Vizsga> vizsgak = FileAction.toVizsga(FileAction.ReadFile("vizsgak.csv"));
        private static List<Jelentkezo> jelentkezok = FileAction.toJelentkezo(FileAction.ReadFile("jelentkezesek.csv"));
        public Feladat()
        {
            JelentkezoBeallitas();
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
        {//soroljuk fel a legalább egyszer bukott vizsgázókat
            Console.WriteLine("\n8. feladat: legalább egyszer bukott vizsgázók\n");
            List<string> bukottak = new List<string>();
            for (int i = 0; i < jelentkezok.Count; i++)
            {
                for (int j = 0; j < jelentkezok.Count; j++)
                {
                    if (jelentkezok[i].Nev == jelentkezok[j].Nev &&
                        j != i &&
                        !bukottak.Contains(jelentkezok[i].Nev) &&
                        jelentkezok[i].Vizsga.Nyelv == jelentkezok[j].Vizsga.Nyelv &&
                        jelentkezok[i].Vizsga.Szint == jelentkezok[j].Vizsga.Szint)
                    {
                        bukottak.Add(jelentkezok[i].Nev);
                    }
                }
            }

            foreach (string item in bukottak)
                Console.WriteLine($"\t{item}");
        }

        private void _7()
        {//kérj be egy dátumot, (év, hó, nap),
         //írd az azon a napon vizsgázok nevét, nyelvét, szintjét

            Console.Write("\n7. feladat: Adj meg egy dátumot (yyyy.mm.dd.) ");
            string beker = Console.ReadLine();

            Console.WriteLine("\n\t{0, -20} {1, -7} {2}\n\t-----------------------------------", "Név", "Nyelv", "Szint");

            foreach (Jelentkezo item in jelentkezok)
                if (item.Vizsga.Datum.ToShortDateString().Contains(beker))
                    Console.WriteLine($"\t{item.Nev, -20} {item.Vizsga.Nyelv, -7} {item.Vizsga.Szint}");

        }

        private void _6()
        {
            DateTime legkorabban = vizsgak[0].Datum;

            foreach (Vizsga item in vizsgak)
                if (item.Datum.Hour < legkorabban.Hour)
                    legkorabban = item.Datum;

            Console.WriteLine($"\n6. feladat: \n\t{legkorabban.ToShortDateString()} napon kezdődött legkorábban a vizsga, {legkorabban.Hour}:" + (legkorabban.Minute < 10 ? "0" + legkorabban.Minute : legkorabban.Minute.ToString()) + "-kor");
        }

        private void _5()
        {
            Console.WriteLine("\n5. feladat: ");

            List<Jelentkezo> legidosebbek = jelentkezok.FindAll(x => x.Szul == (jelentkezok.Min(y => y.Szul))).ToList();
            List<Jelentkezo> legfiatalabbak = jelentkezok.FindAll(x => x.Szul == (jelentkezok.Max(y => y.Szul))).ToList();

            Console.WriteLine("\nLegidősebbek: ");
            Console.WriteLine("\n\t{0,-20} {1}\n", "Név", "Kor");
            foreach (Jelentkezo item in legidosebbek)
                Console.WriteLine($"\t{item.Nev, -20} {2022 - item.Szul}");

            Console.WriteLine("\nLegfiatalabbak: ");
            Console.WriteLine("\n\t{0,-20} {1}\n", "Név", "Kor");
            foreach (Jelentkezo item in legfiatalabbak)
                Console.WriteLine($"\t{item.Nev, -20} {2022 - item.Szul}");
        }

        private void _4()
        {
            int min = int.MaxValue;
            int keresett_vizsga = 0;
            Dictionary<int, int> vizsgazok_szama = new Dictionary<int, int>();
            foreach (Jelentkezo item in jelentkezok)
            {
                if (!vizsgazok_szama.ContainsKey(item.Vizsgaszam))
                {
                    vizsgazok_szama.Add(item.Vizsgaszam, 1);
                }
                else
                {
                    vizsgazok_szama[item.Vizsgaszam]++;
                }
            }

            foreach (KeyValuePair<int, int> item in vizsgazok_szama)
            {
                if (item.Value < min)
                {
                    keresett_vizsga = item.Key;
                    min = item.Value;
                }
            }
            Console.WriteLine($"\n4. feladat: \n\tKeresett vizsga: {keresett_vizsga}, {min} fő");
        }

        private void _3()
        {

            Dictionary<string, int> napok = new Dictionary<string, int>();

            for (int i = 0; i < jelentkezok.Count; i++)
            {
                if (!napok.ContainsKey(jelentkezok[i].Vizsga.Datum.ToShortDateString()))
                {
                    napok.Add(jelentkezok[i].Vizsga.Datum.ToShortDateString(), 1);
                }
                else
                {
                    napok[jelentkezok[i].Vizsga.Datum.ToShortDateString()]++;
                }
            }

        }

        private static void _2()
        {
            Console.WriteLine("\n2. feladat:");
            Dictionary<string, int> nyelvek = new Dictionary<string, int>();

            for (int i = 0; i < jelentkezok.Count; i++)
            {
                if (!nyelvek.ContainsKey(jelentkezok[i].Vizsga.Nyelv))
                {
                    nyelvek.Add(jelentkezok[i].Vizsga.Nyelv, 1);
                }
                else
                {
                    nyelvek[jelentkezok[i].Vizsga.Nyelv]++;
                }
            }

            nyelvek = nyelvek.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

            foreach (KeyValuePair<string, int> item in nyelvek)
            {
                Console.WriteLine($"\t{item.Key} - {item.Value}");
            }
        }
    
        private static void _1()
        {
            Console.WriteLine($"1. feladat: \n\tJelentkezők: {jelentkezok.Count}\n\tVizsgák: {vizsgak.Count}");
        }

        private void JelentkezoBeallitas()
        {
            for (int i = 0; i < jelentkezok.Count; i++)
            {
                jelentkezok[i].VizsgaMeghatarozo(vizsgak);
            }
        }

    }
}
