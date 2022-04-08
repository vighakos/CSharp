using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Cicak
{
    class Cica
    {
        public string Nev { get; set; }
        public int Kor { get; set; }
        public int Suly { get; set; }
        public string Fajta { get; set; }
        public bool Ivar { get; set; }
        public string Kedvenc { get; set; }
        public string Foglalkozas { get; set; }

        public Cica(string[] sor)
        {
            Nev = sor[0];
            Kor = Convert.ToInt32(sor[1]);
            Suly = Convert.ToInt32(sor[2]);
            Fajta = sor[3];
            Ivar = sor[4] == "Ivartalanított" ? true : false;
            Kedvenc = sor[5];
            Foglalkozas = sor[6];
        }

        public void Kiir()
        {
            Console.WriteLine($"\n\tNév: {Nev}" +
                $"\n\tKor: {Kor} nap" +
                $"\n\tSuly: {Suly} g" +
                $"\n\tFajta: {Fajta}" +
                $"\n\tIvartalanított-e: " + (Ivar ? "Igen" : "Nem") + 
                $"\n\tKedvenc kaja: {Kedvenc}" +
                $"\n\tFoglalkozás: {Foglalkozas}");
        }
    }
}
