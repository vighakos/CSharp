using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace OOP_Eletjatek
{
    class EletjatekSzimulator
    {
        private int[,] matrix;
        private int oszlopokSzama, sorokSzama;

        public EletjatekSzimulator(int sorokSzama, int oszlopokSzama)
        {
            this.oszlopokSzama = oszlopokSzama;
            this.sorokSzama = sorokSzama;
            matrix = new int[sorokSzama + 2, oszlopokSzama + 2];
            KezdoAllapot();
        }

        public void Run()
        {
            Megjelenit();
            kovetkezoAllapot();
            Thread.Sleep(100);
            Run();
        }

        private void kovetkezoAllapot()
        {
            int[,] modMatrix = new int[sorokSzama + 2, oszlopokSzama + 2];
            modMatrix = MatrixMasolo(matrix, modMatrix);
            for (int sor = 1; sor < sorokSzama + 1; sor++)
            {
                for (int oszlop = 1; oszlop < oszlopokSzama + 1; oszlop++)
                {
                    int szomszedok = 0;
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            szomszedok += matrix[sor + i - 1, oszlop + j - 1];
                        }
                    }
                    szomszedok -= matrix[sor, oszlop];
                    modMatrix = Valtozas(modMatrix, szomszedok, sor, oszlop);
                }
            }

            matrix = MatrixMasolo(modMatrix, matrix);
        }

        private int[,] Valtozas(int[,] modMatrix, int szomszedok, int sor, int oszlop)
        {
            if (szomszedok == 3)
            {
                modMatrix[sor, oszlop] = 1;
            }
            else if (szomszedok < 2 || szomszedok > 3)
            {
                modMatrix[sor, oszlop] = 0;
            }
            return modMatrix;
        }

        private int[,] MatrixMasolo(int[,] melyikrol, int[,] melyikre)
        {
            for (int sor = 0; sor < sorokSzama + 2; sor++)
            {
                for (int oszlop = 0; oszlop < oszlopokSzama + 2; oszlop++)
                {
                    melyikre[sor, oszlop] = melyikrol[sor, oszlop];
                }
            }
            return melyikre;
        }

        private void KezdoAllapot()
        {
            Random r = new Random();
            for (int sor = 0; sor < sorokSzama + 2; sor++)
            {
                for (int oszlop = 0; oszlop < oszlopokSzama + 2; oszlop++)
                {
                    if (sor == 0 || sor == sorokSzama + 1 ||
                        oszlop == 0 || oszlop == oszlopokSzama + 1)
                    {
                        matrix[sor, oszlop] = 0;
                    }
                    else
                    {
                        matrix[sor, oszlop] = r.Next(0, 2);
                    }
                }
            }
        }

        private void Megjelenit()
        {
            Console.Clear();
            for (int sor = 0; sor < sorokSzama + 2; sor++)
            {
                for (int oszlop = 0; oszlop < oszlopokSzama + 2; oszlop++)
                {
                    if (sor == 0 || sor == sorokSzama + 1 ||
                        oszlop == 0 || oszlop == oszlopokSzama + 1)
                    {
                        Console.Write("X");
                    }
                    else if (matrix[sor, oszlop] == 0) Console.Write(" ");
                    else Console.Write("█", Encoding.UTF8);
                }
                Console.WriteLine();
            }
        }
    }
}
