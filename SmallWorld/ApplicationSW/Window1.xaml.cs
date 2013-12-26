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
        int j1;
        int j2;
        Joueur _j1;
        Joueur _j2;
        /// <summary>
        /// Enum permettant d'identifier les peuples
        /// </summary>
        enum NomPeuple { GAULOIS = 0, NAIN, VIKINGS };

        /// <summary>
        /// Construction de la fenetre du choix des joueurs
        /// </summary>
        public Window1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Réaction à l'evt "lancer une partie demo" (lancement de l'ecran de jeu avc une carte demo)
        /// </summary>
        /// <param name="sender">la fenetre </param>
        /// <param name="e"> </param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        { // Gestionnaire pour lancer une partie en choisissant une carte petite.
            StrategieCarte st = new CartePetite();
            creationJoueur(st.nombreUniteParPeuple());
            Window2 win = new Window2(st, _j1, _j2);
            win.Show();
            this.Close();
        }

        /// <summary>
        /// Réaction à l'evt "lancer une partie petite" (lancement de l'ecran de jeu avc une carte petite)
        /// </summary>
        /// <param name="sender">la fenetre </param>
        /// <param name="e"> </param>
        private void Button_Click_2(object sender, RoutedEventArgs e)
        { // Gestionnaire pour lancer une partie en choisissant une carte démo.
            StrategieCarte st = new CarteDemo();
            creationJoueur(st.nombreUniteParPeuple());
            Window2 win = new Window2(st, _j1, _j2);
            win.Show();
            this.Close();
        }

        /// <summary>
        /// Réaction à l'evt "lancer une partie normal" (lancement de l'ecran de jeu avc une carte normal)
        /// </summary>
        /// <param name="sender">la fenetre </param>
        /// <param name="e"> </param>
        private void Button_Click_3(object sender, RoutedEventArgs e)
        { // Gestionnaire pour lancer une partie en choisissant une carte normal.
            StrategieCarte st = new CarteNormale();
            creationJoueur(st.nombreUniteParPeuple());
            Window2 win = new Window2(st, _j1, _j2);
            win.Show();
            this.Close();
        }

        /// <summary>
        /// Réaction à l'evt "chargement de la ComboBox" (lancement avec un peuple deja selectionné pour j1)
        /// </summary>
        /// <param name="sender">la fenetre </param>
        /// <param name="e"> </param>
        private void ComboBox_Loaded(object sender, EventArgs e)
        {
            comboBoxJ2.SelectedIndex = (int)NomPeuple.NAIN;
            j2 = 1;
        }

        /// <summary>
        /// Réaction à l'evt "chargement de la ComboBox" (lancement avec un peuple deja selectionné pour j2)
        /// </summary>
        /// <param name="sender">la fenetre </param>
        /// <param name="e"> </param>
        private void ComboBox_Loaded_2(object sender, EventArgs e)
        {
            comboBoxJ1.SelectedIndex = (int)NomPeuple.GAULOIS;
            j1 = 0;
        }

        /// <summary>
        /// Réaction à l'evt "changement de la ComboBox" (changement du peuple selectionné par j1)
        /// </summary>
        /// <param name="sender">la fenetre </param>
        /// <param name="e"> </param>
        private void comboBoxJ1_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            // ... Get the ComboBox.
            var comboBoxJ1 = sender as ComboBox;

            // ... Set SelectedItem as Window Title.
            int value = comboBoxJ1.SelectedIndex;

            j1 = value;
            //Test de la valeur : 
            //MessageBox.Show(j1.ToString());
        }

        /// <summary>
        /// Réaction à l'evt "changement de la ComboBox" (changement du peuple selectionné par j2)
        /// </summary>
        /// <param name="sender">la fenetre </param>
        /// <param name="e"> </param>
        private void comboBoxJ2_SelectionChanged_2(object sender, SelectionChangedEventArgs e)
        {
            // ... Get the ComboBox.
            var comboBoxJ1 = sender as ComboBox;

            // ... Set SelectedItem as Window Title.
            int value = comboBoxJ1.SelectedIndex;
            j2 = value;
            //Test de la valeur :
            //MessageBox.Show(j2.ToString());
        }

        /// <summary>
        /// permet de construire un joueur
        /// </summary>
        /// <param name="nbUnite">le nombre d'unite maximum que controle le Joueur </param>
        private void creationJoueur(int nbUnite)
        {
            Peuple peupleJ1, peupleJ2;
            peupleJ1 = creerPeuple(nbUnite, j1);
            peupleJ2 = creerPeuple(nbUnite, j2);
            _j1 = new Joueur(nbUnite, peupleJ1);
            _j2 = new Joueur(nbUnite, peupleJ2);

        }

        /// <summary>
        /// permet de construire un peuple
        /// </summary>
        /// <param name="nbUnite">le nombre d'unite maximum </param>
        /// <param name="joueur">le peuple controle par le joueur (d'apres l'enum NomPeuple)</param>
        private Peuple creerPeuple(int nbUnite, int joueur)
        {
            Peuple peuple;
            switch (joueur)
            {
                case (int)NomPeuple.GAULOIS:
                    peuple = new Gaulois();
                    peuple.creerUnites(nbUnite);
                    break;

                case (int)NomPeuple.NAIN:
                    peuple = new Nains();
                    peuple.creerUnites(nbUnite);
                    break;

                case (int)NomPeuple.VIKINGS:
                    peuple = new Vikings();
                    peuple.creerUnites(nbUnite);
                    break;

                default:
                    return null;
            }
            return peuple;
        }

    }
}
