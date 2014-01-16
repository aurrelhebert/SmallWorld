using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wrapper;

namespace SmallWorld
{
    public class Carte
    {
        public List<Case> ListeDesCases;
        public int longueurCote;

        public Carte()
        {
        }

        /// <summary>
        /// Création d'une carte, les cases de la carte sont initialisées en fonction de la carte que le wrapperalgo a déjà généré
        /// </summary>
        /// <param name="taille"> la taille de la carte </param>
        unsafe public Carte(int taille)
        {
            ListeDesCases = new List<Case>();
            WrapperAlgo wa = new WrapperAlgo(taille);
            int** tabCarte = wa.remplirCarte();
            longueurCote = taille;
            int i, j;
            for (i = 0; i < taille; i++)
            {
                for (j = 0; j < taille; j++)
                {
                    int type = tabCarte[i][j];
                    Case c;

                    switch (type)
                    {

                        case 0:
                            c = new Montagne();
                            break;
                        case 1:
                            c = new Plaine();
                            break;
                        case 2:
                            c = new Desert();
                            break;
                        case 3:
                            c = new Eau();
                            break;
                        default:
                            c = new Foret();
                            break;
                    }
                    ListeDesCases.Add(c);
                }
            }
        }

        /// <summary>
        /// Initialisation de la carte: remplir les cases de la carte d'unités(celle de chaque joueur) et mettre l'état de ces cases à occupé
        /// </summary>
        /// <param name="joueur1"> le joueur1 </param>
        /// <param name="joueur2"> le joueur2 </param>
        /// <param name="nbUnits"> le nombre d'unité pour chaque joueur d'apres la startegie</param>
        public void InitialisationDeLaCarte(Joueur joueur1, Joueur joueur2, int nbUnits)
        {
            initCase(joueur1, nbUnits, 1);
            initCase(joueur2, nbUnits, 2);
        }

        /// <summary>
        /// getter pour l'attribut ListDesCases
        /// </summary>
        /// <returns> la ListDesCases</returns>
        public List<Case> getListeDesCases()
        {
            return ListeDesCases;
        }

        /// <summary>
        /// Fonction qui permet de rendre la case de la carte de coordonnées (column,row)
        /// </summary>
        /// <param name="column"> la Colonne </param>
        /// <param name="row">  le rang </param>
        /// <returns> la case voulue</returns>
        public Case getCase(int column, int row)
        {
            if (column < 0) column = 0;
            if (column >= longueurCote) column = longueurCote - 1;
            if (row < 0) row = 0;
            if (row >= longueurCote) row = longueurCote - 1;
            return ListeDesCases[(longueurCote * row) + column];
        }

        /// <summary>
        /// Initialisation de la case de départ où se situe le joueur avec les unités que possède déjà le joueur, cela permet de faire correspondre les unités de chaque joueur avec les unités de la carte.
        /// </summary>
        /// <param name="joueur"> le joueur </param>
        /// <param name="nbUnits"> le nombre d'unité d'apres la strategie </param>
        /// <param name="numJoueur"> le numéro du joueur</param>
        public void initCase(Joueur joueur, int nbUnits, int numJoueur)
        {
            int column = joueur.getx0();
            int row = joueur.gety0();
            if (column < 0) column = 0;
            if (column >= longueurCote) column = longueurCote - 1;
            if (row < 0) row = 0;
            if (row >= longueurCote) row = longueurCote - 1;
            ListeDesCases[(longueurCote * row) + column].setEtatOccupation(numJoueur);
            ListeDesCases[(longueurCote * row) + column].initUnitsOnCase(joueur.getUnite());
        }

        /// <summary>
        /// Fonction qui permet de rendre le type de la case de la carte de coordonnées (x,y)
        /// </summary>
        /// <param name="x"> la Colonne </param>
        /// <param name="y">  le rang </param>
        /// <returns> le type de la case</returns>
        public Case.TypeCase getTypeCase(int x, int y)
        {
            Case c = getCase(x, y);
            return c.getType();
        }

        /// <summary>
        /// getter pour l'attribut longueurCote
        /// </summary>
        /// <returns> la longueur d'un coté de la carte (5,10 ou 15)</returns>
        public int getLongueurCote()
        {
            return longueurCote;
        }

