using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace OOP_Husvet
{
    class Muvelet
    {
        public static List<string> Beolvas(string fileName)
        {
            List<string> adatok = new List<string>();

            try
            {
                StreamReader be = new StreamReader(fileName);
                be.ReadLine();
                while (!be.EndOfStream)
                {
                    adatok.Add(be.ReadLine());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return adatok;
        }
        public static List<Talalat> toTalalat(List<string> data)
        {
            List<Talalat> lista = new List<Talalat>();
            for (int i = 0; i < data.Count; i++)
            {
                lista.Add(new Talalat(data[i].Split(';')));
            }
            return lista;
        }

        public static List<PluszTalalat> toPluszTalalat(List<string> data)
        {
            List<PluszTalalat> lista = new List<PluszTalalat>();
            for (int i = 0; i < data.Count; i++)
            {
                lista.Add(new PluszTalalat(data[i].Split(';')));
            }
            return lista;
        }
    }
}
