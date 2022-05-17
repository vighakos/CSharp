using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Decoder
{
    class Karakter
    {
        public string Betu;
        public int[,] KarakterMatrix;

        public Karakter(List<string> sorok)
        {
            Betu = sorok[0];
            KarakterMatrix = new int[7, 4];

            for (int sor = 0; sor < 7; sor++)
            {
                for (int oszlop = 0; oszlop < 4; oszlop++)
                {
                    KarakterMatrix[sor, oszlop] = Convert.ToInt32(sorok[sor + 1][oszlop].ToString());
                }
            }
        }

        public void Megjelenit()
        {
            Console.WriteLine();
            for (int sor = 0; sor < 7; sor++)
            {
                Console.Write("\t");
                for (int oszlop = 0; oszlop < 4; oszlop++)
                {
                    if (KarakterMatrix[sor, oszlop] == 1)
                        Console.Write("█");
                    else
                        Console.Write(" ");
                }
                Console.WriteLine();
            }
        }

        public bool Felismer(List<Karakter> karakterbank)
        {
            for (int i = 0; i < karakterbank.Count; i++)
            {
                bool egyezes = true;
                for (int sor = 0; sor < 7; sor++)
                {
                    for (int oszlop = 0; oszlop < 4; oszlop++)
                    {
                        if (KarakterMatrix[sor, oszlop] != karakterbank[i].KarakterMatrix[sor,oszlop])
                        {
                            egyezes = false;
                        }
                    }
                }

                if (egyezes)
                {
                    Betu = karakterbank[i].Betu;
                    return true;
                }
            }
            return false;
        }
    }
}
