using System;

namespace elso_konzol
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Adj meg egy számot: ");
            int szam = Console.Read();

            for (int i = 0; i < szam; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    Console.Write("* ");
                }
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
