using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Raketak
{
    class Hivatal
    {
        public string Orszag, Nev, Rovidites;
        public int Alapitas;
        public bool Urhajosok, Muhold, Urszonda, Biologiai;

        public Hivatal(string[] sor)
        {
            Orszag = sor[0];
            Nev = sor[1];
            Rovidites = sor[2];
            Alapitas = Convert.ToInt32(sor[3]);
            Urhajosok = sor[4] == "Igen" ? true : false;
            Muhold = sor[5] == "Igen" ? true : false;
            Urszonda = sor[6] == "Igen" ? true : false;
            Biologiai = sor[7] == "Igen" ? true : false;
        }
    }
}
