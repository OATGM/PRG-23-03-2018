using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kocka_a_mys
{
    class prekazky
    {
        
        int x, y;
        string znak;
        public prekazky(int x, int y, string znak)
        {
            this.x = y;
            this.y = y;
            this.znak = znak;
        }

        public void kamen()
        {
            mapa.map[x, y] = znak;

        }
        public void dira()
        {
            mapa.map[x, y] = znak;

        }
        public void bazina()
        {
            mapa.map[x, y] = znak;

        }


    }
}
