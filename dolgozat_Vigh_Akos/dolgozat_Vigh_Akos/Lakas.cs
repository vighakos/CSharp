using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dolgozat_Vigh_Akos
{
    class Lakas
    {
        private List<Szobak> Szoba;
        private List<Ajtok> Ajto;
        private List<Ablakok> Ablak;
        
        public Lakas(List<Szobak> szoba, List<Ajtok> ajto, List<Ablakok> ablak) 
        {
            Szoba = szoba;
            Ajto = ajto;
            Ablak = ablak;
        }

        public Lakas() { }

        public double Osszfestek()
        {
            double osszes = 0;
            double ablakterulete = 0;
            double ajtoterulete = 0;
            double padlokterulete = 0;

            for (int i = 0; i < Szoba.Count; i++)
            {
                osszes += 2 * ((Szoba[i].Szoba_hosszusag * Szoba[i].Szoba_magassag) + (Szoba[i].Szoba_hosszusag * Szoba[i].Szoba_szelesseg) + (Szoba[i].Szoba_magassag * Szoba[i].Szoba_szelesseg));
                padlokterulete += Szoba[i].Szoba_hosszusag * Szoba[i].Szoba_szelesseg;
            }
            for (int i = 0; i < Ablak.Count; i++)
            {
                ablakterulete += Ablak[i].Ablak_magassag * Ablak[i].Ablak_szelesseg;
            }
            for (int i = 0; i < Ajto.Count; i++)
            {
                ajtoterulete += Ajto[i].Ajto_magassag * Ajto[i].Ajto_szelesseg;
            }

            return osszes - (ablakterulete + ajtoterulete + padlokterulete);
        }

        public double Osszpadlo()
        {
            double padlokterulete = 0;
            for (int i = 0; i < Szoba.Count; i++)
            {
                padlokterulete += Szoba[i].Szoba_hosszusag * Szoba[i].Szoba_szelesseg;
            }
            return padlokterulete;
        }

    }
}
