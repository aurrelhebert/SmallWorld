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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ApplicationSW
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Construction de la fenetre de lancement
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Action reagissant au click sur le bouton : demarrage de la partie, acces a l'ecran choix des joueurs
        /// </summary>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window1 win2 = new Window1();
            win2.Show();
            this.Close();
        }
    }
}
