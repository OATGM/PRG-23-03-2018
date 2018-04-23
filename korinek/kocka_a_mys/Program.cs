using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kocka_a_mys
{
    class Program
    {
        static string[,] pole;
        static hraci_pole _hraci_pole = new hraci_pole();
        static void Main(string[] args)
        {
            pole = new string[7, 11];
            /*
            Console.WriteLine("Zadejte startovací pozici x pro kočku (1-11)");
            int pozice_kocka_x = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Zadejte startovací pozici y pro kočku (1-7)");
            int pozice_kocka_y = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Zadejte startovací pozici x pro myš (1-11)");
            int pozice_mys_x = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Zadejte startovací pozici y pro myš (1-7)");
            int pozice_mys_y = Convert.ToInt32(Console.ReadLine());
            */
            
            //nadefinovani pozic
            int pozice_kocka_x = 1, pozice_kocka_y = 1;
            int pozice_mys_x = 5, pozice_mys_y = 9;
            // dočasné pozice na porovnani toho zda se myš/kočka posunula nebo zůstala stát
            int tmp_k_x;
            int tmp_k_y;
            int tmp_m_x;
            int tmp_m_y;
            //metoda naplní pole (stěny + překážky)
            _hraci_pole.napln_pole(pole);
            // metody přiřadí startovací pozice pro kočku a myš
            _hraci_pole.start_pozice_kocka(pole);
            _hraci_pole.start_pozice_mys(pole);
            //metoda na výpis prvního pole
            Console.WriteLine(_hraci_pole.vypis_pole(pole));


            string smer;
            int pocet_pohybu_kocka = 1;
            int pocet_pohybu_mys = 1;
            //cyklus kdy běží hra -- když se ukončí vyskočí z cyklu
            while (true)
            {
                //point na zacatek pro kočku
                zacatek:
                //První hráč - kočka
                Console.WriteLine("Na tahu je Kočka");
                smer = Convert.ToString(Console.ReadLine());
                tmp_k_x = pozice_kocka_x;
                tmp_k_y = pozice_kocka_y;
                // Podmínky které vyhodnotí jaký byl zadán směr + zda hráč tám směrem může jít nebo zda prohrál/vyhrál když chytí myš
                if (smer == "s")
                {
                    pozice_kocka_x = _hraci_pole.pohyb_dolu(pole,pozice_kocka_x, pozice_kocka_y, true);
                    if (pozice_kocka_x == tmp_k_x)
                    {
                        Console.Clear();
                        Console.WriteLine(_hraci_pole.vypis_pole(pole));
                        Console.WriteLine("Je tam překážka hraj znovu");
                        goto zacatek;
                    }
                    if(pozice_kocka_x == 666)
                    {
                        Console.Clear();
                        Console.WriteLine("Kočka vyhrává!");
                        break;
                    }
                    if (pozice_kocka_x == 555)
                    {
                        Console.Clear();
                        Console.WriteLine("Myš vyhrává! - Kočka spadla do díry");
                        break;
                    }
                }
                if (smer == "w")
                {
                    pozice_kocka_x = _hraci_pole.pohyb_nahoru(pole, pozice_kocka_x, pozice_kocka_y, true);
                    if (pozice_kocka_x == tmp_k_x)
                    {
                        Console.Clear();
                        Console.WriteLine(_hraci_pole.vypis_pole(pole));
                        Console.WriteLine("Je tam překážka hraj znovu");
                        goto zacatek;
                    }
                    if (pozice_kocka_x == 666)
                    {
                        Console.Clear();
                        Console.WriteLine("Kočka vyhrává!");
                        break;
                    }
                    if (pozice_kocka_x == 555)
                    {
                        Console.Clear();
                        Console.WriteLine("Myš vyhrává! - Kočka spadla do díry");
                        break;
                    }
                }
                if (smer == "a")
                {
                    pozice_kocka_y = _hraci_pole.pohyb_doleva(pole, pozice_kocka_x, pozice_kocka_y, true);
                    if (pozice_kocka_y == tmp_k_y)
                    {
                        Console.Clear();
                        Console.WriteLine(_hraci_pole.vypis_pole(pole));
                        Console.WriteLine("Je tam překážka hraj znovu");
                        goto zacatek;
                    }
                    if (pozice_kocka_y == 666)
                    {
                        Console.Clear();
                        Console.WriteLine("Kočka vyhrává!");
                        break;
                    }
                    if (pozice_kocka_y == 555)
                    {
                        Console.Clear();
                        Console.WriteLine("Myš vyhrává! - Kočka spadla do díry");
                        break;
                    }
                }
                if (smer == "d")
                {
                    pozice_kocka_y = _hraci_pole.pohyb_doprava(pole, pozice_kocka_x, pozice_kocka_y, true);
                    if (pozice_kocka_y == tmp_k_y)
                    {
                        Console.Clear();
                        Console.WriteLine(_hraci_pole.vypis_pole(pole));
                        Console.WriteLine("Je tam překážka hraj znovu");
                        goto zacatek;
                    }
                    if (pozice_kocka_y == 666)
                    {
                        Console.Clear();
                        Console.WriteLine("Kočka vyhrává!");
                        break;
                    }
                    if (pozice_kocka_y == 555)
                    {
                        Console.Clear();
                        Console.WriteLine("Myš vyhrává! - Kočka spadla do díry");
                        break;
                    }
                }
                // Podmínka která vyhodnotí zda není špatně zadaná klávesa pohybu
                if (smer != "w" && smer != "s" && smer != "a" && smer != "d")
                {
                    Console.Clear();
                    Console.WriteLine(_hraci_pole.vypis_pole(pole));
                    Console.WriteLine("Špatně zadaná klávesa pohybu!");
                    goto zacatek;
                }
                Console.Clear();
                Console.WriteLine(_hraci_pole.vypis_pole(pole));
                if (pole[pozice_kocka_x - 1, pozice_kocka_y] != " " && pole[pozice_kocka_x + 1, pozice_kocka_y] != " " && pole[pozice_kocka_x, pozice_kocka_y + 1] != " " && pole[pozice_kocka_x, pozice_kocka_y - 1] != " ")
                {
                    Console.Clear();
                    Console.WriteLine("Myš vyhrává!");
                    break;
                }
                Console.WriteLine("Počet pohybů pro kočku: " + pocet_pohybu_kocka++);


            zacatek_mys:
                // po ni mys------------------------------------------------------------------------------------------ +
                tmp_m_x = pozice_mys_x;
                tmp_m_y = pozice_mys_y;
            
                Console.WriteLine("Na tahu je Myš");
                smer = Convert.ToString(Console.ReadLine());
                if (smer == "s")
                {
                    pozice_mys_x = _hraci_pole.pohyb_dolu(pole, pozice_mys_x, pozice_mys_y, false);
                    if (pozice_mys_x == tmp_m_x)
                    {
                        Console.Clear();
                        Console.WriteLine(_hraci_pole.vypis_pole(pole));
                        Console.WriteLine("Je tam překážka hraj znovu");
                        goto zacatek_mys;
                    }
                    if (pozice_mys_x == 666)
                    {
                        Console.Clear();
                        Console.WriteLine("Myš se nechala chytit, Kočka vyhrává!");
                        break;
                    }
                    if (pozice_mys_x == 555)
                    {
                        Console.Clear();
                        Console.WriteLine("Kočka vyhrává! - myš spadla do díry");
                        break;
                    }
                }
                if (smer == "w")
                {
                    pozice_mys_x = _hraci_pole.pohyb_nahoru(pole, pozice_mys_x, pozice_mys_y, false);
                    if (pozice_mys_x == tmp_m_x)
                    {
                        Console.Clear();
                        Console.WriteLine(_hraci_pole.vypis_pole(pole));
                        Console.WriteLine("Je tam překážka hraj znovu");
                        goto zacatek_mys;
                    }
                    if (pozice_mys_x == 666)
                    {
                        Console.Clear();
                        Console.WriteLine("Myš se nechala chytit, Kočka vyhrává!");
                        break;
                    }
                    if (pozice_mys_x == 555)
                    {
                        Console.Clear();
                        Console.WriteLine("Kočka vyhrává!  - myš spadla do díry");
                        break;
                    }
                }
                if (smer == "a")
                {
                    pozice_mys_y = _hraci_pole.pohyb_doleva(pole, pozice_mys_x, pozice_mys_y, false);
                    if (pozice_mys_y == tmp_m_y)
                    {
                        Console.Clear();
                        Console.WriteLine(_hraci_pole.vypis_pole(pole));
                        Console.WriteLine("Je tam překážka hraj znovu");
                        goto zacatek_mys;
                    }
                    if (pozice_mys_y == 666)
                    {
                        Console.Clear();
                        Console.WriteLine("Myš se nechala chytit, Kočka vyhrává!");
                        break;
                    }
                    if (pozice_mys_y == 555)
                    {
                        Console.Clear();
                        Console.WriteLine("Kočka vyhrává!  - myš spadla do díry");
                        break;
                    }
                }
                if (smer == "d")
                {
                    pozice_mys_y = _hraci_pole.pohyb_doprava(pole, pozice_mys_x, pozice_mys_y, false);
                    if (pozice_mys_y == tmp_m_y)
                    {
                        Console.Clear();
                        Console.WriteLine(_hraci_pole.vypis_pole(pole));
                        Console.WriteLine("Je tam překážka hraj znovu");
                        goto zacatek_mys;
                    }
                    if (pozice_mys_y == 666)
                    {
                        Console.Clear();
                        Console.WriteLine("Myš se nechala chytit, Kočka vyhrává!");
                        break;
                    }
                    if (pozice_mys_y == 555)
                    {
                        Console.Clear();
                        Console.WriteLine("Kočka vyhrává! - myš spadla do díry");
                        break;
                    }
                }
                if (smer != "w" && smer != "s" && smer != "a" && smer != "d")
                {
                    Console.Clear();
                    Console.WriteLine(_hraci_pole.vypis_pole(pole));
                    Console.WriteLine("Špatně zadaná klávesa pohybu!");
                    goto zacatek_mys;
                }


                Console.Clear();
                Console.WriteLine(_hraci_pole.vypis_pole(pole));
                Console.WriteLine("Počet pohybů pro myš: " + pocet_pohybu_mys++);


            }



            



        }
    }
}
