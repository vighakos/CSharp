using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oopSIMkartya
{
    class Program
    {
        static List<Sim> telefonszamok = new List<Sim>();

        static void Main(string[] args)
        {
            /*
             * SIM kártya:
             * - 1 tel szám: 06 00 7db számjegy, a felhasználó választja meg a még nem létező tel.számokból
             * - 1 PIN kód: 4 számjegy, mi generáljuk, első jegy lehet 0 is!!
             * - 1 PUK kód: 8 számjegy, mi generáljuk, első jegy lehet 0 is!!
             * 
             * Menü rendszer:
             * 1. SIM létrehozása
             * 2. Aktivitás lekérdezése: csak tel.számot kérünk és megmondjuk, hogy aktív-e a SIM kártya
             * 3. PIN módosítás: tel.szám + PIN kód kérése
             *      ha minden rendben: elkérjük a régi PIN kódót, majd az újat kétszer
             *      ha a tel.szám nem létezik: írjuk ki, hogy nincs ilyen szám
             *      ha a tel.szám létezik, de a hozzá tartozó PIN nem jó, akkor 4szer lehet próbálkozni
             *          ha nem sikerül 4. próbára sem, akkor a SIM kártyát deaktiváljuk és kérjük a PUK kódot
             *          ha a PUK nincs rendben: végtelen sokszor próbálkozhatunk, de ezentúl ehhez a tel.számhoz mindig a PUK kódot kérjük
             *          ha a PUK rendben: elkérjük az új PIN kódot 2szer és kérdezzük meg, hogy aktiváljuk-e vissza a SIM kártyát
             * 
             * Bármelyik menüpontban tegyük elérhetővé, hogy a 0 megadásával visszalépjünk a főmenübe
             * Ha sikeresen végrehajtottunk egy műveletet, újra a főmenübe lépjünk vissza
             */
            while (true)
            {
                Menu();
            }



            Console.ReadKey();
        }

        private static void Menu()
        {

            Console.WriteLine("\n\nKérem válasszon az alábbiak közül (1, 2, 3):");
            Console.WriteLine("Mindenkori menübe való visszalépés a 0-val (nulla)");
            Console.WriteLine("1. SIM létrehozása");
            Console.WriteLine("2. Aktivitás lekérdezése");
            Console.WriteLine("3. PIN-kód módosítása");
            Console.Write("Választott menüpont: ");
            string valasztas = Console.ReadLine();

            if(valasztas == "1")
            {
                SimLetrehozas();
            }
            else if(valasztas == "2")
            {
                AktivitasLekeres();
            }
            else if(valasztas == "3")
            {
                PinModositas();
            }
        }

        private static void PinModositas()
        {
            Console.Clear();
            Console.Write("Kérem adja meg a telefonszámot: ");
            string telszam = Console.ReadLine();
            if(telszam == "0")
            {
                Console.Clear();
            }
            else if (!LetezoSzam(telszam))
            {
                Console.WriteLine("Ez a telefonszám nem létezik, vagy nem megfelelő!");
            }
            else if(telefonszamok.Find(x => x.TelSzam==telszam).Aktiv)
            {
                int probalkozas = 0;
                for (int i = 0; i < 4; i++)
                {
                    if (PinBekeres(telszam))
                    {
                        break;
                    }
                    else
                    {
                        probalkozas++;
                    }
                }
                if(probalkozas < 4)
                {
                    PinUjPin(telszam);
                }
                else
                {
                    telefonszamok.Find(x => x.TelSzam == telszam).Aktiv = false;
                    PukBekeres(telszam);
                }
                
            }
            else
            {
                PukBekeres(telszam);
            }
        }

        private static void PukBekeres(string telszam)
        {
            string puk = "";
            bool joPuk;
            do
            {
                Console.Write("Kérem a PUK-kódot: ");
                puk = Console.ReadLine();
                joPuk = puk == telefonszamok.Find(x => x.TelSzam == telszam).Puk ? true : false;


            } while (!joPuk && puk!="0");

            if (joPuk)
            {
                UjraAktivalas(telszam);
            }
        }

        private static void UjraAktivalas(string telszam)
        {
            Console.Write("Szeretné aktiválni a SIM kártyát? (I/N) ");
            string valasz = Console.ReadLine().ToUpper();
            if(valasz == "I")
            {
                telefonszamok.Find(x => x.TelSzam == telszam).Aktiv = true;
            }

            UjPinKeres(telszam);
        }

        private static void PinUjPin(string telszam)
        {
            Console.Write("Kérem a régi PIN-kódot: ");
            string regiPin = Console.ReadLine();
            if(regiPin != "0")
            {
                UjPinKeres(telszam);
                
            }
        }

        private static void UjPinKeres(string telszam)
        {
            Console.Write("Kérem az új PIN-kódot: ");
            string ujPin1 = Console.ReadLine();
            if (ujPin1 != "0")
            {
                Console.Write("Kérem az új PIN-kódot újra: ");
                string ujPin2 = Console.ReadLine();
                if (ujPin2 != "0")
                {
                    if(ujPin1 == ujPin2 && ujPin1.Length == 4)
                    {
                        telefonszamok.Find(x => x.TelSzam == telszam).Pin = ujPin1;
                    }
                    else
                    {
                        Console.WriteLine("Az új PIN-kódok nem egyeznek vagy hibásak!");
                        UjPinKeres(telszam);
                    }
                }
            }
        }

        private static bool PinBekeres(string telszam)
        {
            Console.Write("Kérem a PIN-kódot: ");
            string pin = Console.ReadLine();
            string joPin = telefonszamok.Find(x => x.TelSzam == telszam).Pin;
            if(pin == "0")
            {
                Console.Clear();
                Menu();
            }
            else if(joPin == pin)
            {
                return true;
            }
            return false;
        }

        private static void AktivitasLekeres()
        {
            Console.Clear();
            Console.Write("Kérem adja meg a telefonszámát: ");
            string telszam = Console.ReadLine();

            if(telszam == "0")
            {
                Console.Clear();
                
            }
            else if(!LetezoSzam(telszam) || telszam.Length != 11)
            {
                Console.WriteLine("Ez a telefonszám nem létezik, vagy nem megfelelő!");
            }
            else
            {
                bool aktiv = telefonszamok.Find(x => x.TelSzam == telszam).Aktiv;
                Console.WriteLine("A megadott számhoz tartozó SIM kártya " + (aktiv ? "aktív" : "inaktív"));
            }
        }

        private static void SimLetrehozas()
        {
            Console.Clear();
            Console.Write("Kérem a telefonszám utolsó 7 számjegyét: 06 00 ");
            string telszam = "0600" + Console.ReadLine();
            if (LetezoSzam(telszam) || telszam.Length != 11)
            {
                Console.WriteLine("Ez a telefonszám már létezik, vagy nem megfelelő!");
            }
            else
            {
                telefonszamok.Add(new Sim(telszam));
                Console.WriteLine("SIM kártya sikeresen létrehozva.");
                telefonszamok[telefonszamok.Count - 1].Kiir();
            }
        }

        private static bool LetezoSzam(string telszam)
        {
            for (int i = 0; i < telefonszamok.Count; i++)
            {
                if(telefonszamok[i].TelSzam == telszam)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
