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
        public double alfa { get; set; }
        public double beta { get; set; }
        public double gamma { get; set; }
        public Haromszog(List<Koordinatak> koordinatak) 
        {
            a = koordinatak[0];
            b = koordinatak[1];
            c = koordinatak[2];

            alfa = Szog(a, b, c);
            beta = Szog(b, a, c);
            gamma = Szog(c, a, b);
        }
        private Koordinatak Vektor(Koordinatak a, Koordinatak b) 
        {
            Koordinatak eredmeny = new Koordinatak()
            {
                x = b.x - a.x,
                y = b.y - a.y
            };

            return eredmeny;
        }

        public double a_oldal()
        {
            return Math.Sqrt(Math.Pow(b.x - c.x, 2) + Math.Pow(b.y - c.y, 2));
        }
        public double b_oldal()
        {
            return Math.Sqrt(Math.Pow(c.x - a.x, 2) + Math.Pow(c.y - a.y, 2));
        }
        public double c_oldal()
        {
            return Math.Sqrt(Math.Pow(b.x - a.x, 2) + Math.Pow(b.y - a.y, 2));
        }
        
        public bool Letezik()
        {
            if (a_oldal() + b_oldal() > c_oldal() && 
                a_oldal() + c_oldal() > b_oldal() && 
                b_oldal() + c_oldal() > a_oldal())
            {
                return true;
            }

            return false;
        }
        public double Kerulet()
        {
            return a_oldal() + b_oldal() + c_oldal();
        }
        public double Terulet() 
        {
            double s = Kerulet()/2;

            return Math.Sqrt(s * (s - a_oldal()) * (s - b_oldal()) * (s - c_oldal()));
        }
        public bool Derekszogue() 
        {
            if (Math.Pow(a_oldal(), 2) + Math.Pow(b_oldal(), 2) == Math.Pow(c_oldal(), 2)) return true;
            else if (Math.Pow(c_oldal(), 2) + Math.Pow(b_oldal(), 2) == Math.Pow(a_oldal(), 2)) return true;
            else if (Math.Pow(a_oldal(), 2) + Math.Pow(c_oldal(), 2) == Math.Pow(b_oldal(), 2)) return true;
            return false;
        }
        public double Szog(Koordinatak a, Koordinatak b, Koordinatak c) 
        {
            Koordinatak vektorA = Vektor(a, b);
            Koordinatak vektorB = Vektor(a, c);
            double cosinus = (vektorA.x * vektorB.x + vektorA.y * vektorB.y) /
                (Math.Sqrt(vektorA.x * vektorA.x + vektorA.y * vektorA.y) *
                Math.Sqrt(vektorB.x * vektorB.x + vektorB.y * vektorB.y));

            return Math.Acos(cosinus) * 180 / Math.PI;
        }
    }
}
