using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Decoder
{
    class Program
    {
        static List<Karakter> karakterBank = Fajl.Beolvas("bank.txt");
        static List<Karakter> dekodolando = Fajl.Beolvas("dekodol.txt");
        static void Main(string[] args)
        {
            _5();
            _6();
            _9();

            Console.ReadKey();
        }

        private static void _9()
        {
            Console.WriteLine("9. feladat: Dekódolás");
            foreach (Karakter item in dekodolando)
            {
                if (item.Felismer(karakterBank))
                    Console.Write(item.Betu);
                else
                    Console.Write("?");
            }
        }

        private static void _6()
        {
            string betu = "";
            do
            {
                Console.Write("6. feladat: Adj meg egy angol nagybetűt: ");
                betu = Console.ReadLine();
            } while (!BetuEllenor(betu));

            _7(betu);
            
        }

        private static void _7(string betu)
        {
            bool talalt = false;
            foreach (Karakter item in karakterBank)
            {
                if (item.Betu == betu)
                {
                    Console.WriteLine("7. feladat:");
                    talalt = true;
                    item.Megjelenit();
                }
            }

            if (!talalt)
                Console.WriteLine("7. feladat: Nincs ilyen betű");
        }

        private static bool BetuEllenor(string betu)
        {
            string betuk = "QWERTZUIOPASDFGHJKLYXCVBNM";
            if (betuk.Contains(betu) && betu.Length == 1) return true;
            return false;
        }

        private static void _5()
        {
            Console.WriteLine($"5. feladat: karakterek száma: {karakterBank.Count} db");
        }
    }
}
