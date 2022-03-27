using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Muzsika
{
    class Ido
    {
        public int Perc { get; set; }
        public int Mp { get; set; }
        public int Teljes { get; set; }
        public Ido(string[] sor)
        {
            Perc = Convert.ToInt32(sor[0]);
            Mp = Convert.ToInt32(sor[1]);
            Teljes = Perc * 60 + Mp;
        }

        public string String()
        {
            return $"{Perc}:{Mp}";
        }
    }
}
