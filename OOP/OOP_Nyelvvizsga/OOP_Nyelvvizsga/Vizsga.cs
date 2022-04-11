using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Nyelvvizsga
{
    class Vizsga
    {
        public int Vizsgaszam;
        public DateTime Datum;
        public string Nyelv, Szint;

        public Vizsga(string s)
        {
            Vizsgaszam = Convert.ToInt32(s.Split(';')[0]);
            Datum = Convert.ToDateTime(s.Split(';')[1]);
            Nyelv = s.Split(';')[2];
            Szint = s.Split(';')[3];
        }
    }
}
