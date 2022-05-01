using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Berek
{
    class Ber
    {
        public string Nev, Nem, Reszleg;
        public int Belepes, Fizetes;

        public Ber(string[] sor)
        {
            Nev = sor[0];
            Nem = sor[1];
            Reszleg = sor[2];
            Belepes = Convert.ToInt32(sor[3]);
            Fizetes = Convert.ToInt32(sor[4]);
        }

        public void Kiir()
        {
            Console.WriteLine($"\n\tNév: {Nev}" +
                            $"\n\tNem: {Nem}" +
                            $"\n\tRészleg: {Reszleg}" +
                            $"\n\tBelépés éve: {Belepes}" +
                            $"\n\tFizetés: {Fizetes} Ft");
        }
    }
}
