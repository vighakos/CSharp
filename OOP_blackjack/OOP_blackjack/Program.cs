using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_blackjack
{
    class Program
    {
        static List<Jatekos> jatekosok = new List<Jatekos>();
        static Pakli pakli = new Pakli();
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.Write("Hány játékos van? ");
            int jatekosszam = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < jatekosszam; i++)
            {
                jatekosok.Add(new Jatekos((i + 1).ToString()));
                KezdoOsztas(i);
            }

            Eredmenyek();

            Console.ReadKey();
        }

        private static void Eredmenyek()
        {
            Console.Clear();

            for (int i = 0; i < jatekosok.Count; i++)
            {
                jatekosok[i].Helyezes = jatekosok[i].Pontok();
                if (jatekosok[i].Pontok() > 21) jatekosok[i].Helyezes = 0;
            }

            Rendezes();

            jatekosok[0].Helyezes = 1;

            for (int i = 1; i < jatekosok.Count; i++)
            {
                if (jatekosok[i].Pontok() == jatekosok[i - 1].Pontok())
                {
                    jatekosok[i].Helyezes = jatekosok[i - 1].Helyezes;
                }
                else
                {
                    jatekosok[i].Helyezes = jatekosok[i - 1].Helyezes + 1;
                }
            }

            Kiiras();
        }

        private static void Kiiras()
        {
            Console.Clear();

            Console.WriteLine("A játék eredménye:\n---------------------------");

            for (int i = 0; i < jatekosok.Count; i++)
            {
                if (jatekosok[i].Pontok() > 21)
                {
                    Console.WriteLine($"{jatekosok[i].Nev}. játékos helyezés nélküli pontjai: {jatekosok[i].Pontok()}");
                }
                else
                {
                    Console.WriteLine($"{jatekosok[i].Helyezes}. helyezett: {jatekosok[i].Nev}. játékos, pontjai: {jatekosok[i].Pontok()}");
                }
            }
        }

        private static void Rendezes()
        {
            for (int i = 0; i < jatekosok.Count; i++)
            {
                for (int j = i; j < jatekosok.Count; j++)
                {
                    if (jatekosok[i].Helyezes < jatekosok[j].Helyezes)
                    {
                        Jatekos seged = jatekosok[i];
                        jatekosok[i] = jatekosok[j];
                        jatekosok[j] = seged;
                    }
                }
            }
        }

        private static void KezdoOsztas(int ki)
        {
            Random r = new Random();
            Console.Clear();
            Console.WriteLine($"{ki + 1}. játékos lapjai: ");
            for (int i = 0; i < 2; i++)
            {
                Kartya lap = pakli.pakli[r.Next(pakli.pakli.Count)];
                jatekosok[ki].Lapok.Add(lap);
                lap.Kiir();
                pakli.pakli.Remove(lap);
            }

            UjabbLap(ki);
        }

        private static void UjabbLap(int ki)
        {
            Console.Write($"Pontok: {jatekosok[ki].Pontok()}. Kér még lapot? (I/N) ");
            string valasz = Console.ReadLine();

            if (valasz.ToLower() == "i" && jatekosok[ki].Pontok() <= 21)
            {
                UjLapOsztas(ki);
            }
        }

        private static void UjLapOsztas(int ki)
        {
            Kartya lap = pakli.pakli[new Random().Next(pakli.pakli.Count)];
            jatekosok[ki].Lapok.Add(lap);
            lap.Kiir();
            pakli.pakli.Remove(lap);

            UjabbLap(ki);
        }
    }
}
