using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kocka_a_mys
{
    class charaktery
    {
        Random random = new Random();
        Program Program = new Program();
        static mapa mapa_class = new mapa();
        int x, y;

        public charaktery(int x,int y)
        {
            this.x = x;
            this.y = y;
        }

        public void vyobrazeni_charakteru(charaktery charakter,string znak)
        {
            charakter.x = random.Next(2, 15);
            charakter.y = random.Next(2, 35);
            mapa.map[x, y] = znak;
        }


        public int pohyb_charakteru_kocka(charaktery charakter)
        {
            if (Console.KeyAvailable)
            {
                var button = Console.ReadKey().Key;
                if (button == ConsoleKey.DownArrow)
                {
                    if (mapa.map[charakter.y + 1, charakter.x] == " ")
                    {
                        mapa.map[charakter.y, charakter.x] = "│";
                        y++;
                        mapa.map[charakter.y, charakter.x] = "O";
                        mapa_class.vypis_pole();
                        return 0;
                    }
                    else if (mapa.map[charakter.y + 1, charakter.x] == "D") return 1;
                    else if (mapa.map[charakter.y + 1, charakter.x] == "B") return 2;
                    else if (mapa.map[charakter.y + 1, charakter.x] == "X") return 3;
                    else return 0;
                }
                else if (button == ConsoleKey.UpArrow)
                {
                    if (mapa.map[charakter.y - 1, charakter.x] == " ")
                    {
                        mapa.map[charakter.y, charakter.x] = "│";
                        y--;
                        mapa.map[charakter.y, charakter.x] = "O";
                        mapa_class.vypis_pole();
                        return 0;
                    }
                    else if (mapa.map[charakter.y - 1, charakter.x] == "D") return 1;
                    else if (mapa.map[charakter.y - 1, charakter.x] == "B") return 2;
                    else if (mapa.map[charakter.y - 1, charakter.x] == "X") return 3;
                    else return 0;

                }
                else if (button == ConsoleKey.LeftArrow)
                {
                    if (mapa.map[charakter.y, charakter.x - 1] == " ")
                    {
                        mapa.map[charakter.y, charakter.x] = "─";
                        x--;
                        mapa.map[charakter.y, charakter.x] = "O";
                        mapa_class.vypis_pole();
                        return 0;
                    }
                    else if (mapa.map[charakter.y, charakter.x - 1] == "D") return 1;
                    else if (mapa.map[charakter.y, charakter.x - 1] == "B") return 2;
                    else if (mapa.map[charakter.y, charakter.x - 1] == "X") return 3;
                    else return 0;

                }
                else if (button == ConsoleKey.RightArrow)
                {
                    if (mapa.map[charakter.y, charakter.x + 1] == " ")
                    {
                        mapa.map[charakter.y, charakter.x] = "─";
                        x++;
                        mapa.map[charakter.y, charakter.x] = "O";
                        mapa_class.vypis_pole();
                        return 0;
                    }
                    else if (mapa.map[charakter.y, charakter.x + 1] == "D") return 1;
                    else if (mapa.map[charakter.y, charakter.x + 1] == "B") return 2;
                    else if (mapa.map[charakter.y, charakter.x + 1] == "X") return 3;
                    else return 0;

                }


                else return 0;
            }
            else return 0;
        }

    }
}
