using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vighakos_20220202
{
    class Program
    {
        public static int szam;
        static void Main(string[] args)
        {
            Console.Write("Adj meg egy számot: ");
            szam = Convert.ToInt32(Console.ReadLine());

            if (Prime(szam))
            {
                //Console.WriteLine("Prím");
                if (Mersenne(szam))
                {
                    Console.WriteLine("A szám Mersenne-prím");
                }
                else
                {
                    Console.WriteLine("A szám prím, de nem Mersenne-prím");
                }
            }
            else
            {
                Console.WriteLine("A szám nem prím");
            }

            Console.ReadKey();
        }

        private static bool Mersenne(int szam)
        {
            for (int i = 0; i < szam; i++)
            {
                if (Math.Pow(2, i) - 1 == szam && Prime(i))
                {
                    return true;
                }
            }
            return false;
        }

        private static bool Prime(int szam)
        {
            for (int i = 2; i <= szam / 2; i++)
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
