using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dolgozat_Vigh_Akos
{
    class Ajtok
    {
        public double Ajto_szelesseg { get; set; }
        public double Ajto_magassag { get; set; }

        public Ajtok(double szelesseg, double magassag)
        {
            Ajto_szelesseg = szelesseg;
            Ajto_magassag = magassag;
        }
    }
}
