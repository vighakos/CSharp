using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oopKor
{
    class Kor
    {
        private Koordinata kozeppont;
        private double sugar;

        public bool Letezik { get; set; }

        public Kor(Koordinata kozeppont, Koordinata pont) 
        {
            this.kozeppont = kozeppont;
            sugar = Sugar(kozeppont, pont);

            Letezik = sugar == 0 ? false : true;
        }
        public bool Rajtavane(Koordinata pont) 
        {
            return sugar == Sugar(kozeppont, pont) ? true : false;
        }
        private double Sugar(Koordinata pont1, Koordinata pont2)
        {
            return Math.Sqrt(Math.Pow(pont1.X - pont2.X, 2) + Math.Pow(pont1.Y - pont2.Y, 2));
        }
        public double Kerulet() 
        {
            return 2 * sugar * Math.PI;
        }
        public double Terulet() 
        {
            return sugar * sugar * Math.PI;
        }

    }
}
