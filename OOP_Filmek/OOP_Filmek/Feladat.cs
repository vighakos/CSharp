using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Filmek
{
    class Feladat
    {
        public static List<Film> filmek = Fajl.Beolvas("filmek.csv");
        public Feladat()
        {
            _1();
            _2();
            _3();
            _4();
            _5();
            _6();
            _7(); //Mennyi volt a leghosszabb idő, amit várni kellett 2 film megjelenése között?
            _8(); //Hány filmet tudsz megnézni bekért idő alatt?
            _9(); //Ha 2 kategória, dupláz
        }

        private void _9()
        {
            List<Film> kategoriak = new List<Film>();

            for (int i = 0; i < filmek.Count; i++)
            {
                if (filmek[i].Mufaj.Contains('/'))
                {
                    kategoriak.Add(filmek[i]);
                    kategoriak[kategoriak.Count - 1].Mufaj = filmek[i].Mufaj.Split('/')[0];
                    kategoriak.Add(filmek[i]);
                    kategoriak[kategoriak.Count - 1].Mufaj = filmek[i].Mufaj.Split('/')[1];
                }
                else
                {
                    kategoriak.Add(filmek[i]);
                }
            }
        }

        private void _8()
        {
            Console.Write("\n8. feladat: Adj meg egy számot: ");
            int bekert = Convert.ToInt32(Console.ReadLine());
            int maradek = bekert;
            int db = 0;

            List<Film> rendezve = filmek.OrderBy(x => x.Hossz).ToList();

            for (int i = 0; i < rendezve.Count; i++)
            {
                if (maradek >= rendezve[i].Hossz)
                {
                    db++;
                    rendezve[i].Kiir();
                    maradek -= rendezve[i].Hossz;
                }
            }

            Console.WriteLine($"\n\t{db} filmet tudsz megnézni {bekert} perc alatt, {maradek} perc maradt");

        }

        private void _7()
        {
            int kulonbseg = 0;

            List<Film> rendezve = filmek.OrderBy(x => x.Ev).ToList();

            for (int i = 1; i < rendezve.Count; i++)
            {
                if (Math.Abs(rendezve[i-1].Ev - rendezve[i].Ev) > kulonbseg)
                    kulonbseg = Math.Abs(rendezve[i - 1].Ev - rendezve[i].Ev);
            }

            Console.WriteLine($"\n7. feladat: \n\t{kulonbseg} évet kellett várni");
        }

        private void _6()
        {
            Console.WriteLine("\n6. feladat:");

            Dictionary<string, int> evek = new Dictionary<string, int>();

            for (int i = 0; i < filmek.Count; i++)
            {
                if (evek.ContainsKey(filmek[i].Ev.ToString()))
                    evek[filmek[i].Ev.ToString()]++;
                else
                    evek.Add(filmek[i].Ev.ToString(), 1);
            }

            evek = evek.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

            foreach (KeyValuePair<string, int> item in evek)
            {
                Console.WriteLine($"\t{item.Key} - {item.Value}");
            }
        }

        private void _5()
        {
            Console.WriteLine($"\n5. feladat: \n\t{filmek.FindAll(x => x.Cim.Contains("Harry Potter")).Sum(x => x.Hossz) / 60} óra {filmek.FindAll(x => x.Cim.Contains("Harry Potter")).Sum(x => x.Hossz) % 60} percbe telik megnézni");
        }

        private void _4()
        {
            Console.Write("\n4. feladat: Adj meg egy évszámot: ");
            int evszam = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"\n\t{EvszamKeres(evszam)}"); 
        }

        private string EvszamKeres(int evszam)
        {
            int db = 0;

            for (int i = 0; i < filmek.Count; i++)
            {
                if (filmek[i].Ev == evszam)
                    db++;
            }

            return db != 0 ? $"{db} filmet adtak ki ebben az évben" : "Nem adtak ki filmet ebben az évben";
        }

        private void _3()
        {
            Console.Write("\n3. feladat: Adj meg egy műfajt: ");
            string mufaj = Console.ReadLine().ToLower();

            MufajKeres(mufaj);
        }

        private void MufajKeres(string mufaj)
        {
            bool talalt = false;
            for (int i = 0; i < filmek.Count; i++)
            {
                if (filmek[i].Mufaj.ToLower().Equals(mufaj))
                {
                    talalt = true;
                    filmek[i].Kiir();
                }
            }

            if (!talalt) Console.WriteLine("\n\tNincs ilyen műfaj");
        }

        private void _2()
        {
            Console.WriteLine("\n2. feladat:");
            for (int i = 0; i < filmek.Count; i++)
            {
                if (filmek[i].Rendezo == "Robert Zemeckis")
                    filmek[i].Kiir();
            }
        }

        private void _1()
        {
            Console.WriteLine($"1. feladat:\n\t{filmek.Count} adat szerepel a fájlban");
        }
    }
}
