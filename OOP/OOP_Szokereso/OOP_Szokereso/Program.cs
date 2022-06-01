using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Szokereso
{
    class Program
    {
        static List<string> szavak = Fajl.Beolvas("szavak.txt");
        static void Main(string[] args)
        {
            Console.WriteLine($"1. feladat - Szavak száma: {szavak.Count} db");
            Console.WriteLine($"2. feladat - Leghosszabb szó hossza: {Leghosszabb()} db karakter");
            Console.WriteLine("3. feladat - Leghosszabb szó/szavak:");
            _3();
            _5();
            Console.ReadKey();
        }

        private static int Leghosszabb()
        {
            return szavak.Max(x => x.Split('*')[0].Length);
        }

        private static void _3()
        {
            foreach (string item in szavak.Where(y => y.Split('*')[0].Length == szavak.Max(x => x.Split('*')[0].Length)))
            {
                Console.WriteLine($"\t{item.Split('*')[0]}");
            }
        }

        private static void _5()
        {
            char[,] matrix = new char[16, 16];
            foreach (string item in szavak)
            {
                string szo = item.Split('*')[0];
                int sor = Convert.ToInt32(item.Split('*')[1]);
                int oszlop = Convert.ToInt32(item.Split('*')[2]);
                int irany = Convert.ToInt32(item.Split('*')[3]);

                matrix = Elhelyez(matrix, szo, sor, oszlop, irany);
            }
        }

        private static char[,] Elhelyez(char[,] matrix, string szo, int sor, int oszlop, int irany)
        {
            if (irany == 1)
            {
                foreach (char betu in szo)
                {
                    matrix[sor, oszlop] = betu;
                    oszlop++;
                }
                return matrix;
            }
            else if (irany == 2)
            {
                foreach (char betu in szo)
                {
                    matrix[sor, oszlop] = betu;
                    sor--;
                    oszlop++;
                }
                return matrix;
            }
            else if (irany == 3)
            {
                foreach (char betu in szo)
                {
                    matrix[sor, oszlop] = betu;
                    sor++;
                }
                return matrix;
            }
            else if (irany == 4)
            {
                foreach (char betu in szo)
                {
                    matrix[sor, oszlop] = betu;
                    sor--;
                    oszlop--;
                }
                return matrix;
            }
            else if (irany == 5)
            {
                foreach (char betu in szo)
                {
                    matrix[sor, oszlop] = betu;
                    oszlop--;
                }
                return matrix;
            }
            else if (irany == 6)
            {
                foreach (char betu in szo)
                {
                    matrix[sor, oszlop] = betu;
                    sor++;
                    oszlop--;
                }
                return matrix;
            }
            else if (irany == 7)
            {
                foreach (char betu in szo)
                {
                    matrix[sor, oszlop] = betu;
                    sor++;
                }
                return matrix;
            }
            else if (irany == 8)
            {
                foreach (char betu in szo)
                {
                    matrix[sor, oszlop] = betu;
                    sor++;
                    oszlop++;
                }
                return matrix;
            }

            return null;
        }
    }
}
