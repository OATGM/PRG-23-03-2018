using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace kocka_a_mys
{
    /// <summary>
    /// Interakční logika pro VyberPozic.xaml
    /// </summary>
    public partial class VyberPozic : Window
    {
        public VyberPozic()
        {
            InitializeComponent();
        }

        public static double kockaX, kockaY, mysX, mysY;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            kockaX = Convert.ToDouble(XKockaText.Text);
            kockaY = Convert.ToDouble(YKockaText.Text);
            mysX = Convert.ToDouble(XMysText.Text);
            mysY = Convert.ToDouble(XMysText.Text);
            MainWindow main = new MainWindow();
            main.Show();
        }
    }
}
