using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace OOP_KalapacsVetes
{
    class Fajl
    {
        public static List<Versenyzo> Beolvas(string filename)
        {
            List<Versenyzo> versenyzos = new List<Versenyzo>();

            try
            {
                StreamReader be = new StreamReader(filename);
                be.ReadLine();
                while (!be.EndOfStream)
                    versenyzos.Add(new Versenyzo(be.ReadLine().Split(';')));
                be.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return versenyzos;
        }

        public static void Kiir(List<Versenyzo> data)
        {
            try
            {
                StreamWriter ki = new StreamWriter("Dontos2012.txt");
                ki.WriteLine("Helyezés;Név;Csoport;Nemzet;Kód;Sorozat;Eredmény");
                for (int i = 0; i < 12; i++)
                {
                    Versenyzo kifele = data.Find(x => x.Eredmeny == data.Max(y => y.Eredmeny));
                    ki.WriteLine($"{i+1};" +
                        $"{kifele.Nev};" +
                        $"{kifele.Csoport};" +
                        $"{kifele.Nemzet};" +
                        $"{kifele.Kod};" +
                        $"{kifele.Dobasok[0].Szoveg};" +
                        $"{kifele.Dobasok[1].Szoveg};" +
                        $"{kifele.Dobasok[2].Szoveg};" +
                        $"{kifele.Eredmeny}");
                    data.Remove(kifele);
                }
                ki.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
