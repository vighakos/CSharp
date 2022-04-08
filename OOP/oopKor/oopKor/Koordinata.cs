using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oopKor
{
    class Koordinata
    {
        public int X { get; set; }
        public int Y { get; set; }


        public Koordinata(string sor) 
        {
            X = Convert.ToInt32(sor.Split(';')[0].Trim());
            Y = Convert.ToInt32(sor.Split(';')[1].Trim());
        }

    }
}
