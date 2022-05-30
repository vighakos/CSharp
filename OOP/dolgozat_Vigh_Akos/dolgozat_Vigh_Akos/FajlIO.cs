using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace dolgozat_Vigh_Akos
{
    class FajlIO
    {
        public static string[,] Beolvas(string fajlnev)
        {
            string[,] KarakterMatrix = new string[5, 5];
            try
            {
                StreamReader be = new StreamReader(fajlnev);
                while (!be.EndOfStream)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        string sor = be.ReadLine();
                        for (int j = 0; j < sor.Length; j++)
                        {
                            KarakterMatrix[i, j] = sor[j].ToString();
                        }
                    }
                }
                be.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return KarakterMatrix;
        }
    }
}
