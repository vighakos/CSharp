using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_blackjack
{
    class Program
    {
        static void Main(string[] args)
        {
            Pakli ujPakli = new Pakli();

            for (int i = 0; i < ujPakli.pakli.Count; i++)
            {
                ujPakli.pakli[i].Kiir();
            }

            Console.ReadKey();
        }
    }
}
