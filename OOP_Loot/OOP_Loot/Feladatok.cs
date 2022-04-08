using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Loot
{
    class Feladatok
    {
        static List<Loot> lootok = Fajl.Beolvas("loot.csv");
        public static void _1()
        {
            Console.WriteLine($"1. feladat:\n\t{lootok.Count} sor beolvasva");
        }

        public static void _2()
        {

            int db = 0;
            for (int i = 0; i < lootok.Count; i++)
            {
                if (lootok[i].ItemQuality == "legendary")
                {
                    db++;
                }
            }

            Console.WriteLine($"2. feladat:\n\tA lista {db} legendary itemet tartalmaz");
        }

        public static void _3()
        {
            Console.WriteLine("3.feladat:");

            List<Zona> zonak = Harmadikfeladat_zonak_feltolt();

            Harmadikfeladat_kiiras(zonak);
        }

        public static void _4()
        {
            Console.WriteLine(negyedikfeladatkiiras());
            Console.WriteLine(negyedikfeladathoz_szukseges_valtozok());
        }

        public static void _5()
        {
            Console.WriteLine("5. feladat:");
            Dictionary<string, int> instancek = new Dictionary<string, int>();
            for (int i = 0; i < lootok.Count; i++)
            {
                if (instancek.ContainsKey(lootok[i].InstanceName))
                    instancek[lootok[i].InstanceName]++;
                else
                    instancek.Add(lootok[i].InstanceName, 1);
            }

            instancek = instancek.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

            foreach (KeyValuePair<string, int> item in instancek)
            {
                Console.WriteLine($"\t{item.Key} - {item.Value}");
            }
        }

        public static void _6()
        {
            System.Diagnostics.Process.Start(lootok.Find(x => x.ItemName.Equals("Warglaive of Azzinoth (mainhand)")).Url);
        }

        private static string negyedikfeladathoz_szukseges_valtozok()
        {
            int osszes = negyedikfeladt_elkezdese_eloszor_osszeszamolom_oket();
            int epicek_szama = negyedikfeladat_folytatasa_most_az_epicek_szamat_szerzem_meg();
            double szazalek = nyegyedikfeladat_befejezesenel_tartunk_most_a_szazalekot_fogom_kiszamolni(osszes, epicek_szama);
            return $"\tAz epicek százaléka: {szazalek}";
        }

        private static double nyegyedikfeladat_befejezesenel_tartunk_most_a_szazalekot_fogom_kiszamolni(double osszes, double epicek_szama)
        {
            return epicek_szama * 100 / osszes;
        }

        private static int negyedikfeladat_folytatasa_most_az_epicek_szamat_szerzem_meg()
        {
            int db = 0;
            for (int i = 0; i < lootok.Count; i++)
            {
                if (lootok[i].ItemQuality == "epic")
                {
                    db++;
                }
            }
            return db;
        }

        private static int negyedikfeladt_elkezdese_eloszor_osszeszamolom_oket()
        {
            return lootok.Count;
        }

        private static string negyedikfeladatkiiras()
        {
            return "4. feladat:";
        }

        private static void Harmadikfeladat_kiiras(List<Zona> zonak)
        {
            for (int i = 0; i < zonak.Count; i++)
            {
                if (zonak[i].InstanceNevek.Count >= 2)
                {
                    zonak[i].Kiir();
                }
            }
        }

        private static List<Zona> Harmadikfeladat_zonak_feltolt()
        {
            List<string> zona_nevek = HarmadikFeladat_zona_nevek_feltolt();
            List<Zona> eredmeny = Harmadikfeladat_eredmeny_feltolt(zona_nevek);
            return eredmeny;
        }

        private static List<Zona> Harmadikfeladat_eredmeny_feltolt(List<string> zona_nevek)
        {
            List<Zona> eredmeny = new List<Zona>();
            for (int i = 0; i < zona_nevek.Count; i++)
            {
                eredmeny.Add(new Zona(zona_nevek[i], Zona_nevekhez_tartozo_instance_lista(zona_nevek[i])));
            }
            return eredmeny;
        }

        private static List<string> Zona_nevekhez_tartozo_instance_lista(string nev)
        {
            List<string> nevek = new List<string>();

            for (int i = 0; i < lootok.Count; i++)
            {
                if (lootok[i].ZoneName == nev && !nevek.Contains(lootok[i].ZoneName))
                {
                    nevek.Add(lootok[i].ZoneName);
                }
            }

            return nevek;
        }

        private static List<string> HarmadikFeladat_zona_nevek_feltolt()
        {
            List<string> nevek = new List<string>();
            for (int i = 0; i < lootok.Count; i++)
            {
                if (!nevek.Contains(lootok[i].InstanceName))
                {
                    nevek.Add(lootok[i].InstanceName);
                }
            }

            return nevek;
        }
    }
}
