using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Txt2Srt
{
    class IdozitettFelirat
    {
        public string Ido, Felirat;
        public IdozitettFelirat(string ido, string felirat)
        {
            Ido = ido;
            Felirat = felirat;
        }

        public int SzavakSzama()
        {
            return Felirat.Split(' ').Length;
        }

        public string SrtIdozites()
        {
            string str = "";

            string kezdIdo = Ido.Split('-')[0].Trim();
            string vegIdo = Ido.Split('-')[1].Trim();

            int kezdIdoMin = Convert.ToInt32(kezdIdo.Split(':')[0]);
            int kezdIdoSec = Convert.ToInt32(kezdIdo.Split(':')[1]);

            int vegIdoMin = Convert.ToInt32(vegIdo.Split(':')[0]);
            int vegIdoSec = Convert.ToInt32(vegIdo.Split(':')[1]);

            int kezdidoOra = kezdIdoMin / 60;
            int kezdidoPerc = kezdIdoMin % 60;

            int vegidoOra = vegIdoMin / 60;
            int vegidoPerc = vegIdoMin % 60;

            str += ketKarakter(kezdidoOra) + ":" + ketKarakter(kezdidoPerc) + ":" + ketKarakter(kezdIdoSec);
            str += " --> ";
            str += ketKarakter(vegidoOra) + ":" + ketKarakter(vegidoPerc) + ":" + ketKarakter(vegIdoSec);
            return str;
        }

        private string ketKarakter(int szam)
        {
            if (szam != 0) return szam > 9 ? szam.ToString() : "0" + szam;
            else return "00";
        }
    }
}
