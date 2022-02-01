using System;
using System.Collections.Generic;

namespace szamvalto
{
    class Program
    {
        static string szamjegyek = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        static void Main(string[] args)
        {
            Console.Write($"Hányas számrendszerből váltsak (2 - {szamjegyek.Length}) ");
            int indulo_szamrendszer = Convert.ToInt32(Console.ReadLine());
            Console.Write($"Hányas számrendszerbe váltsak (2 - {szamjegyek.Length}) ");
            int erkezo_szamrendszer = Convert.ToInt32(Console.ReadLine());
            Console.Write($"Kérem a(z) {indulo_szamrendszer} beli számot: ");
            string szam = Console.ReadLine();

            int szam_tizesbe = TizesbeValtas(indulo_szamrendszer, szam);
            Console.WriteLine($"10-es számrendszerben: {szam_tizesbe}");

            string szam_tetszolegesbe = Tizesbol_valtas(erkezo_szamrendszer, szam_tizesbe);
            Console.WriteLine($"Az átváltott szám: {szam_tetszolegesbe}");

            Console.ReadKey();
        }

        private static string Tizesbol_valtas(int erkezo_szamrendszer, int szam_tizesbe)
        {
            string valtott = "";
            int maradek;
            int hanyados = -1;

            do
            {
                maradek = szam_tizesbe % erkezo_szamrendszer;
                hanyados = szam_tizesbe / erkezo_szamrendszer;
                valtott += szamjegyek[maradek];
            } while (hanyados != 0);

            return valtott;
        }

        private static int TizesbeValtas(int indulo_szamrendszer, string szam)
        {
            int szam_hossza = szam.Length;
            int szam_tizesbe = 0;

            for (int i = 0; i < szam_hossza; i++)
            {
                double hatvany = Math.Pow(indulo_szamrendszer, szam_hossza - 1 - i);
                int szamjegyertek = Ertek_kereses(szam[i]);

                szam_tizesbe += Convert.ToInt32(hatvany) * szamjegyertek;
            }

            return szam_tizesbe;
        }

        private static int Ertek_kereses(char szamjegy)
        {
            int pozicio = -1;

            for (int i = 0; i < szamjegyek.Length; i++)
            {
                if (szamjegyek[i] == szamjegy)
                {
                    pozicio = i;
                    break;
                }
            }

            return pozicio;
        }
    }
}
