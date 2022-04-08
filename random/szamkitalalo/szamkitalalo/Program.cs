using System;

namespace szamkitalalo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Gondoltam egy számra 1 és 1000 között. Találd ki :DDDDDDDDD");
            Random r = new Random();
            int szam = r.Next(1, 1000);
            bool megvan = false;
            while (!megvan)
            {
                int talal = Convert.ToInt32(Console.ReadLine());
                if (talal > szam)
                {
                    Console.Write("Kisebb tippet kérek: ");
                }
                else if (talal < szam)
                {
                    Console.Write("Nagyobb tippet kérek: ");
                }
                else if (talal == szam)
                {
                    Console.Write("Talált :)");
                    megvan = true;
                }
            }
            
            Console.ReadKey();
        }
    }
}
