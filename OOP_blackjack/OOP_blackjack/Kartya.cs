using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_blackjack
{
    class Kartya
    {
        public string Szin { get; set; }
        public string Figura { get; set; }
        public int Ertek { get; set; }

        public Kartya(string szin, string figura) 
        {
            Szin = szin;
            Figura = figura;

            try
            {
                Ertek = Convert.ToInt32(figura);
            }
            catch (FormatException)
            {
                if (figura == "A")
                {
                    Ertek = 11;
                }
                else
                {
                    Ertek = 10;
                }
            }
        }

        public void Kiir() 
        {
            Console.WriteLine($"{Szin} {Figura}:\t{Ertek}");
        }
    }
}
