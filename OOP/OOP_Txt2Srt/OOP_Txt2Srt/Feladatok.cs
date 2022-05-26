using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Txt2Srt
{
    class Feladatok
    {
        static List<IdozitettFelirat> feliratok = Fajl.Beolvas("feliratok.txt");
        public Feladatok()
        {
            _5();
            _7();
            _9();

            Console.ReadKey();
        }

        private static void _5()
        {
            Console.WriteLine($"5. feladat - Feliratok száma: {feliratok.Count / 2}");
        }

        private static void _7()
        {
            Console.WriteLine("7. feladat - Legtöbb szóból álló felirat:");
            Console.WriteLine(feliratok.First(x => x.SzavakSzama() == feliratok.Max(y => y.SzavakSzama())).Felirat);
        }

        private static void _9()
        {
            Fajl.Kiir(feliratok, "felirat.srt");
        }
    }
}
