using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Szamjegyek
{
    class Program
    {
        const int n = 5;
        static void Main(string[] args)
        {
            char[] szam = new char[] { '5', '2', '6', '3', '1' };
            Console.WriteLine(szam);
            Console.WriteLine(Keres(szam));
            
            Console.ReadKey();
        }

        private static char[] Cserel(char[] szam, int i1, int i2)
        {
            char ch;
            ch = szam[i1];
            szam[i1] = szam[i2];
            szam[i2] = ch;
            return szam;
        }

        private static char[] Keres(char[] szam)
        {
            int indA, indB, i, j, meddig;
            indA = -1;
            i = n - 1;

            while (i > 0 && indA == -1)
            {
                if (szam[i-1] < szam[i])
                {
                    indA = i - 1;
                }
                i--;
            }

            if (indA == -1) return szam;

            indB = indA + 1;

            for (j = indA+2; j <= n-1; j++)
            {
                if (szam[j] > szam[indA] && szam[j] < szam[indB])
                {
                    indB = j;
                }
            }

            szam = Cserel(szam, indA, indB);

            for (meddig = n-1; meddig >= 1; meddig--)
            {
                for (j = indA + 1; j <= meddig - 1; j++)
                {
                    if (szam[j] > szam[j + 1])
                    {
                        Cserel(szam, j, j + 1);
                    }
                }
            }

            return szam;
        }
    }
}
