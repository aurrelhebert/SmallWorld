using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
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
using Wrapper;

namespace JeuSmallWorld
{
    enum TypeCase{MONTAGNE,PLAINE,DESERT,EAU,FORET};
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public void MainWithEvents()
        {
            InitializeComponent();
            //engine = new Cours.Engine.Engine();
        }

        public MainWindow()
        {
            InitializeComponent();
            int n = 0;
            int xJ1, yJ1, xJ2, yJ2;
            xJ1 = 0;
            yJ1 = 0;
            xJ2 = 0;
            yJ2 = 0;
            n = 5;
            int i,j;

            WrapperAlgo wa = new WrapperAlgo(n);

            unsafe
            {
                int** cases;
                cases = wa.remplirCarte();
            
                wa.positionJoueur(xJ1,yJ1,xJ2,yJ2);

                for (i = 0; i < n; i++)
                {
                    for (j = 0; j < n; j++)
                    {
                        switch (cases[i][j])
                        {
                            case (int)TypeCase.MONTAGNE:
                            //    System.Drawing.Point un = new System.Drawing.Point(i, j);
                            //    montagne = JeuSmallWorld.Properties.Resources.montagne;
                            //    BitmapSource objet = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(montagne.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                            //    Graphics.DrawImage(objet, new System.Drawing.Point[10]); // new Rect(0, 0, montagne.Width, montagne.Height)
                                break;
                            case (int)TypeCase.PLAINE:
                                break;
                            case (int)TypeCase.DESERT:
                                break;
                            case (int)TypeCase.EAU:
                                break;
                            case (int)TypeCase.FORET:
                                break;
                            default:
                                break;

                        }
                    }
                }
            }
        }
        protected override void OnRender(DrawingContext dc)
        {
            Bitmap m = JeuSmallWorld.Properties.Resources.montagne;
            BitmapSource objet = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(montagne.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            dc.DrawImage(objet, new Rect(0, 0, objet.Width, objet.Height)); 
        }
        public Bitmap montagne { get; set; }
    }
}
