using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace OOP_Gazdasag
{
    class Fajl
    {
        public static string SorOszlop(string fajlNev)
        {
            int sor = 0, oszlop = 0;

            try
            {
                StreamReader r = new StreamReader(fajlNev);
                while (!r.EndOfStream)
                {
                    oszlop = r.ReadLine().Length;
                    sor++;
                }
                r.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return sor + " " + oszlop;
        }

        public static string[,] Beolvas(string fajlNev, int sor, int oszlop)
        {
            string[,] terulet = new string[sor, oszlop];
            try
            {
                StreamReader be = new StreamReader(fajlNev);
                int sorszam = 0;

                while (!be.EndOfStream)
                {
                    string beolvas = be.ReadLine();
                    for (int i = 0; i < beolvas.Length; i++)
                    {
                        terulet[sorszam, i] = beolvas[i].ToString();
                    }
                    sorszam++;
                }
                be.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return terulet;
        }
    }
}
