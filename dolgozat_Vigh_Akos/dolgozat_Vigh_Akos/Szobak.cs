using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dolgozat_Vigh_Akos
{
    class Szobak
    {
        public double Szoba_szelesseg { get; set; }
        public double Szoba_hosszusag { get; set; }
        public double Szoba_magassag { get; set; }

        public Szobak (double szelesseg, double hosszusag, double magassag)
        {
            Szoba_szelesseg = szelesseg;
            Szoba_hosszusag = hosszusag;
            Szoba_magassag = magassag;
        }
    }
}
