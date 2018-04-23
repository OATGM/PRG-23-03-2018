using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kocka_a_Mys
{
    class Mys
    {
        public int PocetPohybu;
        private char ZnakMys;
        private int Posun;
        public int PosX { private set; get; }
        public int PosY { private set; get; }


        public Mys(char znak, int posun)
        {
            PosX = 40;
            PosY = 10;
            PocetPohybu = 0;
            Posun = posun;
            ZnakMys = znak;
            //Mapa.UmistiObjekt(PosX, PosY, ZnakMys);
        }

        public void NastavStartPos(Mapa.Smer smer)
        {
            Utikej(smer);
        }

    
        public Boolean Utikej(Mapa.Smer smer) // pro pohyb
        {
            int sPosX = PosX,
                sPosY = PosY;

            switch (smer)
            {
                case Mapa.Smer.nahoru:
                    PosY -= Posun;
                    break;
                case Mapa.Smer.dolu:
                    PosY += Posun;
                    break;
                case Mapa.Smer.doprava:
                    PosX += Posun;
                    break;
                case Mapa.Smer.doleva:
                    PosX -= Posun;
                    break;
            }

            //ověření, zda není v cestě překážka
            char objekt = Mapa.VratObjektNaMape(PosX, PosY);
            foreach (char o in Mapa.zdi)
            {
                if (o == objekt)
                {
                    PosX = sPosX; //navrátí původní hodnoty
                    PosY = sPosY;
                    return (false); //nemůže chodit přes zdi
                }
            }

            Mapa.UmistiObjekt(PosX, PosY, ZnakMys);
            Mapa.UmistiObjekt(sPosX, sPosY, ' ');

            if (!Hra.VybiraPolohu)
                PocetPohybu++;
            return (true);
        }
    }
}
