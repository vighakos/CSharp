using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace primfelbont2
{
    class Program
    {
        static void Main(string[] args)
        {
            PrimFelbontas(Szambekeres());

            Console.ReadKey();
        }

        private static void PrimFelbontas(int szam)
        {
            int oszto = 2;
            int maradek = 0;
            List<int> tenyezok = new List<int>();

            if (Prim(szam))
            {
                Console.WriteLine("A szám prímszám");
                PrimFelbontas(Szambekeres());
            }
            else
            {
                while (maradek != 1)
                {
                    if (Prim(oszto))
                    {
                        if (szam % oszto == 0)
                        {
                            maradek = szam / oszto;
                            szam = maradek;
                            tenyezok.Add(oszto);
                            oszto = 1;
                        }
                    }
                    oszto++;
                }
                Kiiras(tenyezok);
                PrimFelbontas(Szambekeres());
            }
        }

        private static void Kiiras(List<int> tenyezok)
        {
            Console.Write("Prímtényezős felbontásban: ");
            for (int i = 0; i < tenyezok.Count; i++)
            {
                if (i == tenyezok.Count - 1)
                {
                    Console.Write($"{tenyezok[i]}");
                }
                else
                {
                    Console.Write($"{tenyezok[i]} * ");
                }
            }
            Console.WriteLine();
        }

        private static bool Prim(int oszto)
        {
            for (int i = 2; i <= oszto / 2; i++)
            {
                if (oszto % i == 0) return false;
            }
            return true;
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
