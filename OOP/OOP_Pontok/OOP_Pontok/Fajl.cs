using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace OOP_Pontok
{
    class Fajl
    {
        public static List<Pont> Beolvas(string fajlNev)
        {
            List<Pont> data = new List<Pont>();

            try
            {
                StreamReader be = new StreamReader(fajlNev);
                while (!be.EndOfStream)
                {
                    data.Add(new Pont(be.ReadLine()));
                }
                be.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return data;
        }
    }
}
