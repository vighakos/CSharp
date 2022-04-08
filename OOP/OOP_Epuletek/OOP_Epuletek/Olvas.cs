using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace OOP_Epuletek
{
    class Olvas
    {
        public static List<Epulet> Beolvas(string fajlNev)
        {
            List<Epulet> adatok = new List<Epulet>();

            try
            {
                StreamReader be = new StreamReader(fajlNev);
                be.ReadLine();

                while (!be.EndOfStream)
                {
                    adatok.Add(new Epulet(be.ReadLine().Split(';')));
                }
                be.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return adatok;
        }


    }
}
