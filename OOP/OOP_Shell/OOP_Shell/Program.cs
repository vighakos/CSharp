using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Shell
{
    class Program
    {
        static int[] t = new int[] { 63, 54, 33, 45, 23, 99, 43, 10, 35, 87 };
        static void Main(string[] args)
        {
            ShellRendezes(t);

            for (int i = 0; i < 9; i++)
            {
                Console.WriteLine(t[i]);
            }
            
            Console.ReadKey();
        }

        private static void ShellRendezes(int[] a)
        {
            int gap, n, i, j, x, y;
            gap = 1;
            n = a.Length;

            while (gap * 2 <= n) gap *= 2;

            gap--;

            do
            {
                i = 0;
                while ((i <= gap) && (i + gap < n))
                {
                    j = i + gap;
                    while (j < n)
                    {
                        x = a[j];
                        y = j - gap;
                        while ((x > -1) && (x < a[y]))
                        {
                            a[y + gap] = a[y];
                            y -= gap;
                        }
                        a[y + gap] = x;
                        j += gap;
                    }
                    i++;
                }
                gap /= 2;
            } while (gap > 0);
        }
    }
}
