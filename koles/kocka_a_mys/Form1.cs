using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace kocka_a_mys
{
    public partial class Form1 : Form
    {
        public static int rows = 15;
        public static int cols = 15;
        int square_percent_l = 0;
        int square_percent_t = 10;
        int square_percent_b = 0;
        int square_percent_r = 0;
        float cellWidth;
        float cellHeight;
        float squreWidth_l;
        float squreHeight_t;
        float squreWidth_r;
        float squreHeight_b;
        Pen pen = new Pen(Color.Black);
        Brush brush = Brushes.Yellow;
        Brush red = Brushes.Red;
        Brush green = Brushes.Green;
        Brush darkgreen = Brushes.DarkGreen;
        Brush gray = Brushes.Gray;
        Brush black = Brushes.Black;
        Random nahoda = new Random();

        public int[,] hraci_pole = new int[15, 15];
        public bool na_rade = true;
        public int pocet_tahu = 0;
        public int prekazka = 20;
        public int prekazka_x = 0;
        public int prekazka_y = 0;
        public int bazina = 0;

        //1 - zed
        //2 - mys
        //3 - kocka
        //4 - kamen
        //5 - dira
        //6 - bazina

        public Form1()
        {
            napl();
            InitializeComponent();
            recount();
            label1.Text = "pocet tahů: " + pocet_tahu;
            label2.Text = "Na řadě: Kočka";
        }

        public void napl()
        {
            int pozice_kocky_x = nahoda.Next(1,13);
            int pozice_kocky_y = nahoda.Next(1,13);
            int pozice_mysy_x = nahoda.Next(1,13);
            int pozice_mysy_y = nahoda.Next(1,13);

            for (int i = 0; i < 15; i++)
            {
                hraci_pole[0, i] = 1;
                hraci_pole[i, 0] = 1;
                hraci_pole[14, i] = 1;
                hraci_pole[i, 14] = 1;

                hraci_pole[pozice_kocky_x, pozice_kocky_y] = 3;
                hraci_pole[pozice_mysy_x, pozice_mysy_y] = 2;
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            //square
            g.DrawLine(pen, squreWidth_l, squreHeight_t, this.ClientSize.Width - squreWidth_r, squreHeight_t);
            g.DrawLine(pen, squreWidth_l, this.ClientSize.Height - squreHeight_b, this.ClientSize.Width - squreWidth_r, this.ClientSize.Height - squreHeight_b);
            g.DrawLine(pen, squreWidth_l, squreHeight_t, squreWidth_l, this.ClientSize.Height - squreHeight_b);
            g.DrawLine(pen, this.ClientSize.Width - squreWidth_r, squreHeight_t, this.ClientSize.Width - squreWidth_r, this.ClientSize.Height - squreHeight_b);

            //field(lines)
            for (int i = 1; i < rows; i++)
            {
                g.DrawLine(pen, squreWidth_l, (i * cellHeight) + squreHeight_t, this.ClientSize.Width - squreWidth_r, (i * cellHeight) + squreHeight_t);
            }
            for (int i = 1; i < cols; i++)
            {
                g.DrawLine(pen, (i * cellWidth) + squreWidth_l, squreHeight_t, (i * cellWidth) + squreWidth_l, this.ClientSize.Height - squreHeight_b);
            }

            obsah(sender, e);
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            recount();
            Invalidate();
        }

        public void recount()
        {
            squreWidth_l = ((float)this.ClientSize.Width / 100) * square_percent_l;
            squreHeight_t = ((float)this.ClientSize.Height / 100) * square_percent_t;
            squreWidth_r = ((float)this.ClientSize.Width / 100) * square_percent_r;
            squreHeight_b = ((float)this.ClientSize.Height / 100) * square_percent_b;
            cellWidth = (((float)ClientSize.Width / 100) * (100 - (square_percent_l + square_percent_r))) / cols;
            cellHeight = (((float)ClientSize.Height / 100) * (100 - (square_percent_t + square_percent_b))) / rows;
            label1.Width = (int)cellWidth * 6;
            label1.Height = (int)cellHeight / 2;
            label1.Font = new Font("Arial", cellWidth / 5 + cellHeight / 5, FontStyle.Bold);
            label1.Location = new Point((int) cellWidth, (int)cellHeight / 2);
            label2.Width = (int)cellWidth * 6;
            label2.Height = (int)cellHeight / 2;
            label2.Font = new Font("Arial", cellWidth / 5 + cellHeight / 5, FontStyle.Bold);
            label2.Location = new Point(ClientSize.Width - (int)cellWidth * 6,(int)cellHeight / 2);
        }

        public void obsah(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    if (hraci_pole[i, j] == 1 || hraci_pole[i, j] == 7)
                    {

                        float x = squreWidth_l + (i * cellWidth);
                        float y = squreHeight_t + (j * cellHeight);
                        float width = cellWidth;
                        float height = cellHeight;

                        e.Graphics.FillRectangle(brush,x, y, width, height);
                    }
                    else if (hraci_pole[i, j] == 2)
                    {

                        float x = squreWidth_l + (i * cellWidth);
                        float y = squreHeight_t + (j * cellHeight);
                        float width = cellWidth;
                        float height = cellHeight;

                        e.Graphics.FillRectangle(red, x, y, width, height);
                    }
                    else if (hraci_pole[i, j] == 3)
                    {

                        float x = squreWidth_l + (i * cellWidth);
                        float y = squreHeight_t + (j * cellHeight);
                        float width = cellWidth;
                        float height = cellHeight;

                        e.Graphics.FillRectangle(green, x, y, width, height);
                    }
                    else if (hraci_pole[i, j] == 4)
                    {

                        float x = squreWidth_l + (i * cellWidth);
                        float y = squreHeight_t + (j * cellHeight);
                        float width = cellWidth;
                        float height = cellHeight;

                        e.Graphics.FillRectangle(gray, x, y, width, height);
                    }
                    else if (hraci_pole[i, j] == 5)
                    {

                        float x = squreWidth_l + (i * cellWidth);
                        float y = squreHeight_t + (j * cellHeight);
                        float width = cellWidth;
                        float height = cellHeight;

                        e.Graphics.FillRectangle(black, x, y, width, height);
                    }
                    else if (hraci_pole[i, j] == 6)
                    {

                        float x = squreWidth_l + (i * cellWidth);
                        float y = squreHeight_t + (j * cellHeight);
                        float width = cellWidth;
                        float height = cellHeight;

                        e.Graphics.FillRectangle(darkgreen, x, y, width, height);
                    }
                }
            }
        }


        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            int x = 0, y = 0;
            int posun = 0;
            int adventage = 0;
            int kostka = 0;
            bool tah_proveden = false;

            if(na_rade)
            {
                adventage = 1;
                posun = 3;
                kostka = 7;
            }
            else if (!na_rade)
            {
                adventage = 2;
                posun = 2;
                kostka = 0;
            }
            

            for (int i = 0; i < 14; i++)
            {
                for (int j = 0; j < 14; j++)
                {
                    if(posun == 3 && hraci_pole[i,j] == 3)
                    {
                        x = i;
                        y = j;
                    }
                    else if (posun == 2 && hraci_pole[i, j] == 2)
                    {
                        x = i;
                        y = j;
                    }
                }
            }

            try
            {
                if (e.KeyCode == Keys.W)
                {
                    if (hraci_pole[x, y - adventage] == 1 || hraci_pole[x, y - adventage] == 4 || hraci_pole[x, y - adventage] == 3 || (hraci_pole[x, y - adventage] == 7 && na_rade))
                    {
                        tah_proveden = true;
                    }
                    else
                    {
                        hraci_pole[x, y] = kostka;
                        if (hraci_pole[x, y - adventage] == 2 || hraci_pole[x, y - adventage] == 5)
                        {
                            game_over(3);
                        }

                        tah_proveden = true;
                        if (hraci_pole[x, y - adventage] == 6)
                        {
                            bazina = 1;
                            prekazka_x = -1;
                            prekazka_y = -1;
                        }
                        hraci_pole[x, y - adventage] = posun;

                    }
                }
                else if (e.KeyCode == Keys.S)
                {
                    if (hraci_pole[x, y + adventage] == 1 || hraci_pole[x, y + adventage] == 4 || hraci_pole[x, y + adventage] == 3 || (hraci_pole[x, y + adventage] == 7 && na_rade))
                    {
                        tah_proveden = true;
                    }
                    else
                    {
                        hraci_pole[x, y] = kostka;
                        if (hraci_pole[x, y + adventage] == 2 || hraci_pole[x, y + adventage] == 5)
                        {
                            game_over(3);
                        }

                        tah_proveden = true;
                        if (hraci_pole[x, y + adventage] == 6)
                        {
                            bazina = 1;
                            prekazka_x = -1;
                            prekazka_y = -1;
                        }
                        hraci_pole[x, y + adventage] = posun;
                    }
                }
                else if (e.KeyCode == Keys.D)
                {
                    if (hraci_pole[x + adventage, y] == 1 || hraci_pole[x + adventage, y] == 4 || hraci_pole[x + adventage, y] == 3 || (hraci_pole[x + adventage, y] == 7 && na_rade))
                    {
                        tah_proveden = true;
                    }
                    else
                    {
                        hraci_pole[x, y] = kostka;
                        if (hraci_pole[x + adventage, y] == 2 || hraci_pole[x + adventage, y] == 5)
                        {
                            game_over(3);
                        }

                        tah_proveden = true;
                        if (hraci_pole[x + adventage, y] == 6)
                        {
                            bazina = 1;
                            prekazka_x = -1;
                            prekazka_y = -1;
                        }
                        hraci_pole[x + adventage, y] = posun;

                    }
                }
                else if (e.KeyCode == Keys.A)
                {
                    if (hraci_pole[x - adventage, y] == 1 || hraci_pole[x - adventage, y] == 4 || hraci_pole[x - adventage, y] == 3 || (hraci_pole[x - adventage, y] == 7 && na_rade))
                    {
                        tah_proveden = true;
                    }
                    else
                    {
                        hraci_pole[x, y] = kostka;
                        if (hraci_pole[x - adventage, y] == 2 || hraci_pole[x - adventage, y] == 5)
                        {
                            game_over(3);
                        }

                        tah_proveden = true;
                        if (hraci_pole[x - adventage, y] == 6)
                        {
                            bazina = 1;
                            prekazka_x = -1;
                            prekazka_y = -1;
                        }
                        hraci_pole[x - adventage, y] = posun;
                    }
                }
                else if (e.KeyCode == Keys.Q)
                {
                    if (hraci_pole[x - adventage, y - adventage] == 1 || hraci_pole[x - adventage, y - adventage] == 4 || hraci_pole[x - adventage, y - adventage] == 3 || (hraci_pole[x - adventage, y - adventage] == 7 && na_rade))
                    {
                        tah_proveden = true;
                    }
                    else
                    {
                        hraci_pole[x, y] = kostka;
                        if (hraci_pole[x - adventage, y - adventage] == 2 || hraci_pole[x - adventage, y - adventage] == 5)
                        {
                            game_over(3);
                        }

                        tah_proveden = true;
                        if (hraci_pole[x - adventage, y - adventage] == 6)
                        {
                            bazina = 1;
                            prekazka_x = -1;
                            prekazka_y = -1;
                        }
                        hraci_pole[x - adventage, y - adventage] = posun;
                    }
                }
                else if (e.KeyCode == Keys.E)
                {
                    if (hraci_pole[x + adventage, y - adventage] == 1 || hraci_pole[x + adventage, y - adventage] == 4 || hraci_pole[x + adventage, y - adventage] == 3 || (hraci_pole[x + adventage, y - adventage] == 7 && na_rade))
                    {
                        tah_proveden = true;
                    }
                    else
                    {
                        hraci_pole[x, y] = kostka;
                        if (hraci_pole[x + adventage, y - adventage] == 2 || hraci_pole[x + adventage, y - adventage] == 5)
                        {
                            game_over(3);
                        }

                        tah_proveden = true;
                        if (hraci_pole[x + adventage, y - adventage] == 6)
                        {
                            bazina = 1;
                            prekazka_x = -1;
                            prekazka_y = -1;
                        }
                        hraci_pole[x + adventage, y - adventage] = posun;
                    }
                }
                else if (e.KeyCode == Keys.Y)
                {
                    if (hraci_pole[x - adventage, y + adventage] == 1 || hraci_pole[x - adventage, y + adventage] == 4 || hraci_pole[x - adventage, y + adventage] == 3 || (hraci_pole[x - adventage, y + adventage] == 7 && na_rade))
                    {

                    }
                    else
                    {
                        hraci_pole[x, y] = kostka;
                        if (hraci_pole[x - adventage, y + adventage] == 2 || hraci_pole[x - adventage, y + adventage] == 5)
                        {
                            game_over(3);
                        }

                        tah_proveden = true;
                        if (hraci_pole[x - adventage, y + adventage] == 6)
                        {
                            bazina = 1;
                            prekazka_x = -1;
                            prekazka_y = -1;
                        }
                        hraci_pole[x - adventage, y + adventage] = posun;
                    }
                }
                else if (e.KeyCode == Keys.C)
                {
                    if (hraci_pole[x + adventage, y + adventage] == 1 || hraci_pole[x + adventage, y + adventage] == 4 || hraci_pole[x + adventage, y + adventage] == 3 || hraci_pole[x + adventage, y + adventage] == 7)
                    {
                        tah_proveden = true;
                    }
                    else
                    {
                        hraci_pole[x, y] = kostka;
                        if (hraci_pole[x + adventage, y + adventage] == 2 || hraci_pole[x + adventage, y + adventage] == 5)
                        {
                            game_over(3);
                        }

                        tah_proveden = true;
                        if (hraci_pole[x + adventage, y + adventage] == 6)
                        {
                            bazina = 1;
                            prekazka_x = -1;
                            prekazka_y = -1;
                        }
                        hraci_pole[x + adventage, y + adventage] = posun;
                    }
                }
            }
            catch
            {
                tah_proveden = true;
            }

                if (tah_proveden)
                {
                    prekazky();
                    pocet_tahu++;
                    zmena_tahu(x, y);
                }
                Invalidate();
                label1.Text = "pocet tahů: " + pocet_tahu;
            
        }

        public void prekazky()
        {
            if (prekazka == 17)
            {
                if (hraci_pole[prekazka_x, prekazka_y] == 2)
                {
                    hraci_pole[prekazka_x, prekazka_y] = 2;
                }
                else if (hraci_pole[prekazka_x, prekazka_y] == 3)
                {
                    hraci_pole[prekazka_x, prekazka_y] = 3;
                }
                else
                {
                    hraci_pole[prekazka_x, prekazka_y] = 0;
                }

            }
            if (prekazka == 20)
            {
                int druh = nahoda.Next(4, 7);
                do
                {
                    prekazka_x = nahoda.Next(1, 13);              
                    prekazka_y = nahoda.Next(1, 13);
                } while (hraci_pole[prekazka_x,prekazka_y] > 1);


                hraci_pole[prekazka_x, prekazka_y] = druh;
                prekazka = 0;
            }
            prekazka++;



        }

        public void zmena_tahu(int x,int y)
        {
            if(na_rade && bazina != 2)
            {
                na_rade = false;
                label2.Text = "Na řadě: Myš";
            }
            else if(bazina != 2)
            {
                na_rade = true;
                label2.Text = "Na řadě: Kočka";
            }
            if (bazina == 1)
            {
                bazina++;
            }
            else if (bazina == 2)
            {
                bazina = 0;
            }
        }

        public void game_over(int v)
        {
            MessageBox.Show("game over");
        }
    }
}
