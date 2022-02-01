using System;
using System.Collections.Generic;

namespace szambeker
{
    class Program
    {
        
        static void Main(string[] args)
        {
            List<int> szamok = new List<int>();
            Console.WriteLine("Adj meg számokat 0 végjelig");
            int szam = 1;

            do
            {
                Console.Write("Kérem a számot: ");
                szam = Convert.ToInt32(Console.ReadLine());
                if (szam != 0)
                {
                    szamok.Add(szam);
                }
            } while (szam != 0);

            Console.WriteLine("--------------------------------");
            Console.WriteLine($"Megadott számok száma: {szamok.Count}");

            for (int i = 0; i < szamok.Count; i++)
            {
                if (i != szamok.Count-1)
                {
                    Console.Write($"{szamok[i]}, ");
                }
                else
                {
                    Console.Write($"{szamok[i]}");
                    Console.WriteLine();
                }
            }
            Console.WriteLine("--------------------------------");
            Console.Write("Kérek egy számot: ");
            int keresett = Convert.ToInt32(Console.ReadLine());

            if (szamok.Contains(keresett))
            {
                Console.WriteLine("A szám megtalálható");
                int index = szamok.FindIndex(x => x == keresett);
                Console.WriteLine($"A(z) {index+1}. helyen található");
            }
            else
            {
                Console.WriteLine("A szám nem megtalálható");
            }
            Console.WriteLine("--------------------------------");

            

            Console.ReadKey();
        }
    }
}
