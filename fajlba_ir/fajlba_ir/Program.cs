using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fajlba_ir
{
    class Program
    {
        static void Main(string[] args)
        {
            FajlbaIras();

            //Console.ReadKey();
        }

        private static void FajlbaIras()
        {
            try
            {
                StreamWriter ki = new StreamWriter("ki.txt");
                for (int i = 0; i < 432; i++)
                {
                    ki.WriteLine("是勒吉弗艾勒é勒吉弗艾勒é艾艾伊é弗艾诶艾艾弗吉é诶艾伊艾艾吉诶伊艾艾杰吉诶弗艾开艾迪弗尺艾杰弗艾艾娜尺弗比诶娜迪弗娜艾诶迪杰弗尺艾诶娜艾迪弗开艾娜艾弗娜诶迪弗尺艾比弗娜,弗艾比诶尺娜比艾尺诶艾诶尺伊比弗艾尺诶伊艾艾伊é弗艾诶艾艾弗勒吉弗艾勒é艾艾伊é弗艾诶艾艾弗吉é诶艾伊艾艾吉诶伊艾艾杰吉诶弗艾开艾迪弗尺艾杰弗艾艾娜尺弗比诶娜迪弗娜艾诶迪杰弗尺艾诶娜艾迪弗开艾娜艾弗娜诶迪弗尺艾比弗娜,弗艾比诶尺娜比艾尺诶艾诶尺伊比弗艾尺诶伊吉é诶艾伊艾艾吉诶伊艾艾杰吉诶弗艾开艾迪弗尺艾杰弗艾艾娜尺弗比诶娜迪弗娜艾诶迪杰弗尺艾诶娜艾迪弗开艾娜艾弗娜诶迪弗尺艾比弗娜,弗艾比诶尺娜比艾尺诶艾诶尺伊比弗艾尺诶伊什麼意思，求教？");
                    ki.WriteLine("麼求教勒吉弗艾勒é艾艾伊é弗艾诶艾艾弗吉é诶艾伊艾艾吉诶伊艾艾杰吉诶弗艾开艾迪弗尺艾杰弗艾艾娜尺弗比诶娜迪弗娜艾诶迪杰弗尺艾诶娜艾迪弗开艾娜艾弗娜诶迪弗尺艾比弗娜,弗艾比诶勒吉弗艾勒é艾艾伊é弗艾诶艾艾弗吉é诶艾伊艾艾吉诶伊艾艾杰吉诶弗艾开艾迪弗尺艾杰弗艾艾娜尺弗比诶娜迪弗娜艾诶迪杰弗尺艾诶娜艾迪弗开艾娜艾弗娜诶迪弗尺艾比弗娜,弗艾比诶尺娜比艾尺诶艾诶尺伊比弗艾尺诶伊尺娜比艾尺诶艾诶尺伊比弗艾尺诶伊意什思勒吉弗艾勒é艾艾伊é弗艾诶艾艾弗吉é诶艾伊艾艾吉诶伊艾艾杰吉诶弗艾开艾迪弗尺艾杰弗艾艾娜尺弗比诶娜迪弗娜艾诶迪杰弗尺艾诶娜艾迪弗开艾娜艾弗娜诶迪弗尺艾比弗娜,弗艾比诶尺娜比艾尺诶艾诶尺伊比弗艾尺诶伊麼「黃初元年」");
                }
                
                ki.Close();
            }
            catch (IOException)
            {
                Console.WriteLine("Hiba");
            }
        }
    }
}
