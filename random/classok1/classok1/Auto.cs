using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classok1
{
    class Auto
    {
        public string Rendszam { get; set; }
        public int GyartasiEv { get => gyartasiEv; set => gyartasiEv = value; }

        private int gyartasiEv;
        private int kor;
        public double Loero { get; set; }
         
        //mezők ^

        public Auto(string rendszam, int gyartasiEv, double loero)
        { // konstruktor :D
            Rendszam = rendszam;
            GyartasiEv = gyartasiEv;
            Loero = loero;
        }

        public Auto(){} // még ez is konstruktor :O

        public Auto(string rendszam) //konstruktor :D
        {
            Rendszam = rendszam;
            Random r = new Random();
            GyartasiEv = r.Next(2000, 2023);
            Loero = r.NextDouble() * r.Next(1, 1000);
        }

        public int Kor() //metódus
        {
            kor = 2022 - GyartasiEv;
            return kor;
        }
        
        public void Kiir()
        {
            Console.WriteLine($"Az autó rendszáma: {Rendszam}");
            Console.WriteLine($"Az autó gyártási éve: {GyartasiEv}");
            Console.WriteLine($"Az autó lóereje: {Loero}");
            Console.WriteLine($"Az autó kora: {Kor()}");
        }

    }
}
