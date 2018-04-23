using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kocka_a_Mys
{
    static class Mapa
    {
        
        private const int VELIKOST = 52;
        static private Char[,] mapa_pole;
        static public char[] zdi = {'─', '│', '┐', '┌', '┘', '└',  '*', 'K'};

        enum Prekazka
        {
            Kamen,
            Bazina,
            Díra
        }
        
        

        static public void VytvorMapu()
        {
            mapa_pole = new Char[VELIKOST, VELIKOST / 4]; //x , y
            for (int j = 0; j < mapa_pole.GetLength(1); j++)
            {
                for (int i = 0; i < mapa_pole.GetLength(0); i++)
                {
                    if (j == 0 || i == mapa_pole.GetLength(0) - 1 || j == mapa_pole.GetLength(1) - 1 || i == 0) { 
                        mapa_pole[i, j] = '*';
                    }
                    else
                    {
                        mapa_pole[i, j] = ' ';
                    }
                }
            }
        }

        static public char VratObjektNaMape(int posX, int posY)
        {
            return mapa_pole[posX, posY];
        }

        static public void UmistiObjekt(int posX, int posY, char znak) {
            mapa_pole[posX, posY] = znak;
        }

        static public String VykresliMapu()
        {
            string mapa = "";
            for (int j = 0; j < mapa_pole.GetLength(1); j++)
            {
                for (int i = 0; i < mapa_pole.GetLength(0); i++)
                {
                    mapa += mapa_pole[i, j];
                    if (i == (mapa_pole.GetLength(0) - 1)) mapa += "\n";

                }
            }
            return mapa;
        }

        public enum Smer
        {
            nahoru,
            dolu,
            doprava,
            doleva,
            neplatny
        }

    }
}
