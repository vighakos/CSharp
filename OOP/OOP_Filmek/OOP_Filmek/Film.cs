using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Filmek
{
    class Film
    {
        public string Cim { get; set; }
        public string Rendezo { get; set; }
        public int Ev { get; set; }
        public string Mufaj { get; set; }
        public int Hossz { get; set; }

        public Film(string[] sor)
        {
            Cim = sor[0];
            Rendezo = sor[1];
            Ev = Convert.ToInt32(sor[2]);
            Mufaj = sor[3];
            Hossz = Convert.ToInt32(sor[4]);
        }

        public void Kiir()
        {
            Console.WriteLine($"\n\tCím: {Cim}" +
                $"\n\tRendező: {Rendezo}" +
                $"\n\tÉv: {Ev}" +
                $"\n\tMűfaj: {Mufaj}" +
                $"\n\tHossz: {Hossz} perc");
        }

        public string Szoveg()
        {
            return $"{Cim};{Rendezo};{Ev};{Mufaj};{Hossz}";
        }
    }
}
