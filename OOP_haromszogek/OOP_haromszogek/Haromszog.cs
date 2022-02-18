using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_haromszogek
{
    class Haromszog
    {
        public Koordinatak a { get; set; }
        public Koordinatak b { get; set; }
        public Koordinatak c { get; set; }

        private double a_oldal()
        {
            return Math.Sqrt(Math.Pow(b.x - c.x, 2) + Math.Pow(b.y - c.y, 2));
        }
        private double b_oldal()
        {
            return Math.Sqrt(Math.Pow(c.x - a.x, 2) + Math.Pow(c.y - a.y, 2));
        }
        private double c_oldal()
        {
            return Math.Sqrt(Math.Pow(b.x - a.x, 2) + Math.Pow(b.y - a.y, 2));
        }
        public double Kerulet()
        {
            return a_oldal() + b_oldal() + c_oldal();
        }
        public bool Lehetseges()
        {
            if (a_oldal() + b_oldal() > c_oldal() && a_oldal() + c_oldal() > b_oldal() && b_oldal() + c_oldal() > a_oldal())
            {
                return true;
            }

            return false;
        }


        public Haromszog(List<Koordinatak> koordinatak) 
        {
            a = koordinatak[0];
            b = koordinatak[1];
            c = koordinatak[2];
        }



    }
}
