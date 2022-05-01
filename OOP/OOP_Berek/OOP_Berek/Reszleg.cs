using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Berek
{
    class Reszleg
    {
        public string Nev;
        public double FizSum, Fo, AtlagFiz;

        public Reszleg(string nev)
        {
            Nev = nev;
            FizSum = 0;
            Fo = 0;
            AtlagFiz = 0;
        }

        public void Kiir()
        {
            Console.WriteLine($"\t{Nev}: {AtlagFiz} Ft");
        }
    }
}