        /// <summary>
        /// Fonction qui permet de savoir si un déplacement est potentiellement faisable, sans tenir compte des points de déplacement de l'unité qui veut se déplacer. 
        /// </summary>
        /// <param name="xdep"> la Colonne correspondant à la case de départ </param>
        /// <param name="ydep">  le rang correspondant à la case de départ </param>
        /// <param name="xarr"> la Colonne correspondant à la case d'arrivée </param>
        /// <param name="yarr">  le rang correspondant à la case de d'arrivée </param>
        /// <param name="casedep">  la case de départ </param>
        /// <param name="casearr"> la case d'arrivée </param>
        /// <param name="nompeuple">  le nom du peuple de joueur qui tente de déplacer une unité </param>
        /// <returns> Rend vrai si le déplacement est acceptale. Faux sinon.</returns>
        private Boolean isMoveAllowed(int xdep, int ydep, int xarr, int yarr, Case casedep, Case casearr, Peuple.NomPeuple nompeuple)
        {
            switch (nompeuple)
            {
                case Peuple.NomPeuple.GAULOIS:
                    if (!WrapperAlgo.isAdjacentCase(xdep, ydep, xarr, yarr)) return false;
                    if (casearr.getType() == Case.TypeCase.EAU) return false;
                    break;

                case Peuple.NomPeuple.NAINS:
                    if ((!WrapperAlgo.isAdjacentCase(xdep, ydep, xarr, yarr)) && casearr.getType() != Case.TypeCase.MONTAGNE) return false;
                    if ((!WrapperAlgo.isAdjacentCase(xdep, ydep, xarr, yarr)) && (casearr.getType() == Case.TypeCase.MONTAGNE) && (casedep.getType() != Case.TypeCase.MONTAGNE)) return false;
                    if (casearr.getType() == Case.TypeCase.EAU) return false;
                    break;

                default:
                    if (!WrapperAlgo.isAdjacentCase(xdep, ydep, xarr, yarr)) return false;
                    break;
            }
            return true;
        }

        /// <summary>
        /// Fonction qui permet de connaitre la liste des cases sur lesquelles il peut potentiellement y avoir un déplacement
        /// </summary>
        /// <param name="xdep"> la Colonne correspondant à la case de départ </param>
        /// <param name="ydep">  le rang correspondant à la case de départ </param>
        /// <param name="casedep">  la case de départ </param>
        /// <param name="nompeuple">  le nom du peuple de joueur qui pourrait déplacer une unité </param>
        /// <returns> La liste des cases qui peut être jouées.</returns>
        public List<int> listeDesCasesPossibles(int xdep, int ydep, Case casedep, Peuple.NomPeuple nompeuple)
        {
            List<int> res = new List<int>();
            int row, column;
            for (row = 0; row < longueurCote; row++)
            {
                for (column = 0; column < longueurCote; column++)
                {

                    if (isMoveAllowed(xdep, ydep, column, row, casedep, getCase(column, row), nompeuple))
                    {
                        res.Add(column);
                        res.Add(row);
                    }
                }
            }
            return res;
        }

        /// <summary>
        /// Fonction qui permet de connaitre le cout d'un déplacement.
        /// </summary>
        /// <param name="casearr"> la case d'arrivée </param>
        /// <param name="nompeuple">  le nom du peuple du joueur qui pourrait effectuer un déplacement </param>
        /// <returns> Le cout</returns>
        private float getMoveCost(Case casearr, Peuple.NomPeuple nompeuple)
        {
            switch (nompeuple)
            {
                case Peuple.NomPeuple.GAULOIS:
                    if (casearr.getType() == Case.TypeCase.PLAINE) return 0.5f;
                    break;
                default: break;
            }
            return 1.0f;
        }

        /// <summary>
        /// Fonction qui permet de savoir si une case est au bord de l'eau. les cases au milieu de l'eau sont considérées au bord de l'eau également
        /// </summary>
        /// <param name="column"> la colonne de la case </param>
        /// <param name="row">  lrang de la case </param>
        /// <returns> Rend vrai si la case est au bord de l'eau, faux sinon.</returns>
        private Boolean estAuBordDeLeau(int column, int row)
        {
            if (column > 0) { if (getTypeCase(column - 1, row) == Case.TypeCase.EAU) return true; }
            if (column < longueurCote - 1) { if (getTypeCase(column + 1, row) == Case.TypeCase.EAU) return true; }
            if (row > 0) { if (getTypeCase(column, row - 1) == Case.TypeCase.EAU) return true; }
            if (row < longueurCote - 1) { if (getTypeCase(column, row + 1) == Case.TypeCase.EAU) return true; }
            return false;
        }

