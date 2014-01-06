using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wrapper;

namespace SmallWorld
{
    [Serializable]
    public class Partie
    {
       /* public int pvMaxUnite;
        public StrategieCarte strat;
        private Carte LaCarte;
        public Joueur joueur1;
        public Joueur joueur2;
        private SelectionOperateur selectOp;
        private Boolean Joueur1ALaMain;
        private int nbToursRestants;*/
        public int pvMaxUnite;
        public StrategieCarte strat;
        public Carte LaCarte;
        public Joueur joueur1;
        public Joueur joueur2;
        public Boolean Joueur1ALaMain;
        public SelectionOperateur selectOp;
        public int nbToursRestants;

        public Partie()
        {
        }

        unsafe public Partie(Joueur j1, Joueur j2, StrategieCarte st)
        {
            pvMaxUnite = 2;
            joueur1 = j1;
            joueur2 = j2;
            LaCarte = new Carte(st.tailleCarte());
            strat = st;
            nbToursRestants = strat.nombreDeTour();
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
            if (Joueur1ALaMain) {
                foreach (UniteDeBase u in joueur1.getUnite()) {
                    u.setPtDeDepl(1);
                }
            }
            else {
                foreach (UniteDeBase u in joueur2.getUnite()) {
                    u.setPtDeDepl(1);
                }
            }

        }

        void gestionUnites(List<Unite> unite) { ;}

        void executionTour() { ;}

        void deroulementDeLaPartie() { ;}

        void miseAJourDesPoints() { ;}

        /*public int combat(Unite unitAtt, Unite target)
        {
            int pvUatt = unitAtt.getPV();
            int pvTarget = target.getPV();
            int att = unitAtt.getAtt()*(pvUatt)/pvMaxUnite;
            int def = target.getDef()*(pvTarget)/pvMaxUnite;
            int maximum = Math.Max(pvTarget, pvUatt);
            Random r = new Random();
            int nBCombat = r.Next(3,maximum+2);
            Boolean finCombat = false;
            int arret =0;

            for (int i=0;i<nBCombat || !finCombat; i++)
            {

                double tmp = Math.Round((double)unitAtt.getAtt() * (double)(pvUatt) / pvMaxUnite + 0.001, 0);
                att = (int)tmp;
                tmp = Math.Round((double)target.getDef() * (double)(pvTarget) / pvMaxUnite + 0.001, 0);
                def = (int)tmp;
                if (haveAttaquePerduUneVie(att, def))
                {
                    pvUatt--;
                    if (0 == pvUatt)
                    {
                        unitAtt.meurt();
                        finCombat = true;
                        arret++;
                    }
                    unitAtt.setPV(pvUatt);
                }
                else
                {

                    pvTarget--;

                    if(0==pvTarget)
                    {
                        target.meurt();
                        unitAtt.majPosition(target.getRow(), target.getColumn());
                        finCombat = true;
                        arret++;
                    }
                    target.setPV(pvTarget);
                }
            }
            return arret;
        }*/


        //oups, dsl j'avais pas vu ta fonction, mais de toute façon dans le poly ils disent que ces calculs doivent être fait en c++
        /*public Boolean haveAttaquePerduUneVie(int att, int def)
        {
            Boolean resultat = false;
            double i;
            double chance;

            if (att > def) {
                double tmp = (double) def / att;
                i = 0.5 * (1 - tmp) * 100;
                chance = 50 - i;
            }
            else {
                double tmp = (double)att / def;
                i = 0.5 * (1 - tmp) * 100;
                chance = i + 50;
            }

            Random rand = new Random();
            int res = rand.Next(0, 100);

            if (res < chance)
                    resultat = true;

            return resultat;
        }*/

        public Boolean nextRound() {
            if (joueur1.getUnite().Count == 0 || joueur2.getUnite().Count == 0) return true;
            changementDeMain();
            if (Joueur1ALaMain){
                nbToursRestants--;                
            }
            return (nbToursRestants == 0);
        }

        public int getNbToursRestants()
        {
            return nbToursRestants;
        }


        public String evaluerFinDePartie() {
            String resultat;
            if (joueur1.getUnite().Count == 0 && joueur2.getUnite().Count != 0) {
                resultat = "La partie est finie car le joueur1 n'a plus d'unités";
                return resultat;
            }
            if (joueur2.getUnite().Count == 0 && joueur1.getUnite().Count != 0) {
                resultat = "La partie est finie car le joueur2 n'a plus d'unités";
                return resultat;
            }
            resultat="La partie est finie car tous les tours de jeu ont été joués !\n";
            int totaljoueur1=0;
            int totaljoueur2=0;
            foreach (Case c in LaCarte.getListeDesCases())
            {
                switch(c.getEtatOccupation()){
                    case Case.etatCase.joueur1:
                        totaljoueur1+= LaCarte.getPointOccupation(c, joueur1.getPeuple().nomPeuple);
                        break;

                    case Case.etatCase.joueur2:
                        totaljoueur2 += LaCarte.getPointOccupation(c, joueur2.getPeuple().nomPeuple);
                        break;
                }
            }
            if (totaljoueur1 == totaljoueur2)
            {
                resultat += "Le resultat est ex-aequo d'un score de " + totaljoueur2.ToString() + " pour chaque joueur !";
            }
            if (totaljoueur1 > totaljoueur2)
            {
                resultat += "Le joueur1 a gagné au score de " + totaljoueur1.ToString() + " à " + totaljoueur2.ToString();
            }
            if (totaljoueur2 > totaljoueur1)
            {
                resultat += "Le joueur2 a gagné au score de " + totaljoueur2.ToString() + " à " + totaljoueur1.ToString();
            }

            return resultat;
        }


    }
}
