using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Toto
{
    class Toto
    {
        public int Ev { get; set; }
        public int Het { get; set; }
        public int Fordulo { get; set; }
        public int T13p1 { get; set; }
        public int Ny13p1 { get; set; }
        public string Eredmenyek { get; set; }

        public Toto(string sor)
        {
            Ev = Convert.ToInt32(sor.Split(';')[0]);
            Het = Convert.ToInt32(sor.Split(';')[1]);
            Fordulo = Convert.ToInt32(sor.Split(';')[2]);
            T13p1 = Convert.ToInt32(sor.Split(';')[3]);
            Ny13p1 = Convert.ToInt32(sor.Split(';')[4]);
            Eredmenyek = sor.Split(';')[5];
        }

        public void Kiir()
        {
            Console.WriteLine($"\tÉv: {Ev}. \n\tHét: {Het}. \n\tForduló: {Fordulo}. \n\tTelitalálat: {T13p1} db \n\tNyeremény: {Ny13p1} Ft \n\tEredmények: {Eredmenyek}");
        }

        public bool VolteDontetlen()
        {
            if (Eredmenyek.Contains("X")) return true;
            return false;
        }
    }
}
