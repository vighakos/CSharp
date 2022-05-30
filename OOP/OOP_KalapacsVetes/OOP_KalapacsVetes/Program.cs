using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_KalapacsVetes
{
    class Program
    {
        static List<Versenyzo> versenyok = Fajl.Beolvas("Selejtezo2012.txt");
        static void Main(string[] args)
        {
            _5();
            _6();
            _9();
            _10();
            _11();

            Console.ReadKey();
        }

        private static void _5()
        {
            Console.WriteLine($"5. feladat: A aszám amit beolavsdás utén kapounk: {versenyok.Count}");
        }

        private static void _6()
        {
            Console.WriteLine($"6. feladat: {versenyok.Count(x => x.Dobasok[1].Szoveg == "-" || x.Dobasok[2].Szoveg == "-")} fő jutott tovább");
        }

        private static void _9()
        {
            double max = 0;
            foreach (Versenyzo item in versenyok)
            {
                if (item.Dobasok[0].Szam > max) max = item.Dobasok[0].Szam;
                if (item.Dobasok[1].Szam > max) max = item.Dobasok[1].Szam;
                if (item.Dobasok[2].Szam > max) max = item.Dobasok[2].Szam;

            }
            versenyok.First(x => x.Dobasok[0].Szam == max || x.Dobasok[1].Szam == max || x.Dobasok[2].Szam == max).Kiir();
        }

        private static void _10()
        {
            Fajl.Kiir(versenyok);
        }

        private static void _11()
        {
            Dictionary<string, int> kodok = new Dictionary<string, int>();

            foreach (Versenyzo item in versenyok)
            {
                kodok = Vizsgal(kodok, item);
            }

            foreach (KeyValuePair<string, int> item in kodok)
            {
                Console.WriteLine(item.Key + " " + item.Value);
            }
        }

        private static Dictionary<string, int> Vizsgal(Dictionary<string, int> kodok, Versenyzo item)
        {
            if (kodok.ContainsKey(item.Kod))
                kodok[item.Kod]++;
            else
                kodok.Add(item.Kod, 1);

            return kodok;
        }
    }
}