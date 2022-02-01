using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace primfelbont
{
    class Program
    {
        public static List<int> szamok = new List<int>();
        public static bool kesz = false;
        static void Main(string[] args)
        {
            Console.Write("Adj meg egy egész számot: ");
            int szam = Convert.ToInt32(Console.ReadLine());
            int eredetiszam = szam;

            if (!isPrim(szam))
            {
                do
                {
                    keres(szam);
                } while (!kesz);

                Console.Write($"{eredetiszam} felbontva: ");

                for (int i = 0; i < szamok.Count; i++)
                {
                    if (i != szamok.Count-1)
                    {
                        Console.Write($"{szamok[i]} * ");
                    }
                    else
                    {
                        Console.WriteLine($"{szamok[i]}");
                    }
                    
                }
            }
            else
            {
                Console.WriteLine("Prím számot adtál meg");
            }

            Console.ReadKey();
        }

        private static void keres(int szam)
        {

            for (int i = 2; i <= szam /2; i++)
            {
                if (szam % i == 0)
                {
                    szamok.Add(i);
                    szam /= i;
                    break;
                }
                else if (szam == 1)
                {
                    kesz = true;
                }
            }
        }

        private static bool isPrim(int szam)
        {
            if (szam == 0 || szam == 1)
            {
                return false;
            }

            for (int i = 2; i < szam / 2; i++)
            {
                if (szam % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
