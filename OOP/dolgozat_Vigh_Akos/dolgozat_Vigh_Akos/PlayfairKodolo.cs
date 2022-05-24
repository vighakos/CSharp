using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace dolgozat_Vigh_Akos
{
    class PlayfairKodolo
    {
        public string[,] KarakterMatrix;
        public PlayfairKodolo(string fajlnev)
        {
            KarakterMatrix = FajlIO.Beolvas(fajlnev);
        }

        public int SorIndex(string karakter)
        {
            for (int sor = 0; sor < 5; sor++)
            {
                for (int oszlop = 0; oszlop < 5; oszlop++)
                {
                    if (KarakterMatrix[sor, oszlop] == karakter)
                    {
                        return sor;
                    }
                }
            }
            return -1;
        }
        
        public int OszlopIndex(string karakter)
        {
            for (int sor = 0; sor < 5; sor++)
            {
                for (int oszlop = 0; oszlop < 5; oszlop++)
                {
                    if (KarakterMatrix[sor, oszlop] == karakter)
                    {
                        return oszlop;
                    }
                }
            }
            return -1;
        }

        public string KodolBetupar(string betupar)
        {
            string kodolt = "";
            string elsobetu = betupar[0].ToString();
            string masodikbetu = betupar[1].ToString();

            // 7a sorindex egyenlő
            if (SorIndex(elsobetu) == SorIndex(masodikbetu))
            {
                int sorindex = SorIndex(elsobetu);

                if (OszlopIndex(elsobetu) == 4)
                {
                    kodolt += KarakterMatrix[sorindex, 0] + KarakterMatrix[sorindex, OszlopIndex(masodikbetu) + 1];
                }
                else if (OszlopIndex(masodikbetu) == 4)
                {
                    kodolt += KarakterMatrix[sorindex, OszlopIndex(elsobetu) + 1] + KarakterMatrix[sorindex, 0];
                }
                else
                {
                    kodolt += KarakterMatrix[sorindex, OszlopIndex(elsobetu) + 1] + KarakterMatrix[sorindex, OszlopIndex(masodikbetu) + 1];
                }
                return kodolt;
            }

            // 7b oszlopindex egyenlő
            if (OszlopIndex(elsobetu) == OszlopIndex(masodikbetu))
            {
                int oszlopindex = OszlopIndex(elsobetu);

                if (SorIndex(elsobetu) == 4)
                {
                    kodolt += KarakterMatrix[0, oszlopindex] + KarakterMatrix[SorIndex(masodikbetu) + 1, oszlopindex];
                } 
                else if (SorIndex(masodikbetu) == 4)
                {
                    kodolt += KarakterMatrix[SorIndex(elsobetu) + 1, oszlopindex] + KarakterMatrix[0, oszlopindex];
                }
                else
                {
                    kodolt += KarakterMatrix[SorIndex(elsobetu) + 1, oszlopindex] + KarakterMatrix[SorIndex(masodikbetu) + 1, oszlopindex];
                }
                return kodolt;
            }

            // 7c téglalap
            kodolt += KarakterMatrix[SorIndex(elsobetu), OszlopIndex(masodikbetu)] + KarakterMatrix[SorIndex(masodikbetu), OszlopIndex(elsobetu)];
            return kodolt;
        }
    }
}
