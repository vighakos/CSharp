using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Berek
{
    class Feladat
    {
        public static List<Ber> adatok = Fajl.Beolvas("berek.txt");
        public Feladat()
        {
            _1();
            _2();
            _3();
            _4();
            _5();
            _6();
            _7();
            _8();
            _9();
        }

        private void _9()
        {
            Console.WriteLine("\n9.feladat:");
            Console.WriteLine($"\n\tRossz fizetés: {adatok.Count(x => x.Fizetes < 150000)} db");
            Console.WriteLine($"\tKözepes fizetés: {adatok.Count(x => x.Fizetes > 150000 && x.Fizetes < 250000)} db");
            Console.WriteLine($"\tJó fizetés: {adatok.Count(x => x.Fizetes > 250000 && x.Fizetes < 400000)} db");
            Console.WriteLine($"\tKimagasló fizetés: {adatok.Count(x => x.Fizetes > 400000)} db");
        }

        private void _8()
        {
            List<Reszleg> reszlegek = new List<Reszleg>();

            foreach (Ber item in adatok)
                reszlegek = Ellenoriz(reszlegek, item);

            foreach (Reszleg item in reszlegek)
                item.AtlagFiz = item.FizSum / item.Fo;

            Console.WriteLine("\n8. feladat: Átlagos fizetés részlegenként:\n");

            reszlegek = reszlegek.OrderByDescending(x => x.AtlagFiz).ToList();

            foreach (Reszleg item in reszlegek)
                item.Kiir();
        }

        private List<Reszleg> Ellenoriz(List<Reszleg> reszlegek, Ber item)
        {
            bool talalt = false;
            for (int i = 0; i < reszlegek.Count; i++)
            {
                if (reszlegek[i].Nev == item.Reszleg)
                {
                    reszlegek[i].Fo++;
                    reszlegek[i].FizSum += item.Fizetes;
                    talalt = true;
                    break;
                }
            }

            if (!talalt) reszlegek.Add(new Reszleg(item.Reszleg));

            return reszlegek;
        }

        private void _7()
        {
            Dictionary<string, int> reszlegek = new Dictionary<string, int>();

            foreach (Ber item in adatok)
            {
                if (!reszlegek.ContainsKey(item.Reszleg) && item.Nem == "nő")
                    reszlegek.Add(item.Reszleg, 1);
                else if (item.Nem == "nő")
                    reszlegek[item.Reszleg]++;
            }
            
            Console.WriteLine("\n7. feladat:");

            foreach (KeyValuePair<string, int> item in reszlegek)
            {
                if (item.Value == reszlegek.Max(x => x.Value))
                {
                    Console.WriteLine($"\tA(z) {item.Key} részlegen dolgozik a legtöbb nő, {item.Value} fő");
                    break;
                }
            }
        }

        private void _6()
        {
            Console.Write("\n6. feladat: Adj meg egy évszámot: ");
            int ev = Convert.ToInt32(Console.ReadLine());

            List<Ber> egyezoek = adatok.FindAll(x => x.Belepes == ev).ToList();

            if (egyezoek.Count != 0)
                foreach (Ber item in egyezoek) item.Kiir();
        }

        private void _5()
        {
            Console.Write("\n5. feladat: Add meg egy részleg nevét: ");
            string reszleg = Console.ReadLine().ToLower();

            List<Ber> egyezoek = adatok.FindAll(x => x.Reszleg.ToLower().Contains(reszleg)).ToList();

            if (egyezoek.Count != 0)
                foreach (Ber item in egyezoek) item.Kiir();
        }

        private void _4()
        {
            double ferfiak = adatok.Count(x => x.Nem == "férfi");
            Console.WriteLine($"\n4. feladat:\n\tA dolgozók {ferfiak * 100 / adatok.Count:0.00}%-a férfi, {(adatok.Count - ferfiak) * 100 / adatok.Count:0.00}%-a nő");
        }

        private void _3()
        {
            Console.WriteLine("\n3. feladat:");

            Console.WriteLine("\nLegrégebbi dolgozók:");
            foreach (Ber item in adatok.FindAll(x => x.Belepes == adatok.Min(y => y.Belepes)).ToList()) 
                item.Kiir();

            Console.WriteLine("\nLegújabb dolgozók:");
            foreach (Ber item in adatok.FindAll(x => x.Belepes == adatok.Max(y => y.Belepes)).ToList()) 
                item.Kiir();
        }

        private void _2()
        {
            Console.WriteLine($"\n2. feladat: \n\tAz átlag bér: {adatok.Average(x => x.Fizetes):000 000.00} Ft");
        }

        private void _1()
        {
            Console.WriteLine($"1. feladat: \n\tA fájl {adatok.Count} adatot tartalmaz");
        }
    }
}
