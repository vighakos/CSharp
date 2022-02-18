using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_haromszogek
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Készíts saját osztályt, amely egy 3szög 
             * 3 pontjának koordinátáit tárolja, amelyek
             * megmondják a 3szög kerületét, területét, 
             * derékszögű-e
            */
            
            List<Koordinatak> koordinatak = new List<Koordinatak>();

            for (int i = 0; i < 3; i++)
            {
                Console.Write("Kérem a koordinátákat szóközzel elválasztva: ");
                string sor = Console.ReadLine();
                koordinatak.Add(new Koordinatak(sor));
            }

            Haromszog uj = new Haromszog(koordinatak);


            if (uj.Letezik())
            {
                Console.WriteLine("\nA háromszög adatai:");
                Console.WriteLine("Oldalainak hossza:");
                Console.WriteLine($"\ta - {uj.a_oldal()}");
                Console.WriteLine($"\tb - {uj.b_oldal()}");
                Console.WriteLine($"\tc - {uj.c_oldal()}");
                Console.WriteLine($"\nKerülete: {uj.Kerulet()}");
                Console.WriteLine($"Területe: {uj.Terulet()}");
                Console.WriteLine($"\nSzögei:");
                Console.WriteLine($"\talfa - {uj.alfa}");
                Console.WriteLine($"\tbeta - {uj.beta}");
                Console.WriteLine($"\tgamma - {uj.gamma}");

            }
            else
            {
                Console.WriteLine("Nem lehet 3szög");
            }

            Console.ReadKey();
        }
    }
}
