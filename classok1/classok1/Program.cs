using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classok1
{
    class Program
    {
        static void Main(string[] args)
        {
            Auto sajatAuto = new Auto();
            sajatAuto.GyartasiEv = 2010;
            sajatAuto.Loero = 150.2;
            sajatAuto.Rendszam = "AAA-123";

            Auto szomszed = new Auto() 
            {
                GyartasiEv = 2020,
                Loero = 66.3,
                Rendszam = "asd-613"
            };

            Auto felesegAutoja = new Auto("BAB-555", 2016, 99999);
            
            Auto lopottAuto = new Auto("OOO-699");

            sajatAuto.Kiir();
            Console.WriteLine("--------------------");
            szomszed.Kiir();
            Console.WriteLine("--------------------");
            lopottAuto.Kiir();

            //Console.WriteLine($"A saját autó kora: {sajatAuto.Kor()}");

            Console.ReadKey();
        }
    }
}
