using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Frame
{
    class Frame
    {
        public string Nev;
        public int Health, Shield, TimeToCraft;
        public double Armor, Energy;

        public Frame(string[] sor)
        {
            Nev = sor[0];
            Health = Convert.ToInt32(sor[1]);
            Shield = sor[2] == "-" ? 0 : Convert.ToInt32(sor[2]);
            Energy = sor[3] == "-" ? 0 : Convert.ToDouble(sor[3]);
            Armor = Convert.ToDouble(sor[4]);
            TimeToCraft = Convert.ToInt32(sor[5]);
        }

        public void Kiir()
        {
            Console.WriteLine($"\n\tNév: {Nev} " +
                $"\n\tHP: {Health} " +
                $"\n\tShield: {Shield} " +
                $"\n\tEnergy: {Energy} " +
                $"\n\tArmor: {Armor} " +
                $"\n\tTTC: {TimeToCraft} óra");
        }
    }
}