        /// <summary>
        /// Fonction qui permet de savoir combien de point rapporte l'occupation d'une case.
        /// </summary>
        /// <param name="casearr"> la case occupée </param>
        /// <param name="nompeuple">  le nom du peuple du joueur qui occupe la case </param>
        /// <returns> la valeur des points d'occupation</returns>
        public int getPointOccupation(Case casearr, Peuple.NomPeuple nompeuple)
        {
            switch (nompeuple)
            {
                case Peuple.NomPeuple.GAULOIS:
                    if (casearr.getType() == Case.TypeCase.PLAINE) return 2 * casearr.getNbUnitsOnCase();
                    if (casearr.getType() == Case.TypeCase.MONTAGNE) return 0;
                    break;
                case Peuple.NomPeuple.NAINS:
                    if (casearr.getType() == Case.TypeCase.FORET) return 2 * casearr.getNbUnitsOnCase();
                    if (casearr.getType() == Case.TypeCase.PLAINE) return 0;
                    break;
                default:
                    if (casearr.getType() == Case.TypeCase.DESERT) return 0;
                    if (casearr.getType() == Case.TypeCase.EAU) return 0;
                    int total = 0;
                    foreach (UniteDeBase u in casearr.getUnitsOnCase())
                    {
                        if (estAuBordDeLeau(u.getColumn(), u.getRow()))
                        {
                            total += 2;
                        }
                        else
                        {
                            total += 1;
                        }
                    }
                    return total;
            }
            return casearr.getNbUnitsOnCase();
        }

        /// <summary>
        /// Fonction qui effectue le déplacement d'une unité (si celle ci le peut).
        /// </summary>
        /// <param name="xdep"> la colonne de la case de départ </param>
        /// <param name="ydep"> le rang de la case de départ </param>
        /// <param name="xarr"> la colonne de la case de d'arrivée </param>
        /// <param name="yarr"> le rang de la case d'arrivée </param>
        /// <param name="casedep"> la case de départ </param>
        /// <param name="casearr"> la case d'arrivée </param>
        /// <param name="nompeuple">  le nom du peuple du joueur qui veut faire un déplacement </param>
        /// <param name="j">  le joueur qui veut faire un déplacement </param>
        /// <param name="numJoueur">  le numéro du joueur qui veut faire un déplacement </param>
        /// <returns> Vrai si le déplacement a été effectué, Faux si le déplacement ne pouvait pas avoir lieu</returns>
        public Boolean moveProcessing(int xdep, int ydep, int xarr, int yarr, Case casedep, Case casearr, Peuple.NomPeuple nompeuple, Joueur j, int numJoueur)
        {
            UniteDeBase u = casedep.UnitsOnCase[0];
            if (!isMoveAllowed(xdep, ydep, xarr, yarr, casedep, casearr, nompeuple)) return false;
            float cost = getMoveCost(casearr, nompeuple);
            if (u.ptDeDepl < cost) return false;
            casedep.UnitsOnCase.Remove(u);
            if (casedep.UnitsOnCase.Count == 0)
            {
                casedep.setEtatOccupation(0); // 0 etant l'etat libre
            }
            UniteDeBase umodifie = u;
            umodifie.ptDeDepl -= cost;
            umodifie.setRow(yarr);
            umodifie.setColumn(xarr);
            casearr.UnitsOnCase.Add(umodifie);
            casearr.setEtatOccupation(numJoueur);
            return true;
        }

