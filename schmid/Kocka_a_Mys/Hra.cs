using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kocka_a_Mys
{
    class Hra
    {
        static char ZnakKocka = 'O';
        static char ZnakMys = 'x';
        public static Boolean VybiraPolohu ;
        public static Boolean VybiraKocka = true;
        private static Zvire Hraje; //kdo je na řadě
        private static int KamenX = 25;
        private static int KamenY = 5;
        private static int DiraX = 40;
        private static int DiraY = 10;
        private static int BazinaX = 5;
        private static int BazinaY = 3;

        enum Zvire
        {
            Kočka,
            Myš
        }

        static Kocka Tom;
        public static Mys Jerry;

        public static void Update(string zprava = "")
        {
            Console.Clear();
            if (!VybiraPolohu)
            {
                Console.SetCursorPosition(60, 2);
                Console.WriteLine("Je na řadě: " + Hraje.ToString());
                Console.SetCursorPosition(60, 3);
                Console.WriteLine("Počet pohybů: " + (Tom.PocetPohybu + Jerry.PocetPohybu));
            }
            Console.SetCursorPosition(0, 0);
            if (zprava != "") Console.WriteLine(zprava);
            Console.WriteLine(Mapa.VykresliMapu());
        }

        static public void NastavHru()
        {
            Mapa.VytvorMapu();

            VybiraPolohu = true;
            Jerry = new Mys(ZnakMys, 1);
            Tom = new Kocka(ZnakKocka, 1);

            do
            {

                Update("Umístěte znak O, tam kde chcete, aby kočka začínala. Akci potvrďte enterem.");
                Tom.NastavStartPos(ZiskejSmer());
            } while (VybiraKocka);


            VybiraPolohu = true; //vybrání polohy pro myš

            do
            {

                Update("Umístěte znak x, tam kde chcete, aby myš začínala. Akci potvrďte enterem.");
                Jerry.NastavStartPos(ZiskejSmer());
                
            } while (VybiraPolohu);

            if (Mapa.VratObjektNaMape(KamenX, KamenY) == ' ')
                Mapa.UmistiObjekt(KamenX, KamenY, 'K');
            if (Mapa.VratObjektNaMape(DiraX, DiraY) == ' ')
                Mapa.UmistiObjekt(DiraX, DiraY, 'D');
            if (Mapa.VratObjektNaMape(BazinaX, BazinaY) == ' ')
                Mapa.UmistiObjekt(BazinaX, BazinaY, 'B');

        }

        static public void Hrej()
        {
            while (true)
            {
                Update();

                if (!HrajeTom()) break;
                if (!HrajeJerry()) break;
            }
        }

        public static Boolean HrajeJerry()
        {
            bool pohnulSe;
            do { pohnulSe = Jerry.Utikej(ZiskejSmer()); }
            while (!pohnulSe);
            if (Tom.PosX == Jerry.PosX && Tom.PosY == Jerry.PosY)
            {
                Console.WriteLine("Konec Hry - Jerry se nechal chytit.. :( ");
                return false;
            }
            if (Jerry.PosX == DiraX && Jerry.PosY == DiraY)
            {
                Console.WriteLine("Konec Hry - Tom spadl do díry :O");
                return false;
            }
            if (Jerry.PosX == BazinaX && Jerry.PosY == BazinaY)
            {
                Console.WriteLine("Výhoda - Tom může hrát 2x!");
                HrajeTom();
            }
            pohnulSe = false; //vynulování pro další kolo
            Hraje = Zvire.Kočka;
            return true;
        }

        public static Boolean HrajeTom()
        {
            bool pohnulSe;

            do { pohnulSe = Tom.ChytMys(ZiskejSmer()); }
            while (!pohnulSe);
            if (Tom.PosX == Jerry.PosX && Tom.PosY == Jerry.PosY)
            {
                Console.WriteLine("Konec Hry - Tom chytil Jerryho!!!");
                return false;
            }
            if (Tom.PosX == DiraX && Tom.PosY == DiraY)
            {
                Console.WriteLine("Konec Hry - Tom spadl do díry :O");
                return false;
            }
            if (Tom.PosX == BazinaX && Tom.PosY == BazinaY)
            {
                Console.WriteLine("Výhoda - Jerry může hrát 2x!");
                HrajeJerry();
            }
            pohnulSe = false; //využiji stejnou proměnnou pro myš 
            Hraje = Zvire.Myš;
            Update();//aktualizace
            return true;
        }

        static void Main(string[] args)
        {

            NastavHru(); // nastaví objekty a jejich výhcozí pozice
            Hrej();
        }

        static Mapa.Smer ZiskejSmer() {
            Mapa.Smer smer = Mapa.Smer.neplatny;
            bool OK = false;
            while (!OK)
            {
                ConsoleKey key = Console.ReadKey().Key;
                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        smer = Mapa.Smer.nahoru;
                        OK = true;
                        break;
                    case ConsoleKey.DownArrow:
                        smer = Mapa.Smer.dolu;
                        OK = true;
                        break;
                    case ConsoleKey.LeftArrow:
                        smer = Mapa.Smer.doleva;
                        OK = true;
                        break;
                    case ConsoleKey.RightArrow:
                        smer = Mapa.Smer.doprava;
                        OK = true;
                        break;
                    default:
                        if (VybiraPolohu)
                        {
                            if (!VybiraKocka) {
                                VybiraPolohu = false; //pokud vybere i myš
                            } 
                            VybiraKocka = false;
                            
                        }
                        OK = false;
                        break;
                }
            }
            return smer;
        }



    }
}
