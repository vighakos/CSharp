using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace OOP_Fogyasztas
{
    class Olvas
    {
        static public List<Tankolas> Beolvas(string fileNev)
        {
            List<Tankolas> tankolasok = new List<Tankolas>();

            try
            {
                StreamReader be = new StreamReader(fileNev);
                be.ReadLine();

                while (!be.EndOfStream)
                {
                    tankolasok.Add(new Tankolas(be.ReadLine()));
                }
                be.Close();
            }
            catch (IOException)
            {
                Console.WriteLine("Hiba");
            }

            return tankolasok;
        }
    }
}
