using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Muzsika
{
    class Zene
    {
        public string Eloado { get; set;}
        public string Cim { get; set; }
        public string Album { get; set; }
        public Ido Ido { get; set; }
        public string Felhasznalo { get; set; }
        public int Nepszeruseg { get; set; }
        public Zene(string[] sor)
        {
            Eloado = sor[0];
            Cim = sor[1];
            Album = sor[2];
            Ido = new Ido(sor[3].Split(':'));
            Felhasznalo = sor[4];
            Nepszeruseg = Convert.ToInt32(sor[5]);
        }

        public string String()
        {
            return $"{Eloado};{Cim};{Album};{Ido.String()};{Felhasznalo};{Nepszeruseg}";
        }
    }
}
