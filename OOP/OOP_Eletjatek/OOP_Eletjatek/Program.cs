using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Eletjatek
{
    class Program
    {
        static void Main(string[] args)
        {
            EletjatekSzimulator teszt = new EletjatekSzimulator(25, 50);
            Console.CursorVisible = false;
            teszt.Run();

            Console.ReadKey();
        }
    }
}
