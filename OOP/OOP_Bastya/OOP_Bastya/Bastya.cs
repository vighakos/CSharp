using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace OOP_Bastya
{
    class Bastya
    {
        private static string[,] matrix;
        public static bool Mindenertek;

        public Bastya(bool otodik)
        {
            if (!otodik)
            {
                //1. feladat
                LetrehozMatrix();

                //2. feladat
                Gyalogosok();
                Console.WriteLine("2. feladat: Gyalogok elhelyezkedése:\n");
                Megjelenit();

                //3. feladat
                Bastyak();
                Console.WriteLine("\n3. feladat: Bástyák elhelyezkedése:\n");
                Megjelenit();

                //4. feladat
                _4();
                Console.WriteLine("\n4. feladat: Bástyák lépésértékei:\n");
                Megjelenit();
            }
            else
            {
                int i = 0;
                do
                {
                    LetrehozMatrix();
                    Gyalogosok();
                    Bastyak();
                    _4();
                    Console.WriteLine("\n\n" + i);
                    if (MindenErtek())
                    {
                        Console.WriteLine("\n5. feladat: Minden érték:\n");
                        Megjelenit();
                    }
                    i++;
                } while (!MindenErtek());
                
            }
        }

        private static void LetrehozMatrix()
        {
            matrix = new string[8, 8];
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    matrix[i, j] = "#";
                }
            }
        }

        public static void Megjelenit()
        {
            for (int sor = 0; sor < 8; sor++)
            {
                for (int oszlop = 0; oszlop < 8; oszlop++)
                {
                    Console.Write(matrix[sor, oszlop] + " ");
                }
                Console.WriteLine();
            }
        }

        private static void Gyalogosok()
        {
            int db = 0;

            while (db < 10)
            {
                Random r = new Random();

                int sor = r.Next(0, 8);
                Thread.Sleep(5);
                int oszlop = r.Next(0, 8);

                if (matrix[sor, oszlop] == "#")
                {
                    matrix[sor, oszlop] = "G";
                    db++;
                }
            }
        }

        private static void Bastyak()
        {
            int i = 0;
            while (i < 5)
            {
                Random r = new Random();

                int sor = r.Next(0, 8);
                Thread.Sleep(5);
                int oszlop = r.Next(0, 8);

                if (sor != 0 &&
                    sor != 7 &&
                    oszlop != 0 &&
                    oszlop != 7 &&
                    matrix[sor, oszlop] == "#")
                {
                    matrix[sor, oszlop] = "B";
                    i++;
                }
            }
        }

        private static void _4()
        {
            string[,] seged = new string[8, 8];

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    seged[i, j] = matrix[i, j];
                }
            }

            for (int sor = 0; sor < 8; sor++)
            {
                for (int oszlop = 0; oszlop < 8; oszlop++)
                {
                    if (matrix[sor, oszlop] == "B")
                    {
                        seged[sor, oszlop] = LepesErtek(sor, oszlop);
                    }
                }
            }

            matrix = seged;
        }

        private static string LepesErtek(int sor, int oszlop)
        {
            int db = 4;

            // soron megy végig
            for (int i = 0; i < 8; i++)
            {
                if ((matrix[sor, i] == "G" || matrix[sor, i] == "B") && i != oszlop)
                {
                    if (i < oszlop)
                    {
                        db--;
                        i = oszlop;
                    }
                    else
                    {
                        db--;
                        break;
                    }
                }
            }

            // oszlopon megy végig
            for (int i = 0; i < 8; i++)
            {
                if ((matrix[i, oszlop] == "G" || matrix[i, oszlop] == "B") && i != sor)
                {
                    if (i < sor)
                    {
                        db--;
                        i = sor;
                    }
                    else
                    {
                        db--;
                        break;
                    }
                }
            }

            return db.ToString();
        }

        private static bool MindenErtek()
        {
            List<int> szamok = new List<int>();
            Mindenertek = false;

            for (int sor = 0; sor < 8; sor++)
            {
                for (int oszlop = 0; oszlop < 8; oszlop++)
                {
                    if (matrix[sor, oszlop] != "#" && matrix[sor, oszlop] != "G" && matrix[sor, oszlop] != "B")
                    {
                        szamok.Add(Convert.ToInt32(matrix[sor, oszlop]));
                    }
                }
            }

            Console.WriteLine();
            foreach (int item in szamok)
            {
                Console.Write(item + " ");
            }

            if (szamok.Distinct().Count() == 5)
            {
                Mindenertek = true;
            }
            return Mindenertek;
        }
    }
}
