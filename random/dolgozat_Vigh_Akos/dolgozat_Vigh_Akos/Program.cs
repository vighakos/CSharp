using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dolgozat_Vigh_Akos
{
    class Program
    {
        static List<Szobak> szobak = new List<Szobak>();
        static List<Ajtok> ajtok = new List<Ajtok>();
        static List<Ablakok> ablakok = new List<Ablakok>();
        static void Main(string[] args)
        {
            Beker();
            Console.ReadKey();
        }

        private static void Beker()
        {
            Console.Write("Kérem adja meg a szobák számát: ");
            int szobakszama = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < szobakszama; i++)
            {
                double szoba_szelesseg, szoba_hosszusag, szoba_magassag;
                double ajto_szelesseg, ajto_magassag;
                double ablak_szelesseg, ablak_magassag;

                Console.WriteLine("------------------");
                Console.Write($"{i+1}. szoba szélessége: ");
                szoba_szelesseg = Convert.ToDouble(Console.ReadLine());
                Console.Write($"{i+1}. szoba hosszúsága: ");
                szoba_hosszusag = Convert.ToDouble(Console.ReadLine());
                Console.Write($"{i+1}. szoba magassága: ");
                szoba_magassag = Convert.ToDouble(Console.ReadLine());

                szobak.Add(new Szobak(szoba_szelesseg, szoba_hosszusag, szoba_magassag));

                Console.Write($"{i+1}. szobában az ajtó szám: ");
                int ajtoszam = Convert.ToInt32(Console.ReadLine());

                for (int j = 0; j < ajtoszam; j++)
                {
                    Console.Write($"{j+1}. ajtó szélessége: ");
                    ajto_szelesseg = Convert.ToDouble(Console.ReadLine());

                    Console.Write($"{j+1}. ajtó magassága: ");
                    ajto_magassag = Convert.ToDouble(Console.ReadLine());

                    ajtok.Add(new Ajtok(ajto_szelesseg, ajto_magassag));
                }

                Console.Write($"{i + 1}. szobában az ablak szám: ");
                int ablakszam = Convert.ToInt32(Console.ReadLine());

                for (int k = 0; k < ablakszam; k++)
                {
                    Console.Write($"{k + 1}. ablak szélessége: ");
                    ablak_szelesseg = Convert.ToDouble(Console.ReadLine());

                    Console.Write($"{k + 1}. ablak magassága: ");
                    ablak_magassag = Convert.ToDouble(Console.ReadLine());

                    ablakok.Add(new Ablakok(ablak_magassag, ablak_szelesseg));
                }
            }
            Lakas lakas = new Lakas(szobak, ajtok, ablakok);
            Kiszamol(lakas);
        }

        private static void Kiszamol(Lakas lakas)
        {
            Console.WriteLine($"\nÖsszfesték: " + lakas.Osszfestek() + " m2");
            Console.WriteLine($"Összpadló: " + lakas.Osszpadlo() + " m2");
        }
    }
}
