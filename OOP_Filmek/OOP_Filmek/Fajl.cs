using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace OOP_Filmek
{
    class Fajl
    {
        public static List<Film> Beolvas(string fileName)
        {
            List<Film> adatok = new List<Film>();

            try
            {
                StreamReader be = new StreamReader(fileName, Encoding.Default);
                be.ReadLine();

                while (!be.EndOfStream)
                {
                    adatok.Add(new Film(be.ReadLine().Split(';')));
                }
                be.Close();
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("nincs fájl");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return adatok;
        }

        public static void FajlbaIr(List<Film> adatok)
        {
            try
            {
                StreamWriter ki = new StreamWriter("adatok2.csv");

                for (int i = 0; i < adatok.Count; i++)
                {
                    ki.WriteLine(adatok[i].Szoveg());
                }
                ki.Close();
                Console.WriteLine("\n9. feladat: Fájlbaírás kész");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
