using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Raketak
{
    class Feladat
    {
        public static List<Raketa> raketak = Muvelet.toRaketa(Muvelet.ReadFile("raketak.txt"));
        public static List<Hivatal> hivatalok = Muvelet.toHivatal(Muvelet.ReadFile("hivatalok.txt"));

        public Feladat()
        {
            /*
            _1();
            _2();
            _3();
            _4();
            _5();
            _6();
            _7();
            _8();*/
            _9();
            _10();
        }

        private void _10()
        {
            //melyik ügynökségnek volt a legtöbb idő eltelt első és utolsó között

            DateTime leghosszabb = Convert.ToDateTime(raketak[0].Utolso - raketak[1].Elso);
            Raketa leghosszabbraketa = raketak[0];
            foreach (Raketa item in raketak)
            {
                if (Convert.ToDateTime(item.Utolso - item.Elso) > leghosszabb)
                {
                    leghosszabb = Convert.ToDateTime(item.Utolso - item.Elso);
                    leghosszabbraketa = item;
                }
            }
            Hivatal ugynokseg = hivatalok.Find(x => x.Orszag == leghosszabbraketa.Orszag);
            Console.WriteLine($"\n10. feladat:\n\t{ugynokseg.Rovidites} - {leghosszabb}");
        }

        private void _9()
        {
            //mikor bocsájtották fel az első űrhajós rakétát?
            List<Hivatal> urhajosok_hivatal = hivatalok.FindAll(x => x.Urhajosok == true).ToList();
            List<Raketa> urhajosok_raketa = new List<Raketa>();

            foreach (Hivatal hivatal in urhajosok_hivatal)
            {
                urhajosok_raketa = Keres_Urhajos(hivatal, urhajosok_raketa);
            }

            Console.WriteLine($"\n9. feladat:\n\tAz első űrhajós rakétát ekkor bocsájtották fel: {urhajosok_raketa.Find(x => x.Elso == urhajosok_raketa.Min(y => y.Elso)).Elso.ToShortDateString()}");
        }

        private List<Raketa> Keres_Urhajos(Hivatal hivatal, List<Raketa> urhajosok_raketa)
        {
            foreach (Raketa item in raketak)
            {
                if (item.Orszag == hivatal.Orszag)
                {
                    urhajosok_raketa.Add(item);
                }
            }
            return urhajosok_raketa;
        }

        private void _8()
        {
            //dátum bekér, adott napon mely műholdaknak volt szolgálata,
            //milyen tevékenységet végeztek

            Console.Write("\n8. feladat: Adjon meg egy dátumot: ");
            DateTime beker = Convert.ToDateTime(Console.ReadLine());

            List<Raketa> megfelelo = raketak.FindAll(x => x.Elso < beker && x.Utolso > beker).ToList();

            foreach (Raketa item in megfelelo)
            {
                Keres(megfelelo, item);
            }
        }

        private void Keres(List<Raketa> megfelelo, Raketa item)
        {
            foreach (Hivatal hivatal in hivatalok)
            {
                if (item.Orszag == hivatal.Orszag)
                {
                    Console.WriteLine($"\t{item.Nev}, {item.Orszag} - " + "{0}{1}{2}{3}", 
                        (hivatal.Urhajosok ? "Űrhajósok " : ""),
                        (hivatal.Muhold ? "Műholdak " : ""),
                        (hivatal.Urszonda ? "Űrszonda " : ""),
                        (hivatal.Biologiai ? "Biológiai" : ""));
                }
            }
        }

        private void _7()
        {
            DateTime holdraszallas = Convert.ToDateTime("1969.07.20");
            List<Raketa> holdra = raketak.FindAll(x => x.Elso < holdraszallas && x.Utolso > holdraszallas).ToList();

            Console.WriteLine("\n7. feladat:");

            foreach (Raketa item in holdra) 
                Console.WriteLine($"\t{item.Nev}");
        }

        private void _6()
        {
            Raketa legkisebb = raketak.Find(x => x.Terfogat == raketak.Min(y => y.Terfogat));
            Raketa legnagyobb = raketak.Find(x => x.Terfogat == raketak.Max(y => y.Terfogat));
            Console.WriteLine($"\n6. feladat:" +
                $"\n\tLegkisebb térfogat: {legkisebb.Nev} - {legkisebb.Terfogat:0.00}" +
                $"\n\tLegnagyobb térfogat: {legnagyobb.Nev} - {legnagyobb.Terfogat:0.00}" +
                $"\n\tA legkisebb térfogata {legkisebb.Terfogat * 100 / legnagyobb.Terfogat:0.00}%-a a legnagyobbnak");
        }

        private void _5()
        {
            Dictionary<string, int> orszagok = new Dictionary<string, int>();
            foreach (Raketa item in raketak)
                orszagok = Ellenoriz(orszagok, item);

            orszagok = orszagok.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            Console.WriteLine($"\n5. feladat:");
            foreach (KeyValuePair<string, int> item in orszagok)
            {
                if (item.Value != 0)
                    Console.WriteLine($"\t{item.Key} - {item.Value}");
            }
        }

        private Dictionary<string, int> Ellenoriz(Dictionary<string, int> orszagok, Raketa item)
        {
            if (!orszagok.ContainsKey(item.Orszag))
                orszagok.Add(item.Orszag, 1);
            else
                orszagok[item.Orszag]++;

            return orszagok;
        }

        private void _4()
        {
            Console.WriteLine($"\n4.feladat:" +
                $"\n\t{raketak.Find(x => x.HasznosArany == raketak.Max(y => y.HasznosArany)).Nev} rakéta aránya a legjobb");
        }

        private void _3()
        {
            Console.WriteLine("\n3.feladat:");
            foreach (Hivatal item in hivatalok)
            {
                if (item.Urhajosok == true && item.Muhold == true && item.Urszonda == true && item.Biologiai == true)
                {
                    Console.WriteLine($"\t{item.Nev} - {item.Rovidites}");
                }
            }
        }

        private void _2()
        {
            double ossz = hivatalok.Count(x => x.Nev.ToLower().Contains("űrügynökség"));
            Console.WriteLine($"\n2. feladat:\n\tÖsszesen {ossz} hivatal nevében szerepel a szó, {ossz * 100 / hivatalok.Count:0.00}%");

        }

        private void _1()
        {
            double ossz = raketak.Count + hivatalok.Count;
            Console.WriteLine($"1. feladat:\n\tÖsszesen {ossz} adat van" +
                $"\n\tRakéták: {(raketak.Count / ossz) * 100:0.00}%" +
                $"\n\tHivatalok: {(hivatalok.Count / ossz) * 100:0.00}%");
        }
    }
}
