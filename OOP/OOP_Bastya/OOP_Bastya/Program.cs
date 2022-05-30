using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace OOP_Bastya
{
    class Program
    {
        static char[,] matrix = new char[8, 8];
        static void Main(string[] args)
        {
            _1();
            _3();
            _4();
            Megjelenit();

            Console.ReadKey();
        }

        private static void _1()
        { 
            int i = 0;
            while (i < 10)
            {
                Random r = new Random();

                int sor = r.Next(0, 8);
                Thread.Sleep(100);

                int oszlop = r.Next(0, 8);
                Thread.Sleep(100);

                if (matrix[sor, oszlop] == 0)
                {
                    matrix[sor, oszlop] = 'G';
                    i++;
                }
            }
        }

        private static void Megjelenit()
        {
            for (int sor = 0; sor < 8; sor++)
            {
                for (int oszlop = 0; oszlop < 8; oszlop++)
                {
                    if (matrix[sor, oszlop] == 'G') 
                        Console.Write("G ");
                    else if (matrix[sor, oszlop] == 'B')
                        Console.Write("B ");
                    else 
                        Console.Write("# ");
                }
                Console.WriteLine();
            }
        }

        private static void _3()
        {
            int i = 0;
            while (i < 5)
            {
                Random r = new Random();

                int sor = r.Next(0, 8);
                Thread.Sleep(100);

                int oszlop = r.Next(0, 8);
                Thread.Sleep(100);

                if (sor != 0 && 
                    sor != 7 && 
                    oszlop != 0 && 
                    oszlop != 7 && 
                    matrix[sor, oszlop] == 0)
                {
                    matrix[sor, oszlop] = 'B';
                    i++;
                }
            }
        }

        private static void _4()
        {
            for (int sor = 0; sor < 8; sor++)
            {
                for (int oszlop = 0; oszlop < 8; oszlop++)
                {
                    if (matrix[sor, oszlop] == 'B')
                    {
                        matrix[sor, oszlop] = Lepesek(sor, oszlop);
                    }
                }
            }
        }

        private static char Lepesek(int sor, int oszlop)
        {
            int db = 4;


            for (int i = 0; i < sor; i++)
            {
                if (matrix[i, oszlop] == 'G' || matrix[i, oszlop] == 'B')
                {
                    db--; 
                    break;
                }
            }

            for (int i = sor; i < 8; i++)
            {
                if (matrix[i, oszlop] == 'G' || matrix[i, oszlop] == 'B')
                {
                    db--;
                    break;
                }
            }

            for (int i = 0; i < oszlop; i++)
            {
                if (matrix[sor, i] == 'G' || matrix[sor, i] == 'B')
                {
                    db--;
                    break;
                }
            }

            for (int i = oszlop; i < 8; i++)
            {
                if (matrix[sor, i] == 'G' || matrix[sor, i] == 'B')
                {
                    db--;
                    break;
                }
            }

            return Convert.ToChar(db);
        }
    }
}
