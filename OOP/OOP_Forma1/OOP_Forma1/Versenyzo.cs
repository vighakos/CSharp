using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Forma1
{
    class Versenyzo
    {
        public int ID, Rajtszam;
        public string Nev, Szarmazas, Rovidites, Csapatnev;
        public DateTime Szul;

        public Versenyzo(string[] sor)
        {
            ID = Convert.ToInt32(sor[0]);
            Rajtszam = Convert.ToInt32(sor[1]);
            Nev = sor[2];
            Szul = Convert.ToDateTime(sor[3].Replace("-", "."));
            Szarmazas = sor[4];
            Rovidites = sor[5];
            Csapatnev = sor[6];
        }

        public void Kiir()
        {
            Console.WriteLine($"\n\tID: {ID}" +
                $"\n\tRajtszam: {Rajtszam}" +
                $"\n\tNev: {Nev}" +
                $"\n\tSzul: {Szul}" +
                $"\n\tSzarmazas: {Szarmazas}" +
                $"\n\tRovidites: {Rovidites}" +
                $"\n\tCsapatnev: {Csapatnev}");
        }
    }
}
