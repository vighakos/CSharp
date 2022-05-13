using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20220509_vigh_akos
{
    class Feladat
    {
        public static List<Adas> adasok = FileAction.Beolvas("cb.txt");
        public Feladat()
        {
            _2();
            _3();
            _4();
            _6();
            _7();
            _8();

            Console.ReadKey();
        }

        private void _8()
        {
            Dictionary<string, int> soforok = new Dictionary<string, int>();

            foreach (Adas item in adasok)
            {
                Ellenoriz(soforok, item);
            }

            string maxnev = soforok.First(x => x.Value == soforok.Max(y => y.Value)).Key;
            int maxszam = soforok.First(x => x.Value == soforok.Max(y => y.Value)).Value;

            Console.WriteLine($"8. feladat: Legtöbb adást indító sofőr" +
                $"\n\tNév: {maxnev}" +
                $"\n\tAdások száma: {maxszam} alkalom");
        }

        private Dictionary<string, int> Ellenoriz(Dictionary<string, int> soforok, Adas item)
        {
            if (soforok.ContainsKey(item.Nev))
                soforok[item.Nev] += item.AdasDb;
            else
                soforok.Add(item.Nev, item.AdasDb);
            return soforok;
        }

        private void _7()
        {
            List<string> soforok = new List<string>();
            foreach (Adas item in adasok)
            {
                if (!soforok.Contains(item.Nev))
                    soforok.Add(item.Nev);
            }
            Console.WriteLine($"7. feladat: Sofőrök száma: {soforok.Count} fő");
        }

        private void _6()
        {
            FileAction.Kiir(adasok);
        }

        private void _4()
        {
            Console.Write("4. feladat: Kérek egy nevet: ");
            string nev = Console.ReadLine();

            int sum = 0;
            foreach (Adas item in adasok)
            {
                if (item.Nev == nev)
                {
                    sum += item.AdasDb;
                }
            }

            if (sum != 0)
                Console.WriteLine($"\t{nev} {sum}x használta a CB-rádiót.");
            else
                Console.WriteLine("\tNincs ilyen nevű sofőr!");
        }

        private void _3()
        {
            foreach (Adas item in adasok)
            {
                if (item.AdasDb == 4)
                {
                    Console.WriteLine($"3. feladat: Volt 4 adást indító sofőr.");
                    break;
                }
            }
        }

        private void _2()
        {
            Console.WriteLine($"2. feladat: Bejegyzések száma: {adasok.Count} db");
        }
    }
}
