using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace fajlbe
{
    class Program
    {
        static void Main(string[] args)
        {
            FajlOlvasas();

            Console.ReadKey();
        }

        private static void FajlOlvasas()
        {
            try
            {
                StreamReader olvas = new StreamReader("be.txt");
                List<string> adatok = new List<string>();
                while (!olvas.EndOfStream)
                {
                    adatok.Add(olvas.ReadLine());
                }
                olvas.Close();
                Console.WriteLine("Sikeres beolvasás :)");
                Kiiras(adatok);
            }
            catch (IOException)
            {
                Console.WriteLine("Hiba");
            }
        }

        private static void Kiiras(List<string> adatok)
        {
            Console.WriteLine("A fájl tartalma:\n----------------------");
            foreach (string sor in adatok)
            {
                Console.WriteLine(sor);
            }
        }
    }
}
