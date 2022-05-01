using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Forma1
{
    class Eredmeny
    {
        public int PilotaID, NagydijID, RajtPoz, Helyezes, Pontszam, Teljesitett;
        public string Leggyorsabb;

        public Eredmeny(string[] sor)
        {
            PilotaID = Convert.ToInt32(sor[0]);
            NagydijID = Convert.ToInt32(sor[1]);
            RajtPoz = Convert.ToInt32(sor[2]);
            Helyezes = Convert.ToInt32(sor[3]);
            Pontszam = Convert.ToInt32(sor[4]);
            Teljesitett = Convert.ToInt32(sor[5]);
            Leggyorsabb = sor[6];
        }

        public void Kiir()
        {
            Console.WriteLine($"\n\tPilotaID: {PilotaID}" +
                $"\n\tNagydijID: {NagydijID}" +
                $"\n\tRajtPoz: {RajtPoz}" +
                $"\n\tHelyezes: {Helyezes}" +
                $"\n\tPontszam: {Pontszam}" +
                $"\n\tTeljesitett: {Teljesitett}" +
                $"\n\tLeggyorsabb: {Leggyorsabb}");
        }
    }
}
