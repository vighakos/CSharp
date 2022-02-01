using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace armstrong
{
    class Program
    {
        static void Main(string[] args)
        {
            //ArmstrongKeres(Szambekeres());

            for (int i = 0; i < int.MaxValue; i++)
            {
                if (ArmstrongKeres(i))
                {
                    Console.WriteLine($"Armstrong szám lokátolva: {i}");
                }
            }

            Console.WriteLine("Vége :)");

            Console.ReadKey();
        }

        private static bool ArmstrongKeres(int szam)
        {
            double osszeg = 0;

            for (int i = 0; i < szam.ToString().Length; i++)
            {
                osszeg += Math.Pow(Szamjegy(szam, i), szam.ToString().Length);
            }

            if (Convert.ToDouble(szam) == osszeg) return true;
            return false;
            ArmstrongKeres(Szambekeres());
        }

        private static double Szamjegy(int szam, int i)
        {
            string szoveg = szam.ToString();
            char karakter = szoveg[i];
            string ujraszoveg = karakter.ToString();

            return Convert.ToInt32(ujraszoveg);
        }

        private static int Szambekeres()
        {
            Console.Write("Adj meg egy számot: ");
            int szam = Convert.ToInt32(Console.ReadLine());

            if (szam < 0) Szambekeres();
            return szam;
        }
    }
}
