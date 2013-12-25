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
        int taille = 0;
        WrapperAlgo wa;
        enum TypeCase { MONTAGNE = 0, PLAINE, DESERT, EAU, FORET };
        StrategieCarte strategie;
        Joueur _j1, _j2;

        /// <summary>
        /// Construction de la fenetre (référencé dans le App.xaml)
        /// </summary>
        unsafe public Window2(StrategieCarte st, Joueur j1, Joueur j2)
        {
            InitializeComponent();
            //engine = new Cours.Engine.Engine();
            strategie = st;
            strategie.tailleCarte();
            taille = strategie.tailleCarte();
            wa = new WrapperAlgo(taille);
            _j1 = j1;
            _j2 = j2;

        }


        /// <summary>
        /// Réaction à l'evt "la fenetre est construite" (référencé dans le MainWithEvents.xaml)
        /// </summary>
        /// <param name="sender">la fenetre </param>
        /// <param name="e"> l'evt : la fentere est construite</param>
        unsafe private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // on initialise la Grid (mapGrid défini dans le xaml) à partir de la map du modèle (engine)
            int** tabCarte = wa.remplirCarte();
            for (int c = 0; c < taille; c++)
            {
                mapGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(60, GridUnitType.Pixel) });
            }
            for (int l = 0; l < taille; l++)
            {
                mapGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(40, GridUnitType.Pixel) });
                for (int c = 0; c < taille; c++)
                {
                    // dans chaque case de la grille on ajoute une tuile (logique) matérialisée par un rectangle (physique)
                    // le rectangle possède une référence sur sa tuile
                    var num = tabCarte[c][l];
                    var element = createRectangle(c, l, num);
                    mapGrid.Children.Add(element);
                }
            }
            int xJ1 = 0;
            int yJ1 = 0;
            int xJ2 = 0;
            int yJ2 = 0;
            wa.positionJoueur(xJ1, yJ1, xJ2, yJ2);
            xJ2 = strategie.tailleCarte() - 1;
            yJ2 = strategie.tailleCarte() - 1;
            //MessageBox.Show(xJ2.ToString() + yJ2.ToString() + xJ1.ToString() + yJ1.ToString());
            List<Unite> uniteJ1 = _j1.getUnite();
            List<Unite> uniteJ2 = _j2.getUnite();

            //creationGraphiqueUnite(uniteJ1, xJ1, yJ1);
            // 1 corresponds au numéro du joueur.
            // CreateEllipse = OK. 
            //var _element = createEllipse(xJ2, yJ2, 1);
            //mapGrid.Children.Add(_element);
            creationGraphiqueUnite(uniteJ1, xJ1, yJ1, 0);
            creationGraphiqueUnite(uniteJ2, xJ2, yJ2, 1);
        }

        private void creationGraphiqueUnite(List<Unite> li, int x, int y, int numJoueur)
        {
            int i;
            for (i = 0; i < strategie.nombreUniteParPeuple(); i++)
            {
                int j = i;
                //li[i].setRaw(x);
                //li[i].setColumn(y);
                // ajout des attributs (column et Row) référencant la position dans la grille à unitEllipse
                if (1 == numJoueur)
                    j += strategie.nombreUniteParPeuple();
                var element = createEllipse(x, y, j);
                mapGrid.Children.Add(element);

            }

        }
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
        /// Création du rectangle matérialisant une tuile
        /// </summary>
        /// <param name="c"> Column </param>
        /// <param name="l"> Row </param>
        /// <param name="tile"> Tuile logique</param>
        /// <returns> Rectangle créé</returns>
        private Rectangle createRectangle(int c, int l, int num)
        {
            var rectangle = new Rectangle();
            switch (num)
            {
                case (int)TypeCase.MONTAGNE:
                    BitmapSource montagne = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(ApplicationSW.Properties.Resources.montagne.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                    rectangle.Fill = new ImageBrush(montagne);
                    //rectangle.Fill = Brushes.Brown;
                    break;
                case (int)TypeCase.PLAINE:
                    BitmapSource plaine = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(ApplicationSW.Properties.Resources.plaine.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                    rectangle.Fill = new ImageBrush(plaine);
                    //rectangle.Fill = Brushes.Silver;
                    break;
                case (int)TypeCase.DESERT:
                    BitmapSource desert = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(ApplicationSW.Properties.Resources.desert.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                    rectangle.Fill = new ImageBrush(desert);
                    //rectangle.Fill = Brushes.Yellow;
                    break;
                case (int)TypeCase.EAU:
                    BitmapSource neige = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(ApplicationSW.Properties.Resources.neige.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                    rectangle.Fill = new ImageBrush(neige);
                    //rectangle.Fill = Brushes.SlateBlue;
                    break;
                case (int)TypeCase.FORET:
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
        void rectangle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var rectangle = sender as Rectangle;
            var tile = rectangle.Tag as ITile;

            int column = Grid.GetColumn(rectangle);
            int row = Grid.GetRow(rectangle);

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

            // on arrête la propagation d'evt : sinon l'evt va jusqu'à la fenetre => affichage via "Window_MouseLeftButtonDown"
            e.Handled = true;
        }

        /// <summary>
        /// Délégué : réaction général à un clic sur la fenetre 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
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
        }

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
