using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Operatorok
{
    class Feladat
    {
        public static List<Operator> operators = Action.Beolvas("operatorok.txt");
        public Feladat()
        {
            _1();
            _2();
            _3();
            _4();
            _5();
            _6();
            _7();
        }

        private void _7()
        {
            int anglia = operators.Count(x => x.Szarmazas == "Anglia");
            int nemet = operators.Count(x => x.Szarmazas == "Németország");
            string valasz = anglia > nemet ? "Angliában" : "Németországban";
            Console.WriteLine($"\n7. feladat: \n\t{valasz} van több operátor");

            List<Orszag> orszagok = new List<Orszag>();
            foreach (Operator item in operators) orszagok = Ellenoriz(orszagok, item);

            int legtobb_tamado = orszagok.Max(x => x.Tamadok);
            int legkevesebb_vedo= orszagok.Min(x => x.Vedok);



        }

        private List<Orszag> Ellenoriz(List<Orszag> orszagok, Operator item)
        {
            bool talalt = false;
            foreach (Orszag orszag in orszagok)
            {
                if (orszag.Nev == item.Szarmazas)
                {
                    talalt = true;
                    if (item.Oldal == "Támadó")
                        orszag.Tamadok++;
                    else
                        orszag.Vedok++;
                    break;
                }
            }

            if (!talalt) orszagok.Add(new Orszag(item.Szarmazas));

            return orszagok;
        }

        private void _6()
        {
            Console.WriteLine($"\n6. feladat:" +
                $"\n\t{operators.Count(x => x.Kor < 35 && x.Szarmazas == "Kanada")} db 35 év alatti kanadai operátor van");
        }

        private void _5()
        {
            Console.WriteLine("\n5. feladat:");

            List<Operator> fbi_swat = operators.FindAll(x => x.Alakulat == "FBI SWAT" && x.Kor >= 25 && x.Kor <= 45).ToList();
            foreach (Operator item in fbi_swat) item.Kiir();

            List<Operator> legidosebbek = operators.FindAll(x => x.Kor == operators.Max(y => y.Kor)).ToList();
            List<Operator> legfiatalabbak = operators.FindAll(x => x.Kor == operators.Min(y => y.Kor)).ToList();

            Console.WriteLine("\nLegidősebbek:");
            foreach (Operator item in legidosebbek) item.Kiir();

             Console.WriteLine("\nLegfiatalabbak:");
            foreach (Operator item in legfiatalabbak) item.Kiir();
        }

        private void _4()
        {
            int ferfi_vedo = operators.Count(x => x.Nem == "Férfi" && x.Oldal == "Védő");
            int noi_tamado = operators.Count(x => x.Nem == "Nő" && x.Oldal == "Támadó");
            Console.WriteLine($"\n4. feladat:\n\tÖsszesen {ferfi_vedo} férfi védő van és {noi_tamado} női támadó van");
        }

        private void _3()
        {
            Operator kona = operators.Find(x => x.Taktikai == "Kóna Station");
            Console.WriteLine($"\n3. feladat:\n\t{kona.Nev} - {kona.Taktikai}");
        }

        private void _2()
        {
            Console.WriteLine("\n2. feladat:");
            List<Operator> sas = operators.FindAll(x => x.Alakulat == "SAS" && x.Oldal == "Támadó").ToList();
            foreach (Operator item in sas) item.Kiir();
        }

        private void _1()
        {
            double ferfiak = operators.Count(x => x.Nem == "Férfi");
            Console.WriteLine($"1. feladat: \n\tA sfddfss {operators.Count} adatot tearatlamz, ebből {ferfiak * 100 / operators.Count:0.00}%-a férfi, {(operators.Count - ferfiak) * 100 / operators.Count:0.00}%-a nő");

        }
    }
}
