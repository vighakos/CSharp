using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace oopSIMkartya
{
    class Sim
    {
        public string TelSzam { get; set; }
        public string Pin { get; set; }
        public string Puk { get; set; }
        public bool Aktiv { get; set; }

        public Sim(string telSzam)
        {
            TelSzam = telSzam;
            Pin = Kodgeneralas(4);
            Puk = Kodgeneralas(8);
            Aktiv = true;
        }

        public void Kiir()
        {
            Console.WriteLine($"\tTelefonszám: {TelSzam}");
            Console.WriteLine($"\tPIN-kód: {Pin}");
            Console.WriteLine($"\tPUK-kód: {Puk}");
            Console.WriteLine($"\tAktivitás: " + (Aktiv ? "aktív" : "inaktív"));
        }

        private string Kodgeneralas(int db)
        {
            Random r = new Random();
            string kod = "";
            

            for (int i = 0; i < db; i++)
            {
                Thread.Sleep(15);
                kod += r.Next(0, 10).ToString();
            }

            return kod;
        }
    }
}
