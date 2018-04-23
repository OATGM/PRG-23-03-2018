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
    public partial class Form2 : Form
    {
        int kocka_x;
        int kocka_y;
        int mys_x;
        int mys_y;

        public Form2()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ControlBox = false;

        }



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                kocka_x = Convert.ToInt32(textBox1.Text);
                kocka_y = Convert.ToInt32(textBox3.Text);
                mys_x = Convert.ToInt32(textBox4.Text);
                mys_y = Convert.ToInt32(textBox2.Text);
            }
            catch
            {

            }

        }
    }
}
