using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fajlbe2
{
    class Program
    {
        static void Main(string[] args)
        {
            BeOlvas();
            
            Console.ReadKey();
        }

        private static void BeOlvas()
        {
            try
            {
                StreamReader olvas = new StreamReader("C:\\Users\\vighakos\\Desktop\\a.txt");
                
            }
            catch (IOException)
            {
                Console.WriteLine("Hiba");
            }
        }
    }
}
