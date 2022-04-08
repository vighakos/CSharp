using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fajlbe3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Honnan szeretnél fájl beolvasni? 1: Asztal, 2: Debug");
            string hely = Console.ReadLine();
            string fajleleres = "";
            if (hely == "1")
            {
                fajleleres = "C:\\Users\\vighakos\\Desktop\\";
            }

            Console.WriteLine("Mi a fájl neve? (a.txt, be.txt) ");
            fajleleres += Console.ReadLine();

            Console.WriteLine("----------------");
            BeOlvas(fajleleres);

            Console.ReadKey();
        }

        private static void BeOlvas(string fajleleres)
        {
            try
            {
                StreamReader be = new StreamReader(fajleleres);
                List<string> adatok = new List<string>();
                while (!be.EndOfStream)
                {
                    adatok.Add(be.ReadLine());
                }
                Kiir(adatok);
            }
            catch (IOException)
            {
                Console.WriteLine("Hiba");
            }
        }

        private static void Kiir(List<string> adatok)
        {
            Console.WriteLine("A fájl adatai:\n----------------");
            foreach (string sor in adatok)
            {
                Console.WriteLine(sor);
            }
        }
    }
}
