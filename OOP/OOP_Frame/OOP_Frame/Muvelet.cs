using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace OOP_Frame
{
    class Muvelet
    {
        public static List<Frame> Beolvas(string fileName)
        {
            List<Frame> adatok = new List<Frame>();

            try
            {
                StreamReader be = new StreamReader(fileName);
                be.ReadLine();

                while (!be.EndOfStream)
                {
                    adatok.Add(new Frame(be.ReadLine().Split(';')));
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
