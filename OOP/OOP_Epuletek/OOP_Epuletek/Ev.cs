using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Epuletek
{
    class Ev
    {
        public int Kezdo { get; set; }
        public int Veg { get; set; }

        public Ev(string kezdet, string veg)
        {
            Kezdo = kezdet == "" ? 0 : Convert.ToInt32(kezdet);
            Veg = veg == "" ? 0 : Convert.ToInt32(veg);
        }
    }
}
