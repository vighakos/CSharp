using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Epuletek
{
    class Epulet
    {
        public string Nev { get; set; }
        public string Telepules { get; set; }
        public double Magassag { get; set; }
        public int Emeletek { get; set; }
        public Evek Ev { get; set; }

        public Epulet(string[] sor)
        {
            Nev = sor[0];
            Telepules = sor[1];
            Magassag = sor[2] == "" ? 0 : Convert.ToDouble(sor[2]);
            Emeletek = sor[3] == "" ? 0 : Convert.ToInt32(sor[3]);
            Ev = new Evek(sor[4], sor[5]);
        }

        public void Kiir()
        {
            Console.WriteLine($"\n\tNév: {Nev}\n\tTelepülés: {Telepules}\n\tMagasság: {Magassag}m\n\tEmeletek: {Emeletek}\n\tÉpítés évei: {Ev.Kezdet} - {Ev.Veg}");
        }
        
        public string String()
        {
            return $"{Nev};{Telepules};{Magassag};{Emeletek};{Ev.Kezdet};{Ev.Veg}";
        }
    }
}
