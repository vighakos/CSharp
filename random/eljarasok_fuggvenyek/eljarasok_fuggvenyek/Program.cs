using System;

namespace eljarasok_fuggvenyek
{
    class Program
    {
        public static double a, b, c = 0;
        static void Main(string[] args)
        {
            // 4 oldal hossz bekér, k, t meghatároz

            Console.WriteLine("Kérem a 3szög oldalait!");

            double a = Beolvas("a");
            double b = Beolvas("b");
            double c = Beolvas("c");

            if (ellenorzes(a, b, c))
            {
                Console.WriteLine($"Kerület: {Kerulet(a, b, c)}");
                Console.WriteLine($"Terület: {Terulet(a, b, c)}");
            }
            else
            {
                Console.WriteLine("Nincs ilyen 3szög");
            }

            Console.ReadKey();
        }

        private static bool ellenorzes(double a, double b, double c)
        {
            double[] rendezett = new double[] {a, b, c};
            Array.Sort(rendezett);

            if (rendezett[0] + rendezett[1] > rendezett[2])
            {
                return true;
            }

            return false;
        }

        private static double Beolvas(string oldal)
        {
            Console.Write($"{oldal}: ");
            double ertek = Convert.ToDouble(Console.ReadLine());
            return ertek;
        }

        private static double Kerulet(double a, double b, double c)
        {
            return a + b + c;
        }

        private static double Terulet(double a, double b, double c) 
        {
            double s = (a + b + c) / 2;
            return Math.Sqrt(s * (s - a) * (s - b) * (s - c));
        }
    }
}
