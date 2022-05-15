using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _20220509_vigh_akos
{
    class FileAction
    {
        public static List<Adas> Beolvas(string fileName)
        {
            List<Adas> data = new List<Adas>();
            try
            {
                StreamReader be = new StreamReader(fileName);
                be.ReadLine();
                while (!be.EndOfStream)
                {
                    data.Add(new Adas(be.ReadLine().Split(';')));
                }
                be.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return data;
        }

        public static int AtszamolPercre(int ora, int perc)
        {
            return ora * 60 + perc;
        }

        public static void Kiir(List<Adas> data)
        {
            try
            {
                StreamWriter ki = new StreamWriter("cb2.txt");
                ki.WriteLine("Kezdes;Nev;AdasDb");
                foreach (Adas item in data)
                {
                    ki.WriteLine($"{AtszamolPercre(item.Ora, item.Perc)};{item.Nev};{item.AdasDb}");
                }
                ki.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
