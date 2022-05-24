using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dolgozat_Vigh_Akos
{
    class Program
    {
        static PlayfairKodolo kodolo = new PlayfairKodolo("kulcstabla.txt");
        static void Main(string[] args)
        {
            _6();
            _8();

            Console.ReadKey();
        }

        private static void _6()
        {
            Console.Write("6. feladat - Kérek egy nagybetűt: ");
            string nagybetu = Console.ReadLine();
            Console.WriteLine($"A karakter sorának az indexe: {kodolo.SorIndex(nagybetu)}");
            Console.WriteLine($"A karakter oszlopának az indexe: {kodolo.OszlopIndex(nagybetu)}");
        }

        private static void _8()
        {
            Console.Write("8. feladat - Kérek egy karakterpárt: ");
            string karakterpar = Console.ReadLine();
            Console.WriteLine("Kódolva: " + kodolo.KodolBetupar(karakterpar));
        }
    }
}
