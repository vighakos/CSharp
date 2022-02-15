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
        static void Main(string[] args)
        {
            Beolvas();

            Console.ReadKey();
        }

        private static void Beolvas()
        {
            try
            {
                for (int i = 0; i < Int32.MaxValue; i++)
                {
                    if (File.Exists(i + ".txt"))
                    {
                        StreamReader be = new StreamReader(i + ".txt");
                        List<int> adatok = new List<int>();
                        while (!be.EndOfStream)
                        {
                            adatok.Add(Convert.ToInt32(be.ReadLine()));
                        }
                    }
                }
            }
            catch (IOException)
            {
                
            }
        }
    }
}
