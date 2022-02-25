using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_sim
{
    class Program
    {
        static List<Sim> simek = new List<Sim>();
        static void Main(string[] args)
        {
            Menu();
        }

        private static void Menu()
        {
            Console.WriteLine("Mit szeretnél csinálni?\n\t1 - SIM létrehozása\n\t2 - Aktivitás lekérése\n\t3 - PIN módosítás\n\tENTER - Kilépés");

            int valasz = Convert.ToInt32(Console.ReadLine());

            if (valasz == 1)
            {
                LetrehozSIM();
            }
            else if (valasz == 2)
            {
                Aktive();
            }
            else if (valasz == 3)
            {
                PinModosit();
            }
            else
            {
                return;
            }
        }

        private static void PinModosit()
        {
            string pin = "";
            Console.Write("Add meg a telefonszámot: ");
            string telszam = Console.ReadLine();

            if (simek.Count > 0)
            {
                if (telszam.Length != 7)
                {
                    Console.WriteLine("7 számot kell megadni");
                    PinModosit();
                }
                else
                {
                    for (int i = 0; i < simek.Count; i++)
                    {
                        if (simek[i].Telszam.Equals(telszam))
                        {
                            Console.Write("Add meg a PIN kódot: ");
                            pin = Console.ReadLine();

                        }
                    }
                }
                
            }

            Console.WriteLine();
            Menu();
        }

        private static void Aktive()
        {
            Console.Write("Adj meg egy telefonszámot: 0600");
            string telszam = Console.ReadLine();
            bool letezik = false;

            if (simek.Count > 0)
            {
                for (int i = 0; i < simek.Count; i++)
                {
                    if (simek[i].Telszam.Equals(telszam))
                    {
                        Console.WriteLine("A telefonszám létezik, " + (simek[i].Aktiv ? "aktív" : "nem aktív"));
                        letezik = true;
                        break;
                    }
                }

                if (!letezik)
                {
                    Console.WriteLine("A telefonszám nem létezik");
                }
            }
            Console.WriteLine();
            Menu();

        }

        private static void LetrehozSIM()
        {
            Console.Write("Add meg a telefonszámot (7 szám): 0600");
            string telszam = Console.ReadLine();

            if (simek.Count > 0)
            {
                for (int i = 0; i < simek.Count; i++)
                {
                    if (simek[i].Telszam.Equals(telszam) || telszam.Length != 7)
                    {
                        Console.WriteLine("Ez a telefonszám már létezik, vagy nem 7 számot adtál meg");
                        LetrehozSIM();
                    }
                }
            }

            Random r = new Random();
            string pin = "";
            for (int i = 0; i < 4; i++)
            {
                pin += r.Next(0, 10);
            }
            Console.WriteLine($"PIN kód: {pin}");

            string puk = "";
            for (int i = 0; i < 8; i++)
            {
                puk += r.Next(0, 10);
            }
            Console.WriteLine($"PUK kód: {puk}");

            simek.Add(new Sim(telszam, pin, puk));

            Console.WriteLine();
            Menu();
        }
    }
}
