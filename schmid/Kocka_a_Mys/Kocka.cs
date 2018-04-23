using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kocka_a_Mys
{
    class Kocka
    {
        public int PocetPohybu;
        private char ZnakKocka;
        private int Posun;
        public int PosX { private set; get; }
        public int PosY { private set; get; }


        public Kocka(char znak, int posun)
        {
            PocetPohybu = 0;
            Posun = posun;
            //smazet
            PosX = 1;
            PosY = 1;
            ZnakKocka = znak;
            Mapa.UmistiObjekt(PosX, PosY, ZnakKocka);
        }

        public void NastavStartPos(Mapa.Smer smer)
        {
            ChytMys(smer);
        }

        public Boolean ChytMys(Mapa.Smer smer) //pro pohyb
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
            char objekt = Mapa. VratObjektNaMape(PosX, PosY);
            foreach (char o in Mapa.zdi)
            {
                if (o == objekt)
                {
                    PosX = sPosX; //navrátí původní hodnoty
                    PosY = sPosY;
                    return (false); //nemůže chodit přes zdi
                }
            }

            Mapa.UmistiObjekt(PosX, PosY, ZnakKocka);

            if (!Hra.VybiraPolohu)
            {
                //if(sPosX == PosX && sPosY > PosY)
                //  Mapa.UmistiObjekt(sPosX, sPosY, '┘');
                if (sPosY == PosY)
                    Mapa.UmistiObjekt(sPosX, sPosY, '─');
                else if (sPosX == PosX)
                    Mapa.UmistiObjekt(sPosX, sPosY, '│');
                PocetPohybu++;
            }
            else Mapa.UmistiObjekt(sPosX, sPosY, ' ');
            return (true);
        }

    }
}
