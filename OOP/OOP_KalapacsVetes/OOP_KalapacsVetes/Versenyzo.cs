using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_KalapacsVetes
{
    class Versenyzo
    {
        public string Nev, Csoport, NemzetEsKod, Nemzet, Kod;
        public List<Dobas> Dobasok;
        public double Eredmeny;

        public Versenyzo(string[] sor)
        {
            Nev = sor[0];
            Csoport = sor[1];
            NemzetEsKod = sor[2];
            Dobasok = new List<Dobas>();
            Dobasok.Add(new Dobas(sor[3]));
            Dobasok.Add(new Dobas(sor[4]));
            Dobasok.Add(new Dobas(sor[5]));
            
            Eredmeny = Dobasok.Max(x => x.Szam);
            Nemzet = sor[2].Split('(')[0].TrimEnd();
            Kod = sor[2].Split('(')[1].Remove(sor[2].Split('(').Length);
        }

        public void Kiir()
        {
            Console.WriteLine($"\n\tNév: {Nev}" +
                $"\n\tCsaopot: {Csoport}" +
                $"\n\tNemzet: {Nemzet}" +
                $"\n\tKód: {Kod}" +
                $"\n\tEredmény: {Eredmeny}");
        }
    }
}
