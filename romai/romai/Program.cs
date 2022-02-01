using System;

namespace romai
{
    class Program
    {
        public static string[] romai_szamok = new string[] { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "VIII", "VII", "VI", "V", "IV", "I" };
        public static int[] arab_szamok = new int[] { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 8, 7, 6, 5, 4, 1 };
        static void Main(string[] args)
        {
            Console.WriteLine("Mit szeretnél csinálni?\n1: Arab --> Római\n2: Római --> Arab");
            string valasz = Console.ReadLine();
            if (valasz == "1")
            {
                Console.Write("Írj be egy arab számot: ");
                int arabszam = Convert.ToInt32(Console.ReadLine());
                while (arabszam > 4000 || arabszam < 0)
                {
                    Console.Write("A számnak 3999 és 1 között kell lennie. Írj be egy új számot: ");
                    arabszam = Convert.ToInt32(Console.ReadLine());
                }

                string arabToRomai = "";

                int egyesek = arabszam % 10;
                int tizesek = (arabszam / 10) % 10;
                int szazasok = (arabszam / 100) % 10;
                int ezresek = arabszam / 1000;

                while (arabszam != 0)
                {
                    switch (ezresek)
                    {
                        case int szam when szam > 0:
                            arabToRomai += "M";
                            ezresek -= 1;
                            arabszam -= 1000;
                            break;
                        default:
                            break;
                    }
                    if (ezresek == 0)
                    {
                        switch (szazasok)
                        {
                            case 9:
                                arabToRomai += "CM";
                                szazasok -= 9;
                                arabszam -= 900;
                                break;
                            case int szam when szam >= 5:
                                arabToRomai += "D";
                                szazasok -= 5;
                                arabszam -= 500;
                                break;
                            case 4:
                                arabToRomai += "CD";
                                szazasok -= 4;
                                arabszam -= 400;
                                break;
                            case int szam when szam > 0:
                                arabToRomai += "C";
                                szazasok -= 1;
                                arabszam -= 100;
                                break;
                            default:
                                break;
                        }
                        if (szazasok == 0)
                        {
                            switch (tizesek)
                            {
                                case 9:
                                    arabToRomai += "XC";
                                    tizesek -= 9;
                                    arabszam -= 90;
                                    break;
                                case int szam when szam >= 5:
                                    arabToRomai += "L";
                                    tizesek -= 5;
                                    arabszam -= 50;
                                    break;
                                case 4:
                                    arabToRomai += "XL";
                                    tizesek -= 4;
                                    arabszam -= 40;
                                    break;
                                case int szam when szam > 0:
                                    arabToRomai += "X";
                                    tizesek -= 1;
                                    arabszam -= 10;
                                    break;
                                default:
                                    break;
                            }
                            if (tizesek == 0)
                            {
                                switch (egyesek)
                                {
                                    case 9:
                                        arabToRomai += "IX";
                                        egyesek -= 9;
                                        arabszam -= 9;
                                        break;
                                    case 8:
                                        arabToRomai += "VIII";
                                        egyesek -= 8;
                                        arabszam -= 8;
                                        break;
                                    case 7:
                                        arabToRomai += "VII";
                                        egyesek -= 7;
                                        arabszam -= 7;
                                        break;
                                    case 6:
                                        arabToRomai += "VI";
                                        egyesek -= 6;
                                        arabszam -= 6;
                                        break;
                                    case 5:
                                        arabToRomai += "V";
                                        egyesek -= 5;
                                        arabszam -= 5;
                                        break;
                                    case 4:
                                        arabToRomai += "IV";
                                        egyesek -= 4;
                                        arabszam -= 4;
                                        break;
                                    case int szam when szam > 0:
                                        arabToRomai += "I";
                                        egyesek -= 1;
                                        arabszam -= 1;
                                        break;
                                    default:
                                        break;
                                }
                            }
                        }
                        
                    }
                }

                Console.WriteLine($"Római szám: {arabToRomai}");

            }
            else if (valasz == "2")
            {
                Console.Write("Írj be egy római számot: ");
                string romaiszam = Console.ReadLine().ToUpper();
                int romaiToArab = 0;

                for (int i = 0; i < romaiszam.Length; i++)
                {
                    for (int j = 0; j < romai_szamok.Length; j++)
                    {
                        if (i != romaiszam.Length - 1)
                        {
                            string vizsgalt = romaiszam[i].ToString() + romaiszam[i + 1].ToString();
                            if (vizsgalt == romai_szamok[j])
                            {
                                romaiToArab += arab_szamok[j];
                                i++;
                                break;
                            }
                            else if (romaiszam[i].ToString() == romai_szamok[j])
                            {
                                romaiToArab += arab_szamok[j];
                            }
                        }
                        else if (romaiszam[i].ToString() == romai_szamok[j])
                        {
                            romaiToArab += arab_szamok[j];
                            break;
                        }
                    }
                }

                Console.WriteLine($"Arab szám: {romaiToArab}");
            }
            else
            {
                Console.WriteLine("Hiba");
            }

            Console.ReadKey();
        }
    }
}
