using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Nyelvvizsga
{
    class Jelentkezo
    {
        public string Nev, Mobil;
        public int Szul, Vizsgaszam;
        public Vizsga Vizsga;

        public Jelentkezo(string s)
        {
            Nev = s.Split(';')[0];
            Mobil = s.Split(';')[1];
            Szul = Convert.ToInt32(s.Split(';')[2]);
            Vizsgaszam = Convert.ToInt32(s.Split(';')[3]);
        }

        public void VizsgaMeghatarozo(List<Vizsga> vizsgak)
        {
            for (int i = 0; i < vizsgak.Count; i++)
            {
                if (vizsgak[i].Vizsgaszam == this.Vizsgaszam)
                {
                    Vizsga = vizsgak[i];
                }
            }
        }
    }
}