        /// <summary>
        /// Fonction qui permet de savoir si un combat peut avoir lieu entre des unités de la case d'arrivée(defenseur) et des unités de la case de départ(attaquant). Elle ne tient pas compte du fait qu'u
        /// </summary>
        /// <param name="xdep"> la Colonne correspondant à la case de départ </param>
        /// <param name="ydep">  le rang correspondant à la case de départ </param>
        /// <param name="xarr"> la Colonne correspondant à la case d'arrivée </param>
        /// <param name="yarr">  le rang correspondant à la case de d'arrivée </param>
        /// <param name="casedep">  la case de départ </param>
        /// <param name="casearr"> la case d'arrivée </param>
        /// <param name="nompeuple">  le nom du peuple de joueur qui tente de provoquer un combat </param>
        /// <returns> Rend vrai si le combat est acceptale. Faux sinon.</returns>
        private Boolean isFightAllowed(int xdep, int ydep, int xarr, int yarr, Case Casedep, Case casearr, Peuple.NomPeuple nompeuple)
        {
            switch (nompeuple)
            {
                case Peuple.NomPeuple.VIKINGS:
                    if (!WrapperAlgo.isAdjacentCase(xdep, ydep, xarr, yarr)) return false;
                    break;

                default: // nains et gaulois
                    if (!WrapperAlgo.isAdjacentCase(xdep, ydep, xarr, yarr)) return false;
                    if (casearr.getType() == Case.TypeCase.EAU) return false;
                    break;
            }
            return true;
        }

        /// <summary>
        /// Fonction qui effectue le combat (si celui ci peut avoir lieu).
        /// </summary>
        /// <param name="xdep"> la colonne de la case de l'attaquant </param>
        /// <param name="ydep"> le rang de la case de l'attaquant </param>
        /// <param name="xarr"> la colonne de la case du défenseur </param>
        /// <param name="yarr"> le rang de la case du défenseur </param>
        /// <param name="casedep"> la case de l'attaquant </param>
        /// <param name="casearr"> la case du défenseur </param>
        /// <param name="nompeuple">  le nom du peuple du joueur qui attaque</param>
        /// <param name="j">  le joueur qui veut faire un combat </param>
        /// <param name="numJoueur">  le numéro du joueur qui veut faire un combat </param>
        /// <returns> Vrai si le combat a été effectué, Faux si le combat ne pouvait pas avoir lieu</returns>
        public Boolean fightProcessing(int xdep, int ydep, int xarr, int yarr, Case casedep, Case casearr, Peuple.NomPeuple nompeuple, Joueur joueuratt, Joueur joueurdef)
        {
            if (!isFightAllowed(xdep, ydep, xarr, yarr, casedep, casearr, nompeuple)) return false;
            UniteDeBase uattaquante = casedep.UnitsOnCase[0];
            UniteDeBase udefensive = casearr.getLUniteDePlusGrandeDefense();
            float cost = getMoveCost(casearr, nompeuple);
            if (uattaquante.ptDeDepl < cost) return false;
            int nbCombat = WrapperAlgo.nbCombat(uattaquante.getPV(), udefensive.getPV());
            while (nbCombat > 0 && (uattaquante.getPV() != 0) && (udefensive.getPV() != 0))
            {
                Boolean LattaquantAPerduUnPV = WrapperAlgo.LattaquantPerdUnPV(uattaquante.getAtt(), udefensive.getDef(), uattaquante.getPourcentagePV(), udefensive.getPourcentagePV());
                if (LattaquantAPerduUnPV)
                {
                    int PVinit = (uattaquante.getPV() * 100) / uattaquante.getPourcentagePV();
                    uattaquante.setPourcentagePV(((uattaquante.getPV() - 1) * 100) / PVinit);
                    uattaquante.setPV(uattaquante.getPV() - 1);
                }
                else
                {
                    int PVinit = (udefensive.getPV() * 100) / udefensive.getPourcentagePV();
                    udefensive.setPourcentagePV(((udefensive.getPV() - 1) * 100) / PVinit);
                    udefensive.setPV(udefensive.getPV() - 1);
                }
                nbCombat--;
            }
            if (udefensive.getPV() == 0)
            {
                udefensive.meurt();
                casearr.UnitsOnCase.Remove(udefensive);
                joueurdef.getUnite().Remove(udefensive);
                if (casearr.UnitsOnCase.Count == 0)
                {
                    casearr.setEtatOccupation(0);// la case devient libre
                    return true;
                }
            }
            if (uattaquante.getPV() == 0)
            {
                uattaquante.meurt();
                casedep.UnitsOnCase.Remove(uattaquante);
                joueuratt.getUnite().Remove(uattaquante);
                if (casedep.UnitsOnCase.Count == 0)
                {
                    casedep.setEtatOccupation(0);// la case devient libre
                }
                return false;
            }
            return false;
        }


    }
}
