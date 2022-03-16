using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace OOP_Foci
{
    class Olvas
    {
        static public List<Jatekos> Beolvas(string fileNev)
        {
            List<Jatekos> jatekosok = new List<Jatekos>();

            try
            {
                StreamReader be = new StreamReader(fileNev);

                be.ReadLine();

                while (!be.EndOfStream)
                {
                    jatekosok.Add(new Jatekos(be.ReadLine()));
                }
                be.Close();
            }
            catch (IOException)
            {
                Console.WriteLine("Hiba");
            }

            return jatekosok;
        }
    }
}
