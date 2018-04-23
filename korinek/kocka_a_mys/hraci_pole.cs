using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kocka_a_mys
{
    class hraci_pole
    {

        public void napln_pole(string[,] pole)
        {
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 11; j++)
                {

                    pole[i, j] = " ";
                    if (i == 0 || i == 6)
                    {
                        pole[i, j] = "*";
                    }
                                     

                    if (j==0 || j == 10)
                    {
                        pole[i, j] = "*";
                    }            
                                    
                    
                    
                }
            }

            pole[3, 5] = "K";
            pole[4, 5] = "D";
        }

        public string vypis_pole(string[,] pole)
        {
            
            string vypis = "";
            for (int i = 0; i < 7; i++)
            {
                
                for (int j = 0; j < 11; j++)
                {
                    vypis += pole[i, j];
                                     
                }
                vypis += "\n";
            }
            return vypis;
        }


        public void start_pozice_kocka(string[,] pole)
        {
            pole[1, 1] = "O";
        }
        public void start_pozice_mys(string[,] pole)
        {
            pole[5, 9] = "X";
        }


        
        public int pohyb_dolu(string[,] pole, int x, int y, bool kocka)
        {
            if (pole[x + 1,y] == "*" || pole[x + 1, y] == "│" || pole[x + 1, y] == "─" || pole[x + 1, y] == "K")
            {
                return x;
            }
            if (pole[x + 1, y] == "X" || pole[x + 1, y] ==  "O")
            {
                return 666;
            }
            if (pole[x + 1, y] == "D")
            {
                return 555;
            }

            string tmp = pole[x, y];
            if (kocka == true)
            {
                pole[x, y] = "│";
            }
            else pole[x, y] = " ";
            x = x + 1;
            pole[x, y] = tmp;
            return x;
            
        }

        public int pohyb_nahoru(string[,] pole, int x, int y, bool kocka)
        {
            if (pole[x - 1, y] == "*" || pole[x - 1, y] == "│" || pole[x - 1, y] == "─" || pole[x - 1, y] == "K")
            {
                return x;
            }
            if (pole[x - 1, y] == "X" || pole[x - 1, y] == "O")
            {
                return 666;
            }
            if (pole[x - 1, y] == "D")
            {
                return 555;
            }
        
            string tmp = pole[x, y];
            if (kocka == true)
            {
                pole[x, y] = "│";
            }
            else pole[x, y] = " ";
            x = x + -1;
            pole[x, y] = tmp;
            return x;

        }

        public int pohyb_doleva(string[,] pole, int x, int y, bool kocka)
        {
            if (pole[x, y-1] == "*" || pole[x, y - 1] == "│" || pole[x, y - 1] == "─" || pole[x, y - 1] == "K")
            {
                return y;
            }
            if (pole[x, y - 1] == "X" || pole[x, y - 1] == "O")
            {
                return 666;
            }
            if (pole[x, y - 1] == "D")
            {
                return 555;
            }

            string tmp = pole[x, y];
            if (kocka == true)
            {
                pole[x, y] = "─";
            }
            else pole[x, y] = " ";
            y = y - 1;
            pole[x, y] = tmp;
            return y;

        }

        public int pohyb_doprava(string[,] pole, int x, int y, bool kocka)
        {
            
            if (pole[x, y + 1] == "*" || pole[x, y + 1] == "│" || pole[x, y + 1] == "─" || pole[x, y + 1] == "K")
            {
                return y;
            }
            if (pole[x, y + 1] == "X" || pole[x, y + 1] == "O")
            {
                return 666;
            }
            if (pole[x, y + 1] == "D")
            {
                return 555;
            }

          
            string tmp = pole[x, y];
            if (kocka == true)
            {
                pole[x, y] = "─";
            }
            else pole[x, y] = " ";
            y = y + 1;
            pole[x, y] = tmp;
            return y;

        }

        


    }

    
}
