using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Pontok
{
    class Pont
    {
        public int Sorszam { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public Pont(string sor)
        {
            Sorszam = SorszamMeghat(sor);
            X = XMeghat(sor);
            Y = YMeghat(sor);
        }

        private int YMeghat(string sor)
        {
            return Convert.ToInt32(sor.Substring(11, 3));
        }

        private int XMeghat(string sor)
        {
            return Convert.ToInt32(sor.Substring(7, 3));
        }

        private int SorszamMeghat(string sor)
        {
            return Convert.ToInt32(sor.Substring(2, 3));
        }
    }
}
