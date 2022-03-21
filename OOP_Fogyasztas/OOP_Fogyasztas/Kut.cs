using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Fogyasztas
{
    class Kut
    {
        public string Azon { get; set; }
        public int Osszeg { get; set; }

        public Kut(string azon, int osszeg)
        {
            Azon = azon;
            Osszeg = osszeg;
        }

        public void HozzaAd(int ujosszeg)
        {
            Osszeg += ujosszeg;
        }
    }
}
