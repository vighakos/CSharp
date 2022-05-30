using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace OOP_Decoder
{
    class Fajl
    {
        public static List<Karakter> Beolvas(string fileName)
        {
            List<Karakter> karakterBank = new List<Karakter>();

            try
            {
                StreamReader be = new StreamReader(fileName);
                List<string> sorok = new List<string>();
                while (!be.EndOfStream)
                {
                    sorok.Add(be.ReadLine());
                    if (sorok.Count == 8)
                    {
                        karakterBank.Add(new Karakter(sorok));
                        sorok.Clear();
                    }
                }
                be.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return karakterBank;
        }
    }
}
