using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Pontok
{
    class Feladat
    {
        static List<Pont> pontok = Fajl.Beolvas("pontok.txt");
        public Feladat()
        {
            Console.WriteLine("1. feladat: Pontok száma a pontok.txt állományban: " + pontok.Count + " db");
            Console.WriteLine("2. feladat: " + _2() + " pont található az x vagy y tengelyen");
            Console.WriteLine("3. feladat: Azonos koordinátájú pontok:");
        }
        private static int _2()
        {
            return pontok.Where(x => x.X == 0 || x.Y == 0).ToList().Count;
        }

        private static void _3()
        {
            for (int i = 0; i < pontok.Count; i++)
            {
                string talalat = pontok[i].Sorszam.ToString() + ". ";
                for (int j = i+1; j < pontok.Count; j++)
                {
                    if (pontok[i].X == pontok[j].X &&
                        pontok[i].Y == pontok[j].Y)
                    {
                        talalat += pontok[j].Sorszam.ToString() + ". ";
                    }
                }

                if (talalat.Split('.').Length > 2)
                {
                    Console.WriteLine($"\tAz x = {pontok[i].X, 3} y = {pontok[i].Y, 3} koordinátán: {talalat}");
                }
            }
        }
    }
}
