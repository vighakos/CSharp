using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classok2
{
    class Cica
    {
        public string Nev { get; set; }
        public double Suly { get; set; }
        public int Kor { get; set; }


        public Cica(string nev)
        {
            Random r = new Random();
            Nev = nev;
            Suly = r.NextDouble() * r.Next(1, 7);
            Kor = r.Next(1, 16);
        }

        public Cica(string nev, double suly, int kor)
        {
            Nev = nev;
            Suly = suly;
            Kor = kor;
        }

        public Cica() { }

        public void Kiir()
        {
            Console.WriteLine($"A cica neve: {Nev}");
            Console.WriteLine($"A cica súlya: {Suly}");
            Console.WriteLine($"A cica kora: {Kor}");
            Console.WriteLine("-----------------------------");
        }

        public int GetKor()
        {
            int cicakora = 2022 - Kor;
            return cicakora;
        }

        public void Fut(double ido) 
        {
            Suly -= 0.1 * ido;
            Console.WriteLine($"{Nev} futott {ido} ideig");
            Console.WriteLine("-----------------------------");
        }
    }
}
