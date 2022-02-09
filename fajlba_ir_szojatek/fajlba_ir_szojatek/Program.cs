using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace fajlba_ir_szojatek
{
    class Program
    {
        static List<string> hasznalt_szavak = new List<string>();
        static List<string> szavak = new List<string>();
        static void Main(string[] args)
        {
            // gép gondol egy számra, szó bekér, 5 tipp van (1700 szóra??), kiír, hogy hány betű talált (jó hely, rossz hely, de van olyan betű, rossz betű),
            // statisztika kell (x. játék {szó} kitalált/meghalt), ne lehessen újra felhasználni a szavakat

            Beolvas();
            BeolvasSzavak();
            Jatek(Beker());
            //Statisztika();
            //SzoEltarol();


            Console.ReadKey();
        }

        private static void Jatek(string tipp)
        {
            int tippek = 5;
            Random r = new Random();
            int szoindex = r.Next(0, hasznalt_szavak.Count);
            for (int i = 0; i < hasznalt_szavak.Count; i++)
            {
                if (hasznalt_szavak[i] == szavak[szoindex])
                {
                    r.Next(0, hasznalt_szavak.Count);
                    i = 0;
                }
            }

            string gondoltszo = szavak[szoindex];

            for (int i = 0; i < gondoltszo.Length; i++)
            {
                for (int j = 0; j < tipp.Length; j++)
                {
                    if (gondoltszo[i] == tipp[j])
                    {

                    }
                }
            }

        }

        private static void BeolvasSzavak()
        {
            try
            {
                StreamReader be = new StreamReader("szavak.txt", Encoding.Default);

                while (!be.EndOfStream)
                {
                    szavak.Add(be.ReadLine());
                }
                be.Close();
            }
            catch (IOException)
            {
                Console.WriteLine("Hiba");
            }
        }

        private static string Beker()
        {
            Console.Write("Adj meg egy szót: ");
            string tipp = Console.ReadLine();

            return tipp;
        }

        private static void Beolvas()
        {
            try
            {
                StreamReader be = new StreamReader("hasznaltszavak.txt", Encoding.Default);

                while (!be.EndOfStream)
                {
                    hasznalt_szavak.Add(be.ReadLine());
                }
                be.Close();
            }
            catch (IOException)
            {

            }
        }
    }
}
