using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_KalapacsVetes
{
    class Dobas
    {
        public string Szoveg;
        public double Szam;

        public Dobas(string dobas)
        {
            Szoveg = dobas;
            if (dobas == "X") Szam = -1;
            else if (dobas == "-") Szam = -2;
            else Szam = Convert.ToDouble(dobas);
        }
    }
}
