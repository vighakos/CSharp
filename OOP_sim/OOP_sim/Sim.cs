using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_sim
{
    class Sim
    {
        public string Telszam { get; set;}
        public string Pin { get; set; }
        public string Puk { get; set; }
        public bool Aktiv { get; set; }

        public Sim(string telszam, string pin, string puk) 
        {
            Telszam = telszam;
            Pin = pin;
            Puk = puk;
            Aktiv = true;
        }

    }
}
