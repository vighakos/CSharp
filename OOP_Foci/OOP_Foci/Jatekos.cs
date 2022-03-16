using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Foci
{
    class Jatekos
    {
        public string Nev { get; set; }
        public Klub Klub { get; set; }
        public Helyezes Helyezes { get; set; }
        public string SzulHely { get; set; }
        public int Eletkor { get => eletkor; set => eletkor = value; }
        private int eletkor;

        public Jatekos(string sor)
        {
            Helyezes = new Helyezes(sor.Split(';')[0], sor.Split(';')[1]);
            Nev = sor.Split(';')[2];
            Klub = new Klub(sor.Split(';')[3], sor.Split(';')[4]);
            SzulHely = sor.Split(';')[5];
            Eletkor = Convert.ToInt32(sor.Split(';')[6]);
        }

    }
}
