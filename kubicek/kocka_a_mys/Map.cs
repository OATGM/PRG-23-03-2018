using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kocka_a_mys
{
    static class Map
    {
        public static int[,] map;
        static Map()
        {
            map = new int[15, 15];
            SetWalls();
        }

        static void SetWalls()
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                Map.map[0, i] = 1;
                Map.map[i, 0] = 1;
                Map.map[14, i] = 1;
                Map.map[i, 14] = 1;
            }

            map[4, 4] = 2;
            map[8, 8] = 3;
        }
    }
}
