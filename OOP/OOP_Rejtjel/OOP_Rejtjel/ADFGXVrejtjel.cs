using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Rejtjel
{
    class ADFGXVrejtjel
    {
        private char[,] Kodtabla;
        private string Uzenet;
        private string Kulcs;


        public string Betupar(char k)
        {
            string[] adfgvx = new string[] { "A", "D", "F", "G", "V", "X"};

            for (int sor = 0; sor < 6; sor++)
            {
                for (int oszlop = 0; oszlop < 6; oszlop++)
                {
                    if (Kodtabla[sor, oszlop] == k)
                    {
                        return adfgvx[sor] + adfgvx[oszlop];
                    }
                }
            }
            return "Hiba";
        }
        public string AtalakitottUzenet()
        {
            // 5. feladat:
            string atalakitott = String.Concat(Uzenet.Where(c => !Char.IsWhiteSpace(c)));
            int ertek = atalakitott.Length;
            while (ertek % Kulcs.Length != 0)
            {
                atalakitott += "x";
                ertek = atalakitott.Length;
            }
            return atalakitott;
        }

        public string Kodszoveg()
        {
            // 7. feladat:
            string atalakitott = AtalakitottUzenet();
            string kodszoveg = "";

            foreach (char betu in atalakitott)
            {
                kodszoveg += Betupar(betu);
            }
            return kodszoveg;
        }

        public string KodoltUzenet()
        {
            string kodszoveg = Kodszoveg();
            int sorokSzama = kodszoveg.Length / Kulcs.Length;
            int oszlopokSzama = Kulcs.Length;
            char[,] m = new char[sorokSzama, oszlopokSzama];
            int index = 0;
            for (int sor = 0; sor < sorokSzama; sor++)
            {
                for (int oszlop = 0; oszlop < oszlopokSzama; oszlop++)
                {
                    m[sor, oszlop] = kodszoveg[index++];
                }
            }

            string kodoltUzenet = "";
            for (char ch = 'A'; ch <= 'Z'; ch++)
            {
                int oszlopIndex = Kulcs.IndexOf(ch);
                if (oszlopIndex != -1)
                {
                    for (int sorIndex = 0; sorIndex < sorokSzama; sorIndex++)
                    {
                        kodoltUzenet += m[sorIndex, oszlopIndex];
                    }
                }
            }
            return kodoltUzenet;
        }

        public ADFGXVrejtjel(string kodtablaFile, string uzenet, string kulcs)
        {
            Uzenet = uzenet;
            Kulcs = kulcs;

            Kodtabla = new char[6, 6];
            int sorIndex = 0;
            foreach (var sor in System.IO.File.ReadAllLines(kodtablaFile))
            {
                for (int oszlopIndex = 0; oszlopIndex < sor.Length; oszlopIndex++)
                {
                    Kodtabla[sorIndex, oszlopIndex] = sor[oszlopIndex];
                }
                sorIndex++;
            }
        }
    }
}
