using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Husvet
{
    class PluszTalalat
    {
        public string Nev;
        public double talalat1, talalat2, talalat3, talalat4, talalat5;

        public PluszTalalat(string[] sor)
        {
            Nev = sor[0];
            talalat1 = Convert.ToDouble(sor[1]);
            talalat2 = Convert.ToDouble(sor[2]);
            talalat3 = Convert.ToDouble(sor[3]);
            talalat4 = Convert.ToDouble(sor[4]);
            talalat5 = Convert.ToDouble(sor[5]);
        }
    }
}
