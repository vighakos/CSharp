using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Cicak
{
    class Foglalkozas
    {
        public string Nev { get; set;}
        public int Db { get; set;}
        
        public Foglalkozas(string nev)
        {
            Nev = nev;
            Db = 1;
        }
    }
}
