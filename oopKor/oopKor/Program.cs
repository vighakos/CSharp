using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oopKor
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             *   kör középpontja és egy pont amin átmegy a kör. 
             *   két pontból lehet-e kör, ha igen akkor ker ter
             *   másik pont koordinátái és megnézzük, hogy a 
             *   körvonalon van-e
             */

            Kor kor = AdatBeolvasas();
            Koordinata pont = PontBekeres();

            if (kor.Letezik)
            {
                Kiir(kor, pont);
            }
            else
            {
                Console.WriteLine("Nem létezik a kör");
            }
            


            Console.ReadKey();
        }

        private static void Kiir(Kor kor, Koordinata pont)
        {
            Console.WriteLine("A kör adatai:");
            Console.WriteLine($"\tA kör kerülete: {kor.Kerulet()}");
            Console.WriteLine($"\tA kör területe: {kor.Terulet()}");
            Console.WriteLine($"\tA megadott pont a körön " + (kor.Rajtavane(pont) ? "van" : "nincs"));
        }

        private static Koordinata PontBekeres()
        {
            Console.Write("Kérek egy tetszőleges pontot (x;y): ");
            return new Koordinata(Console.ReadLine());
        }

        private static Kor AdatBeolvasas()
        {
            Console.Write("Kérem a kör középpontját (x;y): ");
            Koordinata kozeppont = new Koordinata(Console.ReadLine());

            Console.Write("Kérem a körvonal egyik pontját (x;y): ");
            Koordinata pont = new Koordinata(Console.ReadLine());

            return new Kor(kozeppont, pont);            
        }
    }
}
