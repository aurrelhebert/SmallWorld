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
using Cours.Shared;
using Wrapper;
using SmallWorld;
using System.Windows.Controls.Primitives;

namespace ApplicationSW
{
    /// <summary>
    /// Logique d'interaction pour Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {

        //  V1 : gestion avec evts classiques
        //Rectangle selectedVisual;
        Partie MaPartie;
        /// <summary>
        /// Enum permettant d'identifier les cases
        /// </summary>
        StrategieCarte strategie;

        /// <summary>
        /// Construction de la fenetre de jeu
        /// </summary>
        unsafe public Window2(StrategieCarte st, Joueur j1, Joueur j2)
        {
            InitializeComponent();
            //engine = new Cours.Engine.Engine();
            strategie = st;
            //int taille = strategie.tailleCarte();
            //int nbTours = strategie.nombreDeTour();
            MaPartie = new Partie(j1, j2, st);
        }


        /// <summary>
        /// Réaction à l'evt "la fenetre est construite" (référencé dans le MainWithEvents.xaml)
        /// </summary>
        /// <param name="sender">la fenetre </param>
        /// <param name="e"> l'evt : la fenetre est construite</param>
        unsafe private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // on initialise la Grid (mapGrid défini dans le xaml) à partir de la map du modèle (engine)
            for (int c = 0; c < MaPartie.getCarte().getLongueurCote(); c++)
            {
                mapGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(60, GridUnitType.Pixel) });
            }
            for (int l = 0; l < MaPartie.getCarte().getLongueurCote(); l++)
            {
                mapGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(40, GridUnitType.Pixel) });
                for (int c = 0; c < MaPartie.getCarte().getLongueurCote(); c++)
                {
                    // dans chaque case de la grille on ajoute une tuile (logique) matérialisée par un rectangle (physique)
                    // le rectangle possède une référence sur sa tuile
                    Case.TypeCase num = MaPartie.getCarte().getTypeCase(c, l);
                    var element = createRectangle(c, l, (int)num);
                    mapGrid.Children.Add(element);
                }
            }
            //MessageBox.Show(xJ2.ToString() + yJ2.ToString() + xJ1.ToString() + yJ1.ToString());
            List<UniteDeBase> uniteJ1 = MaPartie.joueur1.getUnite();
            List<UniteDeBase> uniteJ2 = MaPartie.joueur2.getUnite();
           
            //creationGraphiqueUnite(uniteJ1, xJ1, yJ1);
            // 1 corresponds au numéro du joueur.
            // CreateEllipse = OK. 
            //var _element = createEllipse(xJ2, yJ2, 1);
            //mapGrid.Children.Add(_element);
            creationGraphiqueUnite(uniteJ1, MaPartie.joueur1.getx0(), MaPartie.joueur1.gety0(), 0);
            creationGraphiqueUnite(uniteJ2, MaPartie.joueur2.getx0(), MaPartie.joueur2.gety0(), 1);

            //Initialisation du panel affichant les informations sur la partie en cours.
            infoGen1.Items.Add("Nombre de tour restant");
            infoGen1.Items.Add("Nombre d'unité restante du Joueur 1");
            infoGen1.Items.Add("Nombre d'unité restante du Joueur 2");

            // Initialise la liste des données de la Partie (à utiliser lors de l'appui du bouton Fin de tour).
            changeDataPartie();

            // Initialisation des informations sur les unités
            infoGen2.Items.Add("Aucune");
        }

        /// <summary>
        /// Création graphique de l'unite
        /// </summary>
        /// <param name="li"> Liste des unites </param>
        /// <param name="x"> Column </param>
        /// <param name="y"> Row </param>
        /// <param name="numJoueur"> Permet d'identifier le joueur (0 pour J1 et 1 pour J2)</param>
        /// <returns> Rectangle créé</returns>
        private void creationGraphiqueUnite(List<UniteDeBase> li, int x, int y, int numJoueur)
        {
            int i = 0;
            int j = 0;
            if (1 == numJoueur)
                j += strategie.nombreUniteParPeuple();

            foreach (Unite u in li)
            {
               
                int k = i + j;
                // ajout des attributs (column et Row) référencant la position dans la grille à unitEllipse et le tag i+j permettant d'identifier l'ellipse à une unite.
                var element = createEllipse(x, y, k);
                mapGrid.Children.Add(element);// c'est cette fonction qui permet l'affichage de l'ellipse
                u.setRow(x);
                u.setColumn(y);
                u.setIndexEllipse(k);
                i++;
            }
            //for (i = 0; i < strategie.nombreUniteParPeuple(); i++)
        }

        /// <summary>
        /// Création de l'ellipse matérialisant une unité
        /// </summary>
        /// <param name="c"> Column </param>
        /// <param name="l"> Row </param>
        /// <param name="num"> Index de l'ellipse</param>
        /// <returns> Ellipse créée</returns>
        private Ellipse createEllipse(int c, int l, int i)
        {
            var ellipse = new Ellipse();
            Grid.SetColumn(ellipse, c);
            Grid.SetRow(ellipse, l);
            ellipse.Tag = i;
            if (i > strategie.nombreUniteParPeuple())
            {
                ellipse.Fill = Brushes.Red;
            }
            else
            {
                ellipse.Fill = Brushes.White;
            }
            ellipse.Height = 10;
            ellipse.Width = 10;
            return ellipse;
        }
        /// <summary>
        /// Récupération de la position de l'unité (logique), mise à jour de l'ellipse (physique) matérialisant l'unité
        /// </summary>
        private void updateUnitUI()
        {
            //var unit = engine.GetUnit();
            // ajout des attributs (column et Row) référencant la position dans la grille à unitEllipse

            //Grid.SetColumn(unitEllipse, unit.Column);
            //Grid.SetRow(unitEllipse, unit.Row);
        }


        /// <summary>
        /// Création du rectangle matérialisant une case
        /// </summary>
        /// <param name="c"> Column </param>
        /// <param name="l"> Row </param>
        /// <param name="num"> Nom de la case</param>
        /// <returns> Rectangle créé</returns>
        private Rectangle createRectangle(int c, int l, int num)
        {
            var rectangle = new Rectangle();
            switch (num)
            {
                case (int) Case.TypeCase.MONTAGNE:
                    BitmapSource montagne = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(ApplicationSW.Properties.Resources.montagne.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                    rectangle.Fill = new ImageBrush(montagne);
                    //rectangle.Fill = Brushes.Brown;
                    break;
                case (int) Case.TypeCase.PLAINE:
                    BitmapSource plaine = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(ApplicationSW.Properties.Resources.plaine.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                    rectangle.Fill = new ImageBrush(plaine);
                    //rectangle.Fill = Brushes.Silver;
                    break;
                case (int) Case.TypeCase.DESERT:
                    BitmapSource desert = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(ApplicationSW.Properties.Resources.desert.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                    rectangle.Fill = new ImageBrush(desert);
                    //rectangle.Fill = Brushes.Yellow;
                    break;
                case (int) Case.TypeCase.EAU:
                    BitmapSource neige = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(ApplicationSW.Properties.Resources.neige.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                    rectangle.Fill = new ImageBrush(neige);
                    //rectangle.Fill = Brushes.SlateBlue;
                    break;
                case (int) Case.TypeCase.FORET:
                    BitmapSource foret = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(ApplicationSW.Properties.Resources.foret.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                    rectangle.Fill = new ImageBrush(foret);
                    //rectangle.Fill = Brushes.DarkGreen;
                    break;
                default:
                    rectangle.Fill = Brushes.White;
                    break;

            }
            // mise à jour des attributs (column et Row) référencant la position dans la grille à rectangle
            Grid.SetColumn(rectangle, c);
            Grid.SetRow(rectangle, l);
            rectangle.Tag = num; // Tag : ref par defaut sur la tuile logique

            rectangle.Stroke = Brushes.Red;
            rectangle.StrokeThickness = 1;
            // enregistrement d'un écouteur d'evt sur le rectangle :
            // source = rectangle / evt = MouseLeftButtonDown / délégué = rectangle_MouseLeftButtonDown
            rectangle.MouseLeftButtonDown += new MouseButtonEventHandler(rectangle_MouseLeftButtonDown);
            return rectangle;
        }

        /// <summary>
        /// Délégué : réponse à l'evt click gauche sur le rectangle, affichage des informations de la tuile
        /// </summary>
        /// <param name="sender"> le rectangle (la source) </param>
        /// <param name="e"> l'evt </param>
        unsafe void rectangle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            int x1=0, y1=0, x2=0, y2=0;
            var rectangle = sender as Rectangle;
            var tile = rectangle.Tag as ITile;

            int column = Grid.GetColumn(rectangle);
            int row = Grid.GetRow(rectangle);
           Case.etatCase etat = MaPartie.getCarte().getCase(column, row).getEtatOccupation(); 
            // affichage des caractéristique de l'unité au top de la pile.
           if (!(etat == 0))
           {
               setGen();
               List<UniteDeBase> listUnite = MaPartie.getCarte().getCase(column, row).getUnitsOnCase();
               changeListeViewUnite(listUnite[0]);
           }
           else
           {
               initListUnite();
           }
            // la var etat est soit libre soit joueur1 soit joueur2
           SelectionOperateur.etatSelection etatSelection = MaPartie.getSelectionOperateur().getEtatSelection(); 
            // la var etatSelection est soit RienEstSelectionne soit UniteDeDepartDelectionnee soit UniteDarriveeSelectionnee 
            //(normalement l'utilisateur n'aura pas le temps de cliquer sur quoi que ce soit lors de la transition de l'etat UniteDarriveeSelectionnee vers RienEstSelectionne)
           switch (etat)
            {
                case Case.etatCase.libre: if (etatSelection != SelectionOperateur.etatSelection.UniteDeDepartDelectionnee)
                    {
                        MessageBox.Show("Attention, vous avez sélectionné une case vide !"); 
                    // se produit surtout quand on est dans l'etat RienEstSelectionne et que l'on essaie de jouer une case qui est vide...
                        MaPartie.getSelectionOperateur().FinDeSelection();
                    }
                    else //ici on est sur d'être dans l'etat UniteDeDepartDelectionnee
                    {
                        MessageBox.Show("Vous déplacez votre unité vers une case vide.");
                        MaPartie.getSelectionOperateur().selectCase(column, row); // donc ici on passe dans l'etat UniteDarriveeSelectionnee
                        Boolean isSecondSelection1 = MaPartie.getSelectionOperateur().getSelectedCases(&x1, &y1, &x2, &y2); //donc il n'y a pas besoin de vérifier isSecondSelection1 cependant il faut conserver l'opération getSelectedCase
                        if (isSecondSelection1) // à supprimer
                        { // à supprimer
                            Case casedep = MaPartie.getCarte().getCase(x1, y1);
                            Case casearr = MaPartie.getCarte().getCase(x2, y2);
                            Peuple p;
                            Joueur j;
                            if (MaPartie.getJoueur1ALaMain())
                            {
                                p = MaPartie.joueur1.getPeuple();
                                j = MaPartie.joueur1;
                            }
                            else
                            {
                                p = MaPartie.joueur2.getPeuple();
                                j = MaPartie.joueur2;
                            }
                            MaPartie.getCarte().moveProcessing(x1, y1, x2, y2, casedep, casearr, p.nomPeuple, j);

                        } // à supprimer
                    }
                    break;
                case Case.etatCase.joueur1: if (!MaPartie.getJoueur1ALaMain()) { //le joueur2 a cliqué sur une case du joueur1
                                                if (etatSelection != SelectionOperateur.etatSelection.UniteDeDepartDelectionnee) { 
                                                    MessageBox.Show("Attention vous avez sélectionné une case appartenant au joueur adverse !");
                                                    MaPartie.getSelectionOperateur().FinDeSelection();
                                                } else {
                                                    MessageBox.Show("Vous avez déclenché un combat !"); // à compléter
                                                    MaPartie.getSelectionOperateur().selectCase(column, row);
                                                }
                                            } else {//le joueur1 a cliqué sur une case du joueur1
                                                switch (etatSelection) {
                                                    case SelectionOperateur.etatSelection.RienEstSelectionne:
                                                        MaPartie.getSelectionOperateur().selectCase(column, row);
                                                        break;
                                                    case SelectionOperateur.etatSelection.UniteDeDepartDelectionnee: // dans ce cas il s'agit d'un déplacement d'une des unités du joueur vers une case où il a déjà des unités mais c'est autorisé
                                                        MaPartie.getSelectionOperateur().selectCase(column, row);
                                                        MaPartie.getSelectionOperateur().getSelectedCases(&x1, &y1, &x2, &y2);
                                                        Case casedep = MaPartie.getCarte().getCase(x1, y1);
                                                        Case casearr = MaPartie.getCarte().getCase(x2, y2);
                                                        Peuple p = MaPartie.joueur1.getPeuple();
                                                        MaPartie.getCarte().moveProcessing(x1, y1, x2, y2, casedep, casearr, p.nomPeuple, MaPartie.joueur1);
                                                        break;
                                                    case SelectionOperateur.etatSelection.UniteDarriveeSelectionnee:
                                                        MessageBox.Show("Vous avez déjà sélectionné 2 cases !");
                                                        MaPartie.getSelectionOperateur().FinDeSelection();
                                                        break;
                                                }

                                               /* if (etatSelection != SelectionOperateur.etatSelection.UniteDarriveeSelectionnee) {
                                                    MaPartie.getSelectionOperateur().selectCase(column, row);
                                                }else{
                                                    MessageBox.Show("Vous avez déjà sélectionné 2 cases !"); //Ne devrait pas trop arriver
                                                    MaPartie.getSelectionOperateur().FinDeSelection();
                                                }*/
                                        }
                    break;

                case Case.etatCase.joueur2: if (MaPartie.getJoueur1ALaMain())
                    { //le joueur1 a cliqué sur une case du joueur2
                        if (etatSelection != SelectionOperateur.etatSelection.UniteDeDepartDelectionnee) { 
                            MessageBox.Show("Attention vous avez sélectionné une case appartenant au joueur adverse !");
                            MaPartie.getSelectionOperateur().FinDeSelection();
                        } else {
                            MessageBox.Show("Vous avez déclenché un combat !");//à compléter
                            MaPartie.getSelectionOperateur().selectCase(column, row);
                        }
                    } else {//le joueur2 a cliqué sur une case du joueur2
                        switch (etatSelection)
                        {
                            case SelectionOperateur.etatSelection.RienEstSelectionne:
                                MaPartie.getSelectionOperateur().selectCase(column, row);
                                break;
                            case SelectionOperateur.etatSelection.UniteDeDepartDelectionnee: // dans ce cas il s'agit d'un déplacement d'une des unités du joueur vers une case où il a déjà des unités mais c'est autorisé
                                MaPartie.getSelectionOperateur().selectCase(column, row);
                                MaPartie.getSelectionOperateur().getSelectedCases(&x1, &y1, &x2, &y2);
                                Case casedep = MaPartie.getCarte().getCase(x1, y1);
                                Case casearr = MaPartie.getCarte().getCase(x2, y2);
                                Peuple p = MaPartie.joueur1.getPeuple();
                                MaPartie.getCarte().moveProcessing(x1, y1, x2, y2, casedep, casearr, p.nomPeuple, MaPartie.joueur2);
                                break;
                            case SelectionOperateur.etatSelection.UniteDarriveeSelectionnee:
                                MessageBox.Show("Vous avez déjà sélectionné 2 cases !");
                                MaPartie.getSelectionOperateur().FinDeSelection();
                                break;
                        }
                        /*if (etatSelection != SelectionOperateur.etatSelection.UniteDarriveeSelectionnee)
                        {
                            MaPartie.getSelectionOperateur().selectCase(column, row);
                        }
                        else
                        {
                            MessageBox.Show("Vous avez déjà sélectionné 2 cases !");
                            MaPartie.getSelectionOperateur().FinDeSelection();
                        }*/
                    }
                    break;
            }
            // V2 : gestion avec Binding
            // Mise à jour du rectangle selectionné => le label sera mis à jour automatiquement par Binding
            Grid.SetColumn(selectionRectangle, column);
            Grid.SetRow(selectionRectangle, row);
            selectionRectangle.Tag = tile;
            selectionRectangle.Visibility = System.Windows.Visibility.Visible;
             // V1 : gestion avec evts classiques
            //if (selectedVisual != null)
            //    selectedVisual.StrokeThickness = 1;
            //selectedVisual = rectangle;
            //selectedVisual.Tag = tile; // Tag : ref par defaut sur la tuile logique
            //rectangle.StrokeThickness = 3;
            //infoLabel.Content = String.Format("[{0:00} - {1:00}] {2} Fer : {3}", column, row, tile, tile.Iron);
            Boolean isSecondSelection = MaPartie.getSelectionOperateur().getSelectedCases(&x1, &y1, &x2, &y2);
            if (isSecondSelection)
            {
                //MessageBox.Show("Bravo vous avez bien sélectionner 2 deux cases: " + x1.ToString() + " " + y1.ToString() + " " + x2.ToString() + " " + y2.ToString());
                MaPartie.getSelectionOperateur().FinDeSelection();

            }

            // on arrête la propagation d'evt : sinon l'evt va jusqu'à la fenetre => affichage via "Window_MouseLeftButtonDown"
            e.Handled = true;
        }

        /// <summary>
        /// Initialisation de l'affichage des chaines de caractères lors de la première selection d'une unité
        /// </summary>
        public void setGen()
        {
            if (infoGen2.Items.GetItemAt(0).Equals("Aucune"))
            {
                infoGen2.Items.Clear();
                infoGen2.Items.Add("Ordonnée");
                infoGen2.Items.Add("Abscisse");
                infoGen2.Items.Add("Point de vie");
                infoGen2.Items.Add("Attaque");
                infoGen2.Items.Add("Défense");
                infoGen2.Items.Refresh();
            }
        }



        /// <summary>
        /// Rafraichissement de l'affichage des données pour une unité des ses caractéristiques
        /// </summary>
        ///  <param name="u"> L'unité choisit par l'utilisateur </param>
        public void changeListeViewUnite(Unite u)
        {
            infoUnite.Items.Clear();
            infoUnite.Items.Add(u.getRow());
            infoUnite.Items.Add(u.getColumn());
            infoUnite.Items.Add(u.getPV());
            infoUnite.Items.Add(u.getAtt());
            infoUnite.Items.Add(u.getDef());
            infoUnite.Items.Refresh();
        }

        /// <summary>
        /// Rafraichissement de l'affichage des données de la partie en cours
        /// </summary>
        public void changeDataPartie()
        {
            infoData.Items.Clear();
            infoData.Items.Add(strategie.nombreDeTour());
            infoData.Items.Add(MaPartie.joueur1.getNbUnite());
            infoData.Items.Add(MaPartie.joueur2.getNbUnite());
            infoData.Items.Refresh();
        }

        public void initListUnite()
        {
            infoUnite.Items.Clear();
            infoUnite.Items.Refresh();
            infoGen2.Items.Clear();
            infoGen2.Items.Add("Aucune");
            infoGen2.Items.Refresh();
        }
        /// <summary>
        /// Délégué : réaction général à un clic sur la fenetre 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /*private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)  //à Aurelien: cette fonction a pas l'âir d'âtre utilisée...
        {
            // V1 : gestion avec evts classiques
            //infoLabel.Content = "Pas d'info";
            //if (selectedVisual != null)
            //    selectedVisual.StrokeThickness = 0;
            //selectedVisual = null;

            // V2 : gestion avec Binding
            // on cache(enlève) le rectangle de selection 
            // la réf sur la tuile est mise à null
            selectionRectangle.Tag = null;
            selectionRectangle.Visibility = System.Windows.Visibility.Collapsed;
        }*/

        /// <summary>
        /// Délégué : réaction à l'evt : clic sur le bouton "prochain tour"
        /// </summary>
        /// <param name="sender"> le bouton "tour suivant" </param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // création d'un thread pour lancer le calcul du tour suivant sans que cela soit bloquant pour l'IHM
            Task.Factory.StartNew(() =>
            {


                // engine.NextTurn(); // calcul du prochain tour
                // appel de méthodes dand un autre thread : le thread principal (de l'IHM) : 
                this.Dispatcher.BeginInvoke(new Action(() =>
                {
                    updateUnitUI();

                    // V1 : gestion avec evts classiques
                    //int column = Grid.GetColumn(selectedVisual);
                    //int row = Grid.GetRow(selectedVisual);
                    //var tile = selectedVisual.Tag as ITile;
                    //int iron = tile.Iron;
                    //infoLabel.Content = String.Format("[{0:00} - {1:00}] {2} Fer : {3}", column, row, tile, iron);            

                    // V2 : gestion avec Binding
                    // On "touche" au rectangle de selection pour provoquer un rafraichissemnt via le Binding
                    var selected = selectionRectangle.Tag;
                    selectionRectangle.Tag = null;
                    selectionRectangle.Tag = selected;
                }));
            });

        }

    }
}
