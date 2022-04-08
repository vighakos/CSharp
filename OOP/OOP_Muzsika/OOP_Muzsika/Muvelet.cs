using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace OOP_Muzsika
{
    class Muvelet
    {
        public static List<Zene> Zenek(string filename)
        {
            List<Zene> zenek = new List<Zene>();
            try
            {
                StreamReader r = new StreamReader(filename);
                r.ReadLine();
                while (!r.EndOfStream)
                    zenek.Add(new Zene(r.ReadLine().Split(';')));
                r.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return zenek;
        }

        public static void Kiir(string fileName, List<Zene> zenek)
        {
            try
            {
                StreamWriter ki = new StreamWriter(fileName);
                for (int i = 0; i < zenek.Count; i++)
                {
                    ki.WriteLine(zenek[i].String());
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
