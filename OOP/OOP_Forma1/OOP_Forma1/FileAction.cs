using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace OOP_Forma1
{
    class FileAction
    {
        public static List<string> ReadFile(string fileName)
        {
            List<string> data = new List<string>();
            try
            {
                StreamReader be = new StreamReader(fileName);
                be.ReadLine();

                while (!be.EndOfStream)
                {
                    data.Add(be.ReadLine());
                }
                be.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            return data;
        }

        public static List<Eredmeny> toEredmeny(List<string> data)
        {
            List<Eredmeny> eredmenyek = new List<Eredmeny>();
            foreach (string item in data)
            {
                eredmenyek.Add(new Eredmeny(item.Split(';')));
            }
            return eredmenyek;
        }

        public static List<Nagydij> toNagydij(List<string> data)
        {
            List<Nagydij> nagydijak = new List<Nagydij>();
            foreach (string item in data)
            {
                nagydijak.Add(new Nagydij(item.Split(';')));
            }
            return nagydijak;
        }

        public static List<Versenyzo> toVersenyzo(List<string> data)
        {
            List<Versenyzo> versenyzok = new List<Versenyzo>();
            foreach (string item in data)
            {
                versenyzok.Add(new Versenyzo(item.Split(';')));
            }
            return versenyzok;
        }
    }
}
