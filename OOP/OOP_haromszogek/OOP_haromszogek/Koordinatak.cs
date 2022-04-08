using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_haromszogek
{
    class Koordinatak
    {
        public int x { get; set; }
        public int y { get; set; }

        public Koordinatak(string sor)
        {
            x = Convert.ToInt32(sor.Split(' ')[0]);
            y = Convert.ToInt32(sor.Split(' ')[1]);
        }

        public Koordinatak() { }

    }
}
