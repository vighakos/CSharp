using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Tavak
{
    class Tipusok
    {
        public string Nev { get; set; }
        public double Meret { get; set; }
        public int Db { get; set; }

        public Tipusok(string nev)
        {
            Nev = nev;
            Meret = 0;
            Db = 1;
        }
    }
}