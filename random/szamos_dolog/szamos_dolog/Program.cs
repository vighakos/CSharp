using System;

namespace szamos_dolog
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Számot: ");
            int szam = Convert.ToInt32(Console.ReadLine());
            string[] egyesek = new string[] { "nulla", "egy", "kettő", "három", "négy", "öt", "hat", "hét", "nyolc", "kilenc" };
            string[] tizesek = new string[] { "", "tizen", "huszon", "harminc", "negyven", "ötven", "hatvan", "hetven", "nyolcvan", "kilencven" };
            string[] szazasok = new string[] { "", "száz", "kétszáz", "háromszáz", "négyszáz", "ötszáz", "hatszáz", "hétszáz", "nyolcszáz", "kilencszáz" };
            string[] ezresek = new string[] { "", "ezer", "kétezer", "háromezer", "négyezer", "ötezer", "hatezer", "hétezer", "nyolcezer", "kilencezer" };

            int szazezres_db = szam / 100000;
            szam = szam % 100000;

            int tizezres_db = szam / 10000;
            szam = szam % 10000;

            int ezres_db = szam / 1000;
            szam = szam % 1000;

            int szazas_db = szam / 100;
            szam = szam % 100;

            int tizes_db = szam / 10;
            int egyes_db = szam % 10;

            if (szam / 10 == 1 && szam % 10 == 0)
            {
                Console.WriteLine("tíz");
            }
            else if (szam / 10 == 2 && szam % 10 == 0)
            {
                Console.WriteLine("húsz");
            }
            else if (szam / 10 == 3 && szam % 10 == 0)
            {
                Console.WriteLine("harminc");
            }
            else if (szam / 10 == 4 && szam % 10 == 0)
            {
                Console.WriteLine("negyven");
            }
            else if (szam / 10 == 5 && szam % 10 == 0)
            {
                Console.WriteLine("ötven");
            }
            else if (szam / 10 == 6 && szam % 10 == 0)
            {
                Console.WriteLine("hatvan");
            }
            else if (szam / 10 == 7 && szam % 10 == 0)
            {
                Console.WriteLine("hetven");
            }
            else if (szam / 10 == 8 && szam % 10 == 0)
            {
                Console.WriteLine("nyolcvan");
            }
            else if (szam / 10 == 9 && szam % 10 == 0)
            {
                Console.WriteLine("kilencven");
            }
            else
            {
                Console.WriteLine($"{tizesek[szam / 10]}{egyesek[szam % 10]}");
            }

            

            Console.ReadKey();
        }
    }
}
