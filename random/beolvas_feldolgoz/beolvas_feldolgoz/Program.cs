using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace beolvas_feldolgoz
{
    class Program
    {
        static List<string> nevek = new List<string>();
        static List<double> eredmenyek = new List<double>();
        static void Main(string[] args)
        {
            BeOlvas();

            //6ározzuk meg, hogy a versenyen hányan indultak
            ElsoFeladat();  
            
            //6ározzuk meg a legmagasabb %-ot elért versenyző nevét és eredményét
            MasodikFeladat();

            //top3 versenyző neve és eredménye
            HarmadikFeladat();

            //név bekér, megnéz létezik-e, milyen eredmény
            NegyedikFeladat();

            //eredemény bekér, megkeres legközelebbi, kiír versenyző
            OtodikFeladat();

            Console.ReadKey();
        }

        private static void OtodikFeladat()
        {
            Console.Write("5. feladat: Adj meg egy eredményt: ");
            double beker = Convert.ToDouble(Console.ReadLine());

            double kulonbseg = eredmenyek[0];
            int index = 0;

            for (int i = 0; i < eredmenyek.Count; i++)
            {

                if (eredmenyek[i] > beker)
                {
                    if (Math.Abs(eredmenyek[i] - beker) < kulonbseg)
                    {
                        kulonbseg = Math.Abs(eredmenyek[i] - beker);
                        index = i;
                        //Console.WriteLine(kulonbseg);
                    }
                }
                else
                {
                    if (Math.Abs(beker - eredmenyek[i]) < kulonbseg)
                    {
                        kulonbseg = Math.Abs(eredmenyek[i] - beker);
                        index = i;
                        //Console.WriteLine(kulonbseg);
                    }
                }
            }

            Console.WriteLine($"\tLegközelebbi pontszám: {nevek[index]}, {eredmenyek[index]}");
            OtodikFeladat();

        }

        private static void NegyedikFeladat()
        {
            Console.Write("4. feladat: Adj meg egy nevet: ");
            string nev = Console.ReadLine();
            bool indult = false;

            for (int i = 0; i < nevek.Count; i++)
            {
                if (nev == nevek[i])
                {
                    Console.WriteLine($"\t{nev} indult a versenyen, eredménye: {eredmenyek[i]}");
                    indult = true;
                }
            }

            if (!indult)
            {
                Console.WriteLine($"\t{nev} nem indult a versenyen");
            }


        }

        private static void HarmadikFeladat()
        {
            eredmenyek.Sort();
			List<double> eredmenyek_rendez = new List<double>();
            
			for (int i = 0; i < eredmenyek.Count; i++)
            {
                eredmenyek_rendez.Add(eredmenyek[i]);
            }

            eredmenyek_rendez.Sort();

            Console.WriteLine("3. feladat: A 3 legeredményesebb versenyző:");
            int szamlalo = 1;
            for (int i = 0; i < eredmenyek.Count; i++)
            {
                if (eredmenyek[i] == eredmenyek_rendez[eredmenyek_rendez.Count - szamlalo])
                {
                    Console.WriteLine($"\t {szamlalo}. legjobb versenyző: {nevek[i]}, {eredmenyek[i]}");
                    i = 0;
                    szamlalo++;
                    if (szamlalo > 3)
                    {
                        return;
                    }
                }
            }
        }

        private static void MasodikFeladat()
        {
            double maxEredmeny = eredmenyek.Max();
            Console.Write("2. feladat: ");
            for (int i = 0; i < nevek.Count; i++)
            {
                if (eredmenyek[i] == maxEredmeny)
                {
                    Console.WriteLine($"A legtöbb pontot {nevek[i]} érte el, ami {eredmenyek[i]}%");
                }
            }
        }

        private static void ElsoFeladat()
        {
            Console.WriteLine($"1. feladat: A versenyen {nevek.Count} db versenyző indult");
        }

        private static void BeOlvas()
        {
            try
            {
                StreamReader be = new StreamReader("adatok.csv", Encoding.Default);
                be.ReadLine();
                while (!be.EndOfStream)
                {
                    SorFeltores(be.ReadLine());
                }
                be.Close();
                //Kiir();
            }
            catch (IOException)
            {
                Console.WriteLine("Hiba");
            }
        }

        private static void SorFeltores(string sor)
        {
            if (sor.Split(';')[0].Length > 2 && !sor.Split(';')[0].Contains(" "))
            {
                nevek.Add(sor.Split(';')[0]);
                eredmenyek.Add(Convert.ToDouble(sor.Split(';')[1]));
            }
        }

        private static void Kiir()
        {
            Console.WriteLine("A fájl tartalma:\n------------------------");
            for (int i = 0; i < nevek.Count; i++)
            {
                Console.WriteLine($"{nevek[i]}, {eredmenyek[i]}");
            }
        }
    }
}
