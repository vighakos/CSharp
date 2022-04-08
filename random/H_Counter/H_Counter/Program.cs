using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace H_Counter
{
    class Program
    {
        static List<string> adatok = new List<string>();
        static int osszes_h = 0;
        static void Main(string[] args)
        {
            if (File.Exists("h.txt"))
            {
                Beolvas();
            }

            Feldolgoz();

            Kiir();

            Console.ReadKey();
        }


        private static void Feldolgoz()
        {
            Console.Write("Nyomd meg a +/- gombot az összes H növeléséhez vagy csökkentéséhez! ");

            string valasz = Console.ReadLine();

            switch (valasz)
            {
                case "+":
                    Novel();
                    break;

                case "-":
                    Csokkent();
                    break;

                default:
                    break;
            }
        }

        private static void Csokkent()
        {
            osszes_h--;
            adatok.Add($"{DateTime.Now} - {osszes_h}");
            Console.WriteLine($"{DateTime.Now} - {osszes_h}");
            Console.WriteLine();
            Feldolgoz();
        }

        private static void Novel()
        {
            osszes_h++;
            adatok.Add($"{DateTime.Now} - {osszes_h}");
            Console.WriteLine($"{DateTime.Now} - {osszes_h}");
            Console.WriteLine();
            Feldolgoz();
        }

        private static void Kiir()
        {
            try
            {
                StreamWriter ki = new StreamWriter("h.txt");

                for (int i = 0; i < adatok.Count; i++)
                {
                    ki.WriteLine(adatok[i]);
                }
                ki.Close();

                Console.WriteLine("Adatok fájlba írva");
            }
            catch (IOException)
            {
                Console.WriteLine("Hiba");
            }
        }

        private static void Beolvas()
        {
            try
            {
                StreamReader be = new StreamReader("h.txt", Encoding.Default);
                while (!be.EndOfStream)
                {
                    adatok.Add(be.ReadLine());
                }

                be.Close();

                osszes_h = Convert.ToInt32(adatok[adatok.Count-1].Split('-')[1].Trim());

                Console.WriteLine($"Összes H: {osszes_h}");
            }
            catch (IOException)
            {
                
            }
        }
    }
}
