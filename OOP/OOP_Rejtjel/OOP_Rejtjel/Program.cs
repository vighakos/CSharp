using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Rejtjel
{
    class Program
    {
        static void Main(string[] args)
        {
            _2();

            Console.ReadKey();
        }

        private static void _2()
        {
            Console.WriteLine("2. feladat:");

            Console.Write("\tKérem a kulcsot [HOLD]: ");
            string kulcs = Console.ReadLine().ToUpper();
            if (kulcs == "") kulcs = "HOLD";

            Console.Write("\tKérem az üzenetet [szeretem a csokit]: ");
            string uzenet = Console.ReadLine().ToLower();
            if (uzenet == "") uzenet = "szeretem a csokit";

            ADFGXVrejtjel rejtjel = new ADFGXVrejtjel("kodtabla.txt", uzenet, kulcs);

            Console.WriteLine("5. feladat: " + rejtjel.AtalakitottUzenet());
            Console.WriteLine($"6. feladat: s->{rejtjel.Betupar('s')} x->{rejtjel.Betupar('x')}");
            Console.WriteLine($"7. feladat: A kódszöveg: {rejtjel.Kodszoveg()}");
            Console.WriteLine($"8. feladat: A kódolt üzenet: {rejtjel.KodoltUzenet()}");
        }
    }
}
