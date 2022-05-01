using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace OOP_Nyelvvizsga
{
    class FileAction
    {
        public static List<string> ReadFile(string file) 
        {
            try
            {
                List<string> adatok = new List<string>();
                StreamReader be = new StreamReader(file);
                be.ReadLine();
                while (!be.EndOfStream)
                {
                    adatok.Add(be.ReadLine());
                }
                be.Close();
                return adatok;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public static List<Vizsga> toVizsga(List<string> data)
        {
            List<Vizsga> lista = new List<Vizsga>();
            for (int i = 0; i < data.Count; i++)
            {
                lista.Add(new Vizsga(data[i]));
            }
            return lista;
        }

        public static List<Jelentkezo> toJelentkezo(List<string> data)
        {
            List<Jelentkezo> lista = new List<Jelentkezo>();
            for (int i = 0; i < data.Count; i++)
            {
                lista.Add(new Jelentkezo(data[i]));
            }
            return lista;
        }
    }
}
