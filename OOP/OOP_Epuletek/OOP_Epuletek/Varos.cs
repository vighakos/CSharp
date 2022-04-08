using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Epuletek
{
    class Varos
    {
        public string Nev { get; set; }
        public int Db { get; set; }

        public Varos(string nev)
        {
            Nev = nev;
            Db = 1;
        }

        public void Kiir()
        {
            Console.WriteLine($"\t{Nev} - {Db}");
        }

    }
}
