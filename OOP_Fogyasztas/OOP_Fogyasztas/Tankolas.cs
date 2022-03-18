using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Fogyasztas
{
    class Tankolas
    {
        public DateTime Datum { get; set; }
        public double Tavolsag { get; set; }
        public double Mennyiseg { get; set; }
        public int Fizet { get; set; }
        public string Azon { get; set; }

        public Tankolas(string sor) 
        {
            Datum = Convert.ToDateTime(sor.Split(';')[0]);
            Tavolsag = Convert.ToDouble(sor.Split(';')[1]);
            Mennyiseg = Convert.ToDouble(sor.Split(';')[2]);
            Fizet = Convert.ToInt32(sor.Split(';')[3]);
            Azon = sor.Split(';')[4];
        }
    }
}
