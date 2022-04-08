using System;

namespace szamkitalal_hazi
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Gondolj egy egész számra 1 és 100 között!\n - : \tKisebb\n + : \tNagyobb\nigen : \tVége\nENTER : Kezdés");
            Console.WriteLine("-----------------------");
            Console.ReadKey();
            bool talalt = false;
            int also_hatar = 1;
            int felso_hatar = 101;
            int tipp = (felso_hatar - also_hatar) / 2;
            Console.WriteLine($"Erre gondoltál? {tipp}");
            while (!talalt)
            {
                switch (Console.ReadLine())
                {
                    case "-":
                        felso_hatar = tipp;
                        tipp = also_hatar + (felso_hatar - also_hatar) / 2;
                        Console.WriteLine($"Erre gondoltál? {tipp}");
                        break;
                    case "+":
                        also_hatar = tipp;
                        tipp = also_hatar + (felso_hatar - also_hatar) / 2;
                        Console.WriteLine($"Erre gondoltál? {tipp}");
                        break;
                    case "igen":
                        Console.WriteLine("Jó játék volt");
                        talalt = true;
                        break;
                    case "i":
                        Console.WriteLine("Jó játék volt");
                        talalt = true;
                        break;
                    case "vissza":
                        tipp = 50;
                        also_hatar = 1;
                        felso_hatar = 101;
                        Console.WriteLine("Tipp visszaállítva 50-re");
                        break;
                    default:
                        Console.WriteLine("-----------------------");
                        Console.WriteLine(" - : \tKisebb\n + : \tNagyobb\nigen : \tVége\nvissza: Tipp vissza 50-re");
                        Console.WriteLine("-----------------------");
                        break;
                }
            }
            Console.ReadKey();
        }
    }
}
