using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fajlbe_csv1
{
    class Program
    {
        static void Main(string[] args)
        {
            BeOlvas("fajl.csv");
            
            Console.ReadKey();
        }

        private static void BeOlvas(string fajlNev)
        {
            try
            {
                StreamReader be = new StreamReader(fajlNev, Encoding.Default);
                List<string> adatok = new List<string>();
                while (!be.EndOfStream)
                {
                    string sor = be.ReadLine();
                    for (int i = 0; i < sor.Split(';').Length; i++)
                    {
                        if (sor.Split(';')[i] != "")
                        {
                            adatok.Add(sor.Split(';')[i]);
                        }
                    }
                }
                be.Close();
                Console.WriteLine($"Az állomány {adatok.Count} elemet olvasott be");
                Kiir(adatok);
            }
            catch (IOException)
            {
                Console.WriteLine("Hiba");
            }
        }

        private static void Kiir(List<string> adatok)
        {
            for (int i = 0; i < adatok.Count; i++)
            {
                Console.WriteLine(adatok[i]);
            }
        }
    }
}
