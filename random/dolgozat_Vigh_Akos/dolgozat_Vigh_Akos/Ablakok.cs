using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dolgozat_Vigh_Akos
{
    class Ablakok
    {
        public double Ablak_szelesseg { get; set; }
        public double Ablak_magassag { get; set; }

        public Ablakok(double szelesseg, double magassag)
        {
            Ablak_szelesseg = szelesseg;
            Ablak_magassag = magassag;
        }
    }
}
