using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Forma1
{
    class Nagydij
    {
        public int ID, KorokSzama;
        public string Nev, Kontinens;
        public DateTime Nap;

        public Nagydij(string[] sor)
        {
            ID = Convert.ToInt32(sor[0]);
            Nev = sor[1];
            Kontinens = sor[2];
            Nap = Convert.ToDateTime(sor[3].Replace("-", "."));
            KorokSzama = Convert.ToInt32(sor[4]);
        }

        public void Kiir()
        {
            Console.WriteLine($"\n\tID: {ID}" +
                $"\n\tNev: {Nev}" +
                $"\n\tKontinens: {Kontinens}" +
                $"\n\tNap: {Nap}" +
                $"\n\tKorokSzama: {KorokSzama}");
        }
    }
}
