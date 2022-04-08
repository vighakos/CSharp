using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace classok2
{
    class Program
    {
        static void Main(string[] args)
        {
            Cica macska1 = new Cica("Urambátyám");
            Thread.Sleep(100);
            Cica macska2 = new Cica("Zsilip");
            Cica macska3 = new Cica("Hurkácska", 24.6, 2);

            Cica macska4 = new Cica();
            macska4.Nev = "Gerzson";
            macska4.Suly = 9.7;
            macska4.Kor = 9999;

            macska1.Kiir();
            macska2.Kiir();

            macska3.GetKor();

            Random r = new Random();
            macska4.Kiir();
            macska4.Fut(r.NextDouble() * r.Next(1,20));
            macska4.Kiir();

            Console.ReadKey();
        }
    }
}
