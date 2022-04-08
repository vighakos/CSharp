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

            string valasz = Console.ReadLine();

            if (valasz == "1")
            {
                LetrehozSIM();
            }
            else if (valasz == "2")
            {
                Aktive();
            }
            else if (valasz == "3")
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
            Console.Write("Add meg a telefonszámot: 0600");
            string telszam = Console.ReadLine();
            bool megvan = false;
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
                            megvan = true;
                            UjPin(simek[i]);
                            break;
                        }
                    }
                    if (!megvan)
                    {
                        Console.WriteLine("Ez a telefonszám nem létezik\n");
                        PinModosit();
                    }
                }
            }
            Console.WriteLine();
            Menu();
        }

        private static void UjPin(Sim sim)
        {
            string ujpin = "";
            bool sikeres = false;
            for (int i = 0; i < 4; i++)
            {
                Console.Write("Add meg a PIN kódot: ");
                string pinbe = Console.ReadLine();

                if (PinVizsgal(sim, pinbe))
                {
                    sikeres = true;
                    UjPinModosit(sim);
                    break;
                }
            }

            if (sikeres)
            {
                Console.WriteLine($"{sim.Telszam} új PIN kódja: {sim.Pin}");
            }
            else
            {
                sim.Aktiv = false;
                PukKeres(sim);
            }
        }

        private static void UjPinModosit(Sim sim)
        {
            Console.Write("Add meg az új PIN kódot: ");
            string ujpin = Console.ReadLine();

            Console.Write("Add meg újra: ");
            string ellenorzo = Console.ReadLine();
            if (ellenorzo == ujpin)
            {
                sim.Pin = ujpin;
            }
            else
            {
                UjPinModosit(sim);
            }
        }

        private static bool PinVizsgal(Sim sim, string pinbe)
        {
            if (pinbe == sim.Pin)
            {
                return true;
            }
            return false;
        }

        private static void PukKeres(Sim sim)
        {
            Console.Write("Add meg a PUK kódot! (0-val főmenübe kilép) ");
            string pukbe = Console.ReadLine();
            if (pukbe == sim.Puk)
            {
                Console.Write("Add meg az új PIN kódot: ");
                string ujpin = Console.ReadLine();

                Console.Write("Add meg újra: ");
                string pinmegerosit = Console.ReadLine();

                if (pinmegerosit == ujpin)
                {
                    sim.Pin = ujpin;
                    Console.Write("Aktiváljam a telefonszámot? (i/n)");
                    string valasz = Console.ReadLine();
                    if (valasz == "i")
                    {
                        sim.Aktiv = true;
                        return;
                    }
                    else
                    {
                        return;
                    }
                }
            }
            else if (pukbe == "0")
            {
                Menu();
            }
            else
            {
                PukKeres(sim);
            }
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

            if (telszam.Length != 7)
            {
                Console.WriteLine("Nem 7 számot adtál meg!");
                LetrehozSIM();
            }

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
