using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Husvet
{
    class Talalat
    {
        public string Nev;
        public int Piros, Sarga, Zold, Kek, Nyuszi;

        public Talalat(string[] sor)
        {
            Nev = sor[0];
            Piros = Convert.ToInt32(sor[1]);
            Sarga = Convert.ToInt32(sor[2]);
            Zold = Convert.ToInt32(sor[3]);
            Kek = Convert.ToInt32(sor[4]);
            Nyuszi = Convert.ToInt32(sor[5]);
        }

        public Talalat(string nev, List<int> tojasok)
        {
            Nev = nev;
            Piros = tojasok[1];
            Sarga = tojasok[2];
            Zold = tojasok[3];
            Kek = tojasok[4];
            Nyuszi = tojasok[5];
        }
    }
}
