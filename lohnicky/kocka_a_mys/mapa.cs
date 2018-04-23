using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kocka_a_mys
{
    class mapa
    {
        Random random = new Random();

        public static string[,] map = new string[20, 40];
        Program Program = new Program();
        
        public void naplnenipole()
        {
            for (int i = 0; i < 20; i++)
            {

                for (int j = 0; j < 40; j++)
                {
                    if (i == 0 || i == 19) map[i, j] = "*";
                    else if (j == 0 || j == 39) map[i, j] = "*";
                    else map[i, j] = " ";
                }
            }

        }
    


        public void vypis_pole()
        {
            Console.Clear();
            string vypis = "";
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 40; j++)
                {
                    vypis += map[i, j];
                }

                vypis += "\n";
            }
            Console.WriteLine(vypis);
        }

        public void pocet_pohybu(int pocet_pohybu)
        {
           
            Console.WriteLine("Počet pohybů je: " + pocet_pohybu);
        }

        public void pridani_prekazek()
        {
            prekazky kamen01 = new prekazky(random.Next(2, 39), random.Next(2, 19), "K");
            kamen01.kamen();
            prekazky dira01 = new prekazky(random.Next(2, 39), random.Next(2, 19), "D");
            dira01.kamen();
            prekazky bazina01 = new prekazky(random.Next(2, 39), random.Next(2, 19), "B");
            bazina01.kamen();


        }


    }

    

}
