using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Gazdasag
{
    class Program
    {
        static int sor = Convert.ToInt32(Fajl.SorOszlop("terulet.txt").Split(' ')[0]);
        static int oszlop = Convert.ToInt32(Fajl.SorOszlop("terulet.txt").Split(' ')[1]);
        static string[,] terulet = Fajl.Beolvas("terulet.txt", sor, oszlop);
        static void Main(string[] args)
        {
            _2();
            _3();
            _4();
            _5();
            _6();
            _7();

            Console.ReadKey();
        }

        private static void _2()
        {
            Console.WriteLine($"2. feladat: {sor * 100} x {oszlop * 100}, területe: {sor * 100 * oszlop * 100 / 10000} ha");
        }

        private static void _3()
        {
            double ossz = 0, legelok = 0;

            foreach (string item in terulet)
            {
                ossz++;
                if (item == "L")
                {
                    legelok++;
                }
            }

            Console.WriteLine($"3. feladat: {legelok / ossz * 100:0.00}%");
        }

        private static void _4()
        {
            for (int i = 0; i < sor; i++)
            {
                for (int j = 0; j < oszlop; j++)
                {
                    if (terulet[i, j] == "L")
                    {
                        Console.WriteLine($"4. feladat: {i * 100}m");
                        return;
                    }
                }
            }
        }

        private static void _5()
        {
            int max = 0;
            for (int i = 0; i < sor; i++)
            {
                int leg = 0;
                for (int j = 0; j < oszlop; j++)
                {
                    if (terulet[i, j] == "L")
                    {
                        leg++;
                    }
                    else
                    {
                        if (max < leg)
                        {
                            max = leg;
                        }
                        leg = 0;
                    }
                }
            }

            Console.WriteLine($"5. feladat: {max * 100}m");
        }

        private static void _6()
        {
            int db = 0;
            for (int i = 0; i < sor; i++)
            {
                for (int j = 0; j < oszlop; j++)
                {
                    if (terulet[i, j] == "L" &&
                        terulet[i, j - 1] == "M" &&
                        terulet[i - 1, j] == "M")
                    {
                        db++;
                    }
                }
            }

            Console.WriteLine($"6. feladat: {db}db");
        }

        private static void _7()
        {
            int maxter = 0;
            for (int i = 0; i < sor; i++)
            {
                for (int j = 0; j < oszlop; j++)
                {
                    if (terulet[i, j] == "L" &&
                        terulet[i, j - 1] == "M" &&
                        terulet[i - 1, j] == "M")
                    {
                        int ter = TeruletSzamolo(i, j);
                        if (ter > maxter)
                        {
                            maxter = ter;
                        }
                    }
                }
            }

            Console.WriteLine($"7. felada: {maxter / 10000} ha");
        }

        private static int TeruletSzamolo(int sorok, int oszlopok)
        {
            int szelesseg = 0, magassag = 0;

            for (int i = oszlopok; i < oszlop; i++)
            {
                if (terulet[sorok, i] == "L")
                    szelesseg++;
                else
                    break;
            }
            
            for (int i = sorok; i < sor; i++)
            {
                if (terulet[i, oszlopok] == "L")
                    magassag++;
                else
                    break;
            }

            return szelesseg * magassag;
        }
    }
}
