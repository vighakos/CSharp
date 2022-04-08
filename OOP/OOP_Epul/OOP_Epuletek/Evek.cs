using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Epuletek
{
    class Evek
    {
        public int Kezdet { get; set; }
        public int Veg { get; set; }
        public Evek(string kezdet, string veg)
        {
            Kezdet = kezdet == "" ? 0 : Convert.ToInt32(kezdet);
            Veg = veg == "" ? 0 : Convert.ToInt32(veg);
        }
    }
}
