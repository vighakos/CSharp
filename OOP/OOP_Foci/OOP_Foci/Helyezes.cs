using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Foci
{
    class Helyezes
    {
        public int Ev2013 { get; set; }
        public int Ev2014 { get; set; }

        public Helyezes(string ev2014, string ev2013)
        {
            Ev2014 = ev2014 != "" ? Convert.ToInt32(ev2014) : 0;
            Ev2013 = ev2013 != "" ? Convert.ToInt32(ev2013) : 0;
        }
    }
}
