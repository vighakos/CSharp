using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Loot
{
    class Zona
    {
        public string Nev { get; set; }
        public List<string> InstanceNevek { get; set; }

        public Zona(string nev, List<string> instanev)
        {
            Nev = nev;
            InstanceNevek = instanev;
        }

        public string Kiir()
        {
            return $"{Nev} - {InstanceNevek.Count}";
        }
    }
}
