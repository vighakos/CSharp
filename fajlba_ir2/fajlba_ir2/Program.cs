using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fajlba_ir2
{
    class Program
    {
        static List<string> adatok = new List<string>();
        static void Main(string[] args)
        {
            // szó/mondat bekér 0 végjelig
            // minden megadott szót/mondatot írjunk a ki.txt állományba

            Beker();
            Kiir(adatok);

            Console.ReadKey();
        }

        private static void Kiir(List<string> adatok)
        {
            try
            {
                StreamWriter ki = new StreamWriter("ki.txt");
                for (int i = 0; i < adatok.Count; i++)
                {
                    ki.WriteLine(adatok[i]);
                }
                ki.Close();
                Console.WriteLine("Adatok kiírva a fájlba");
            }
            catch (IOException)
            {
                Console.WriteLine("Hiba");
            }
        }

        private static void Beker()
        {
            string valasz = "";
            do
            {
                Console.Write("Adj meg egy szót vagy mondatot: ");
                if (valasz != "")
                {
                    valasz = Console.ReadLine();
                    adatok.Add(valasz);
                }
            } while (valasz != "");
        }
    }
}
