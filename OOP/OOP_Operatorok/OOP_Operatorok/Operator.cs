using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Operatorok
{
    class Operator
    {
        public string Nev, Nem, Alakulat, Taktikai, Szarmazas, Oldal;
        public int Kor;

        public Operator(string[] sor)
        {
            Nev = sor[0];
            Nem = sor[1];
            Kor = Convert.ToInt32(sor[2]);
            Alakulat = sor[3];
            Taktikai = sor[4];
            Szarmazas = sor[5];
            Oldal = sor[6];
        }

        public void Kiir()
        {
            Console.WriteLine($"\n\tNév: {Nev}" +
                $"\n\tNem: {Nem}" +
                $"\n\tKor: {Kor}" +
                $"\n\tAlakulat: {Alakulat}" +
                $"\n\tTaktikai: {Taktikai}" +
                $"\n\tSzármazás: {Szarmazas}" +
                $"\n\tOldal: {Oldal}");
        }
    }
}
