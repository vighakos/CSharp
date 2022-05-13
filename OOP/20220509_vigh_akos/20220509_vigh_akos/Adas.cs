using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20220509_vigh_akos
{
    class Adas
    {
        public int Ora, Perc, AdasDb;
        public string Nev;

        public Adas(string[] sor)
        {
            Ora = Convert.ToInt32(sor[0]);
            Perc = Convert.ToInt32(sor[1]);
            AdasDb = Convert.ToInt32(sor[2]);
            Nev = sor[3];
        }
    }
}
