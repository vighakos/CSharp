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

            Console.WriteLine(uj.Lehetseges() ? $"A háromszög kerülete: {uj.Kerulet()}" : "Nem lehet háromszög");

            /*
            if (uj.Egyenese())
            {
                Console.WriteLine($"A háromszög kerülete: {uj.Kerulet()}");
            }
            else
            {
                Console.WriteLine("Nem lehet háromszög");
            }*/



            Console.ReadKey();
        }
    }
}
