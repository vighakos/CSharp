using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Raketak
{
    class Raketa
    {
        public string Nev, Orszag;
        public int Suly, Hasznos_teher;
        public double Magassag, Szelesseg;
        public DateTime Elso, Utolso;
        public double HasznosArany;
        public double Terfogat;

        public Raketa(string[] sor)
        {
            Nev = sor[0];
            Orszag = sor[1];
            Suly = Convert.ToInt32(sor[2]);
            Hasznos_teher = Convert.ToInt32(sor[3]);
            Magassag = Convert.ToDouble(sor[4]);
            Szelesseg = Convert.ToDouble(sor[5]);
            Elso = sor[6] == "-" ? Convert.ToDateTime("2024.01.01") : Convert.ToDateTime(sor[6]);
            Utolso = sor[7] == "-" ? Convert.ToDateTime("2024.01.01") : Convert.ToDateTime(sor[7]);
            HasznosArany = Hasznos_teher / Suly;
            Terfogat = Math.PI * Math.Pow(Szelesseg / 2, 2) * Magassag;
        }

        public Raketa()
        {

        }
    }
}
