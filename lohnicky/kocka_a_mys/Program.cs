using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kocka_a_mys
{
    class Program
    {
        
        static int pohybu = 0;
        static mapa mapa_class = new mapa();
        
        static void Main(string[] args)
        {
            mapa_class.naplnenipole();
            
            mapa_class.pocet_pohybu(pohybu);
            charaktery kocka = new charaktery(0, 0);
            charaktery mys = new charaktery(0, 0);
            kocka.vyobrazeni_charakteru(kocka,"O");
            mys.vyobrazeni_charakteru(mys,"X");

            mapa_class.pridani_prekazek();
            mapa_class.vypis_pole();
            
            while (true)
            {
                int kontrola = kocka.pohyb_charakteru_kocka(kocka);
                if (kontrola == 0) ;
                else if (kontrola == 1)
                {
                    Console.Clear();
                    Console.WriteLine("Konec hry");
                    break;
                }
                else if (kontrola == 2) ; //todo
                else if (kontrola == 3)
                {
                    Console.Clear();
                    Console.WriteLine("Vyhrál jsi");
                    break;
                }
                

                
            }
            
           


        }
    }
}
