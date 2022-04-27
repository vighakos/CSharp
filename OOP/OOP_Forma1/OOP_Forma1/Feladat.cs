using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Forma1
{
    class Feladat
    {
        public static List<Eredmeny> eredmenyek = FileAction.toEredmeny(FileAction.ReadFile("Eredmenyek.txt"));
        public static List<Nagydij> nagydijak = FileAction.toNagydij(FileAction.ReadFile("Nagydijak.txt"));
        public static List<Versenyzo> versenyzok = FileAction.toVersenyzo(FileAction.ReadFile("Versenyzok.txt"));
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
        }

        private void _8()
        {
            Versenyzo nyertes = versenyzok[0];
            foreach (Eredmeny item in eredmenyek)
            {
                if (item.NagydijID == 11 && item.Helyezes == 1)
                {
                    nyertes = versenyzok.Find(x => x.ID == item.PilotaID);
                    break;
                }
            }

            string nagydijnev = nagydijak.Find(x => x.ID == 11).Nev;
            Console.WriteLine($"\n8. feladat: \n\t" +
                $"A(z) {nagydijnev} nagydíjat {nyertes.Nev} nyerte");
        }

        private void _7()
        {
            Console.WriteLine($"\n7. feladat: Átlagosan {nagydijak.Average(x => x.KorokSzama):0.00} kör volt egy versenyen");
        }

        private void _6()
        {
            List<Nagydij> europaiak = nagydijak.FindAll(x => x.Kontinens == "EU").ToList();
            int legkevesebb = europaiak.Min(x => x.KorokSzama);
            Console.WriteLine($"\n6. feladat:\n\t{europaiak.Find(x => x.KorokSzama == legkevesebb).Nev} európai pályán volt a legkevesebb kör");
        }

        private void _5()
        {
            List<Nagydij> azsiaiak = nagydijak.FindAll(x => x.Kontinens == "A").ToList();
            int legtobb = azsiaiak.Max(x => x.KorokSzama);
            Console.WriteLine($"\n5. feladat:\n\t{azsiaiak.Find(x => x.KorokSzama == legtobb).Nev} ázsiai pályán volt a legtöbb kör");
        }

        private void _4()
        {
            Console.Write("\n4. feladat: Adj meg egy dátumot: ");
            DateTime beker = Convert.ToDateTime(Console.ReadLine());
            foreach (Versenyzo item in versenyzok)
            {
                if (item.Szul > beker)
                {
                    item.Kiir();
                }
            }
        }

        private void _3()
        {
            Console.WriteLine("\n3. feladat:");
            Versenyzo versenyzo = versenyzok.Find(x => x.Csapatnev == "ToroRosso");
            Console.WriteLine($"\t{versenyzo.Nev}, {versenyzo.Csapatnev}");

        }

        private void _2()
        {
            Console.WriteLine("\n2.feladat: ");
            foreach (Versenyzo item in versenyzok)
            {
                if (item.Csapatnev.ToLower().Contains("redbull"))
                {
                    item.Kiir();
                }
            }
        }

        private void _1()
        {
            Console.WriteLine($"1. feladat: \n\tEredmények: {eredmenyek.Count}" +
                $"\n\tNagydíjak: {nagydijak.Count}" +
                $"\n\tVersenyzők: {versenyzok.Count}");
        }
    }
}
