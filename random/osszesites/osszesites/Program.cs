using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace osszesites
{
    class Program
    {
        static List<string> adatok = new List<string>();
        static void Main(string[] args)
        {
            int i = 0;
            bool tovabb = true;
            while (tovabb)
            {
                i++;
                tovabb = Beolvas(i);
            }
            Console.WriteLine($"{i-1} állomány beolvasva, amelyben összesen {adatok.Count} elemet találtam");

            Console.ReadKey();
        }

        private static bool Beolvas(int i)
        {
            bool tovabb = true;
            try
            {
                StreamReader be = new StreamReader($"{i}.csv");
                while (!be.EndOfStream)
                {
                    string sor = be.ReadLine();
                    for (int j = 0; j < sor.Split(';').Length; j++)
                    {
                        adatok.Add(sor.Split(';')[j]);
                    }
                }
                be.Close();
            }
            catch (IOException)
            {
                tovabb = false;
            }
            return tovabb;
        }
    }
}
