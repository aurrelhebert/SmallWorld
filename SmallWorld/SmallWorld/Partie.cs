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

        public int pvMaxUnite;
        public StrategieCarte strat;
        public Carte LaCarte;
        public Joueur joueur1;
        public Joueur joueur2;
        public Boolean Joueur1ALaMain;
        public SelectionOperateur selectOp;
        public int nbToursRestants;
        public Boolean restoreSauvegarde;

        /// <summary>
        /// Constructeur d'une partie par défaut
        /// </summary>
        public Partie()
        {
            selectOp = new SelectionOperateur();
        }

        /// <summary>
        /// Création d'une carte à 3 parametres, les 2 joueurs qui vont s'affronter et la strategie de la partie qui sera utilisée
        /// </summary>
        /// <param name="j1"> le joueur 1 </param>
        /// <param name="j2"> le joueur 2 </param>
        /// <param name="st"> la strategie de la partie </param>
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

        /// <summary>
        /// getter pour la carte de la partie c'est-à-dire l'attribut LaCarte
        /// </summary>
        /// <returns> la Carte LaCarte</returns>
        public Carte getCarte()
        {
            return LaCarte;
        }

        /// <summary>
        /// getter pour l'attribut selectOp
        /// </summary>
        /// <returns> le SelectionOperateur selectOp</returns>
        public SelectionOperateur getSelectionOperateur()
        {
            return selectOp;
        }

        /// <summary>
        /// getter pour l'attribut Joueur1ALaMain, permet de savoir quel est le joueur qui a la main
        /// </summary>
        /// <returns> Vrai si le joueur 1 a la main et faux sinon</returns>
        public Boolean getJoueur1ALaMain()
        {
            return Joueur1ALaMain;
        }

        /// <summary>
        /// fonction permettant de changer le joueur qui a la main en remettant des points de deplacement à ces unités
        /// </summary>
        public void changementDeMain()
        {
            Joueur1ALaMain = !Joueur1ALaMain;
            if (Joueur1ALaMain)
            {
                foreach (UniteDeBase u in joueur1.getUnite())
                {
                    u.setPtDeDepl(1);
                }
            }
            else
            {
                foreach (UniteDeBase u in joueur2.getUnite())
                {
                    u.setPtDeDepl(1);
                }
            }

        }

        /// <summary>
        /// fonction qui permet de terminer le tour d'un joueur
        /// </summary>
        /// <returns> Vrai si la partie est finie, faux sinon.</returns>
        public Boolean nextRound()
        {
            if (joueur1.getUnite().Count == 0 || joueur2.getUnite().Count == 0) return true;
            changementDeMain();
            if (Joueur1ALaMain)
            {
                nbToursRestants--;
            }
            return (nbToursRestants == 0);
        }

        /// <summary>
        /// getter pour connaitre le nombre de tours restants
        /// </summary>
        /// <returns> le nombre de tour restant, nbToursRestants</returns>
        public int getNbToursRestants()
        {
            return nbToursRestants;
        }

        /// <summary>
        /// fonction qui évalue la fin de la partie: quel est le joueur qui a gagné, la cause de la fin de la partie, le score s'il y a lieu. Elle retourne toutes ses informations dans un String
        /// </summary>
        /// <returns> La chaine de caractere qui contient le nom du joueur gagnant la cause de la fin de la partie et le score</returns>
        public String evaluerFinDePartie()
        {
            String resultat;
            if (joueur1.getUnite().Count == 0 && joueur2.getUnite().Count != 0)
            {
                resultat = "La partie est finie car le joueur1 n'a plus d'unités";
                return resultat;
            }
            if (joueur2.getUnite().Count == 0 && joueur1.getUnite().Count != 0)
            {
                resultat = "La partie est finie car le joueur2 n'a plus d'unités";
                return resultat;
            }
            resultat = "La partie est finie car tous les tours de jeu ont été joués !\n";
            int totaljoueur1 = 0;
            int totaljoueur2 = 0;
            foreach (Case c in LaCarte.getListeDesCases())
            {
                switch (c.getEtatOccupation())
                {
                    case Case.etatCase.joueur1:
                        totaljoueur1 += LaCarte.getPointOccupation(c, joueur1.getPeuple().nomPeuple);
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

        /// <summary>
        /// Fonction qui permet de connaitre les points d'occupatio générés par toutes les unités d'un joueur.
        /// </summary>
        /// <param name="column"> le joueur dont on veut connaitre les points actuels </param>
        /// <returns> le nombre de points d'occupation du joueur</returns>
        public int getPointJoueur(int joueur)
        {
            int totaljoueur = 0;
            foreach (Case c in LaCarte.getListeDesCases())
            {
                switch (c.getEtatOccupation())
                {
                    case Case.etatCase.joueur1:
                        if (joueur == 0)
                        {
                            totaljoueur += LaCarte.getPointOccupation(c, joueur1.getPeuple().nomPeuple);
                        }
                        break;
                    case Case.etatCase.joueur2:
                        if (joueur == 1)
                        {
                            totaljoueur += LaCarte.getPointOccupation(c, joueur2.getPeuple().nomPeuple);
                        }
                        break;
                }
            }
            return totaljoueur;
        }

    }
}
