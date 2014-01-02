using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wrapper;

namespace SmallWorld
{
    public class Partie
    {

        public StrategieCarte strat;
        private Carte LaCarte;
        public Joueur joueur1;
        public Joueur joueur2;
        private SelectionOperateur selectOp;
        private Boolean Joueur1ALaMain;


        unsafe public Partie(Joueur j1, Joueur j2, StrategieCarte st)
        {
            joueur1 = j1;
            joueur2 = j2;
            LaCarte = new Carte(st.tailleCarte());
            strat = st;
            int j1x, j1y, j2x, j2y;
            WrapperAlgo.positionJoueurParTaille(getCarte().getLongueurCote(), &j1x, &j1y, &j2x, &j2y);
            joueur1.setx0(j1x);
            joueur1.sety0(j1y);
            joueur2.setx0(j2x);
            joueur2.sety0(j2y);
            LaCarte.InitialisationDeLaCarte(joueur1, joueur2, strat.nombreUniteParPeuple());
            Joueur1ALaMain = true;
            selectOp = new SelectionOperateur();
        }

        public Carte getCarte() {
            return LaCarte;
        }

        public SelectionOperateur getSelectionOperateur() {
            return selectOp;
        }

        public Boolean getJoueur1ALaMain() {
            return Joueur1ALaMain;
        }

        public void changementDeMain()
        {
            Joueur1ALaMain = !Joueur1ALaMain;
        }

        void gestionUnites(List<Unite> unite) { ;}

        void executionTour() { ;}

        void deroulementDeLaPartie() { ;}

        void miseAJourDesPoints() { ;}
    }
}
