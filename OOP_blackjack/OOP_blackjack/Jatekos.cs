using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_blackjack
{
    class Jatekos
    {
        public string Nev { get; set; }
        public List<Kartya> Lapok { get; set; }

        public Jatekos(string nev)
        {
            Nev = nev;
            Lapok = new List<Kartya>();
        }

        public int Pontok()
        {
            int osszpont = 0;
            for (int i = 0; i < Lapok.Count; i++)
            {
                osszpont += Lapok[i].Ertek;
            }

            return osszpont;
        }
    }
}
