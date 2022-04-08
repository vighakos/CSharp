using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Foci
{
    class Klub
    {
        public string Nev { get; set; }
        public string Orszag { get; set; }
        public int Jatekosszam { get; set; }
        public Klub(string nev, string orszag)
        {
            Nev = nev;
            Orszag = orszag;
        }
    }
}
