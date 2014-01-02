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
using System.Drawing;
using Wrapper;
using SmallWorld;
 
                   
namespace ApplicationSW
{
    /// <summary>
    /// Logique d'interaction pour Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        int taille = 0;
        WrapperAlgo wa;


        unsafe public Window3()
        {
            InitializeComponent();
            taille = 10;
            WrapperAlgo wa = new WrapperAlgo(taille);

            int** tabCarte = wa.remplirCarte();
            int xJ1 = 0;
            int yJ1 = 0;
            int xJ2 = 0;
            int yJ2 = 0;
            wa.positionJoueur(xJ1, yJ1, xJ2, yJ2);
        }

        unsafe private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            int taille = 10;

            int** TCarte = wa.remplirCarte();

            for (int c = 0; c < taille; c++)
            {
                Carte.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(20, GridUnitType.Pixel) });
            }

            for (int l = 0; l < taille; l++)
            {

                Carte.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(20, GridUnitType.Pixel) });
            }

           
        }

        protected override void OnRender(DrawingContext dc)
        {
            Bitmap m = ApplicationSW.Properties.Resources.montagne;
            BitmapSource objet = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(montagne.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            dc.DrawImage(objet, new Rect(0, 0, objet.Width, objet.Height));
        }
        public Bitmap montagne { get; set; }


    }
}
