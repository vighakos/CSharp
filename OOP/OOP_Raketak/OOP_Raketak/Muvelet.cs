using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace OOP_Raketak
{
    class Muvelet
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
            }

            return data;
        }

        public static List<Raketa> toRaketa(List<string> adatok)
        {
            List<Raketa> data = new List<Raketa>();

            foreach (string item in adatok)
                data.Add(new Raketa(item.Split(';')));

            return data;
        }
        
        public static List<Hivatal> toHivatal(List<string> adatok)
        {
            List<Hivatal> data = new List<Hivatal>();

            foreach (string item in adatok)
                data.Add(new Hivatal(item.Split(';')));

            return data;
        }
    }
}
