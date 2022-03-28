using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Tavak
{
    class Tavak
    {
        public string Nev { get; set; }
        public string Tipus { get; set; }
        public double Terulet { get; set; }
        public int Vizgyujto { get; set; }
        public bool Egyedi { get; set; }

        public Tavak(string sor)
        {
            Nev = sor.Split('\t')[1];
            Tipus = sor.Split('\t')[2] == "" ? "0" : sor.Split('\t')[2];
            Terulet = sor.Split('\t')[3] == "" ? 0 : Convert.ToDouble(sor.Split('\t')[3]);
            Vizgyujto = sor.Split('\t')[4] == "" ? 0 : Convert.ToInt32(sor.Split('\t')[4]);
            Egyedi = true;
        }

        public void Kiir()
        {
            Console.WriteLine($"\t{Nev}");
        }
    }
}
