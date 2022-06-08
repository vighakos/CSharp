using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Primvizsgalat
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine(primSzam(100));
            Console.WriteLine(primSzam(101));

            Console.ReadKey();
        }

        private static bool primSzam(int n)
        {
            return elsoOszto(n) == n;
        }

        private static long elsoOszto(int n)
        {
            int[] szita = new int[] { 7, 11, 13, 17, 19, 23, 29, 31 },
                elsoPrimek = new int[] { 2, 3, 5 };
            long ngyok, i;
            int j;

            if (n == 1) return 0;

            for (j = 0; j < elsoPrimek.Length; j++)
            {
                if (n % elsoPrimek[j] == 0)
                {
                    return elsoPrimek[j];
                }
            }
            ngyok = Convert.ToInt64(Math.Sqrt(n));
            i = 0;

            while (i < ngyok)
            {
                for (j = 0; j < szita.Length; j++)
                {
                    if (n % (i + szita[j]) == 0)
                    {
                        return i + szita[j];
                    }
                }
                i += 30;
            }
            return n;
        }
    }
}
