using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Husvet
{
    class Feladat
    {
        public static List<Talalat> talalatok = Muvelet.toTalalat(Muvelet.Beolvas("talaltok.txt"));
        public static List<Talalat> talalatok2 = Muvelet.toTalalat(Muvelet.Beolvas("talaltok.txt"));
        public static List<PluszTalalat> plusz_talalatok = Muvelet.toPluszTalalat(Muvelet.Beolvas("pluszTalalat.csv"));
        public static double[] pontok = new double[] { 20, 10.5, 6, 3.5, 1};
        public Feladat()
        {
            _1();
        }

        private void _1()
        {
            int pirosTojasok = talalatok.Sum(x => x.Piros);

        }
    }
}
