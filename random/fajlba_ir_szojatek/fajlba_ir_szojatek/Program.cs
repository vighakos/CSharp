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
        static List<string> statisztika_lista = new List<string>();
        static int tippek = 5;
        static bool talalt = false;
        static void Main(string[] args)
        {
            // gép gondol egy szóra, 5 tipp
            // kiír, hogy hány betű talált (jó hely, rossz hely, de van olyan betű, rossz betű)
            // statisztika kell (x. játék {szó} nyert/nem nyert), ne lehessen újra felhasználni a szavakat
            Console.ForegroundColor = ConsoleColor.White;
            Beolvas();
            BeolvasSzavak();
            StatBeolvas();

            Console.WriteLine($"Gondoltam egy szóra, találd ki! Tippek: {tippek}");
            Jatek();

            Console.ReadKey();
        }

        private static void Jatek()
        {
            Random r = new Random();
            int szoindex = r.Next(0, szavak.Count);
            for (int i = 0; i < hasznalt_szavak.Count; i++)
            {
                if (hasznalt_szavak[i] == szavak[szoindex])
                {
                    r.Next(0, hasznalt_szavak.Count);
                    i = 0;
                }
            }

            string gondoltszo = szavak[szoindex];
            //Console.WriteLine($"A gondolt szó: {gondoltszo}");
            Console.WriteLine();

            Tippeles(Beker(), gondoltszo);

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("--------------------------------");
            hasznalt_szavak.Add(gondoltszo);
            HasznaltszoKiir(gondoltszo);
            Statisztika(gondoltszo);
        }

        private static void Statisztika(string gondoltszo)
        {
            try
            {
                StreamWriter ki = new StreamWriter("statisztika.txt", append: true);

                string talalte = talalt ? "Nyert" : "Nem nyert";

                if (statisztika_lista.Count == 0)
                {
                    ki.WriteLine($"1. játék: {gondoltszo} ({talalte})");
                }
                else
                {
                    ki.WriteLine($"{Convert.ToInt32(statisztika_lista[statisztika_lista.Count - 1].Split('.')[0]) + 1}. játék: {gondoltszo} ({talalte})");
                }
                ki.Close();

                Console.WriteLine("Statisztika frissítve");
            }
            catch (IOException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Hiba a 'statisztika.txt' fájl írása közben");
            }
        }

        private static void HasznaltszoKiir(string gondoltszo)
        {
            try
            {
                StreamWriter ki = new StreamWriter("hasznaltszavak.txt", append: true);
                ki.WriteLine(gondoltszo);
                ki.Close();

                Console.WriteLine("Használt szó kiírva");
            }
            catch (IOException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Hiba a 'hasznaltszavak.txt' fájl írása közben");
            }
        }

        private static bool Tippeles(string tipp, string gondoltszo)
        {
            Console.ForegroundColor = ConsoleColor.White;
            if (tipp == gondoltszo)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nTalált!");
                Console.WriteLine();
                talalt = true;
                return talalt;
            }
            else
            {
                for (int i = 0; i < tipp.Length; i++)
                {
                    if (gondoltszo.Contains(tipp[i]))
                    {
                        if (gondoltszo[i] == tipp[i])
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"{tipp[i]}: Jó betű, jó hely");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine($"{tipp[i]}: Jó betű, rossz helyen");
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"{tipp[i]}: Rossz betű");
                    }
                }

                tippek--;

                if (tippek < 1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nElfogytak a tippek, vesztettél!");
                    Console.WriteLine($"A szó {gondoltszo} volt");
                    Console.WriteLine();
                    talalt = false;
                    return talalt;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"Tippek száma: {tippek}");
                    Console.WriteLine();
                    Tippeles(Beker(), gondoltszo);
                }
            }
            return talalt;
        }

        private static string Beker()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Tippelj: ");
            string tipp = Console.ReadLine();
            return tipp;
        }

        private static void StatBeolvas()
        {
            try
            {
                StreamReader be = new StreamReader("statisztika.txt", Encoding.Default);

                while (!be.EndOfStream)
                {
                    statisztika_lista.Add(be.ReadLine());
                }
                be.Close();
            }
            catch (IOException)
            {

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
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Hiba a 'szavak.txt' fájl olvasása közben");
            }
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
