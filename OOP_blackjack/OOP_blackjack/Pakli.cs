using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_blackjack
{
    class Pakli
    {
        public List<Kartya> pakli { get; set; }
        private string[] szin = new string[] { "♥", "♦", "♣", "♠" };
        private string[] figura = new string[] {"2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };

        public Pakli() 
        {
            pakli = new List<Kartya>();

            for (int i = 0; i < szin.Length; i++)
            {
                for (int j = 0; j < figura.Length; j++)
                {
                    Kartya ujLap = new Kartya(szin[i], figura[j]);
                    pakli.Add(ujLap);
                }
            }
        }
    }
}
