using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace OOP_Txt2Srt
{
    class Fajl
    {
        public static List<IdozitettFelirat> Beolvas(string filename)
        {
            List<IdozitettFelirat> data = new List<IdozitettFelirat>();

            try
            {
                StreamReader be = new StreamReader(filename);

                while (!be.EndOfStream)
                {
                    data.Add(new IdozitettFelirat(be.ReadLine(), be.ReadLine()));
                }
                be.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return data;
        }

        public static void Kiir(List<IdozitettFelirat> data)
        {
            try
            {
                int db = 1;
                StreamWriter ki = new StreamWriter("felirat.srt");
                foreach (IdozitettFelirat item in data)
                {
                    ki.WriteLine(db);
                    ki.WriteLine(item.SrtIdozites());
                    ki.WriteLine(item.Felirat);
                    ki.WriteLine();
                    db++;
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
