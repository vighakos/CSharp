using System;
using System.Collections.Generic;

namespace lottoszamok
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ez a program képes megjósolni a nyerőszámokt a lottón! (nem)");
            Console.WriteLine("Melyik típusú lott érdekli?");
            Console.Write("Ötös lott (1), hatos lott (2), hetes lott (3): ");
            string valasz = Console.ReadLine();
            if (valasz == "1")
            {
                OtosLotto();
            }
            else if (valasz == "2")
            {
                HatosLotto();
            }
            else if (valasz == "3")
            {
                HetesLotto();
            }
            else if (valasz == "4")
            {
                OtosLotto();
                HatosLotto();
                HetesLotto();
            }
            
            Console.ReadKey();
        }

        private static void HetesLotto()
        {
            Random r = new Random();
            List<int> szamok = new List<int>();
            Console.Write("A hetes lottó nyerőszámai: ");
            do
            {
                int szam = r.Next(1, 35);
                if (!szamok.Contains(szam))
                {
                    szamok.Add(szam);
                }
            } while (szamok.Count != 7);

            szamok.Sort();

            for (int i = 0; i < szamok.Count; i++)
            {
                Console.Write($"{szamok[i]} ");
            }
            Console.WriteLine();
        }

        private static void HatosLotto()
        {
            Random r = new Random();
            List<int> szamok = new List<int>();
            Console.Write("A hatos lottó nyerőszámai: ");
            do
            {
                int szam = r.Next(1, 45);
                if (!szamok.Contains(szam))
                {
                    szamok.Add(szam);
                }
            } while (szamok.Count != 6);

            szamok.Sort();

            for (int i = 0; i < szamok.Count; i++)
            {
                Console.Write($"{szamok[i]} ");
            }
            Console.WriteLine();
        }

        private static void OtosLotto()
        {
            /*A 1 és 90 közül 5 szám, nincs imsétlődés*/
            Random r = new Random();
            List<int> szamok = new List<int>();
            Console.Write("Az ötös lottó nyerőszámai: ");
            do
            {
                int szam = r.Next(0, 91);
                if (!szamok.Contains(szam))
                {
                    szamok.Add(szam);
                }
            } while (szamok.Count != 5);

            szamok.Sort();

            for (int i = 0; i < szamok.Count; i++)
            {
                Console.Write($"{szamok[i]} ");
            }
            Console.WriteLine();
        }
    }
}
