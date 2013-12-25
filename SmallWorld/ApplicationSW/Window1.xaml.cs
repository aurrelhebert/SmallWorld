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
using SmallWorld;

namespace ApplicationSW
{
    /// <summary>
    /// Logique d'interaction pour Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        { // Gestionnaire pour lancer une partie en choisissant une carte petite.
            StrategieCarte st = new CartePetite();
            Window2 win = new Window2(st);
            win.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        { // Gestionnaire pour lancer une partie en choisissant une carte démo.
            StrategieCarte st = new CarteDemo();
            Window2 win = new Window2(st);
            win.Show();
            this.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        { // Gestionnaire pour lancer une partie en choisissant une carte normal.
            StrategieCarte st = new CarteNormale();
            Window2 win = new Window2(st);
            win.Show();
            this.Close();
        }
    }
}
