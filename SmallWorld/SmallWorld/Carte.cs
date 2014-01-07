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

        unsafe public Carte(int taille) {
            ListeDesCases = new List<Case>();
            WrapperAlgo wa=new WrapperAlgo(taille);
            int** tabCarte = wa.remplirCarte();
            longueurCote = taille;
            int i,j;
            for (i = 0; i < taille; i++) {//pour chaque ligne
                for (j = 0; j < taille; j++) {
                    int type =tabCarte[i][j];
                    Case c;

                    switch (type) {
                            
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

        public void InitialisationDeLaCarte(Joueur joueur1, Joueur joueur2, int nbUnits) {
            initCase(joueur1, nbUnits, 1);
            initCase(joueur2, nbUnits, 2);
        }

        public List<Case> getListeDesCases()
        {
            return ListeDesCases;
        }

        public Case getCase(int column, int row) {
            if (column < 0) column = 0;
            if (column >= longueurCote) column = longueurCote - 1;
            if (row < 0) row = 0;
            if (row >= longueurCote) row = longueurCote - 1;
            return ListeDesCases[(longueurCote * row) + column];
        }

        /*public void initCase(Joueur joueur, int nbUnits, int numJoueur)
        {
            int x=joueur.getx0();
            int y=joueur.gety0();
            if (x < 0) x = 0;
            if (x >= longueurCote) x = longueurCote - 1;
            if (y < 0) y = 0;
            if (y >= longueurCote) y = longueurCote - 1;
            Peuple p=joueur.getPeuple();
            ListeDesCases[(longueurCote * x) + y].setEtatOccupation(numJoueur);
            UniteDeBase u;
            switch(p.nomPeuple){
                case(Peuple.NomPeuple.GAULOIS): u=new GuerrierGaulois(); break;
                case(Peuple.NomPeuple.NAINS): u=new GuerrierNains(); break;
                default: u=new GuerrierVikings(); break;
            }
            u.setRow(y);
            u.setColumn(x);
            int i;
            for (i = 0; i < nbUnits; i++) {
                ListeDesCases[(longueurCote * x) + y].setUnitsOnCase(u);
            }            
        }*/

        public void initCase(Joueur joueur, int nbUnits, int numJoueur) {
            int column = joueur.getx0();
            int row = joueur.gety0();
            if (column < 0) column = 0;
            if (column >= longueurCote) column = longueurCote - 1;
            if (row < 0) row = 0;
            if (row >= longueurCote) row = longueurCote - 1;
            ListeDesCases[(longueurCote * row) + column].setEtatOccupation(numJoueur);
            ListeDesCases[(longueurCote * row) + column].initUnitsOnCase(joueur.getUnite());
        }

        public Case.TypeCase getTypeCase(int x, int y) {
            Case c = getCase(x, y);
            return c.getType();
        }

        public int getLongueurCote() {
            return longueurCote;
        }


        private Boolean isMoveAllowed(int xdep, int ydep, int xarr, int yarr, Case casedep, Case casearr, Peuple.NomPeuple nompeuple) {
            switch (nompeuple)
            {
                case Peuple.NomPeuple.GAULOIS:
                    if (!WrapperAlgo.isAdjacentCase(xdep, ydep, xarr, yarr) ) return false;
                    if (casearr.getType() == Case.TypeCase.EAU) return false;
                    break;

                case Peuple.NomPeuple.NAINS:
                    if ((!WrapperAlgo.isAdjacentCase(xdep, ydep, xarr, yarr)) && casearr.getType() != Case.TypeCase.MONTAGNE) return false;
                    if (casearr.getType() == Case.TypeCase.EAU) return false;
                    break;

                default:
                    if (!WrapperAlgo.isAdjacentCase(xdep, ydep, xarr, yarr)) return false;
                    break;
            }
            return true;
        }

        private float getMoveCost(Case casedep, Case casearr, Peuple.NomPeuple nompeuple) {
            switch (nompeuple) {
                case Peuple.NomPeuple.GAULOIS:
                    if(casearr.getType()==Case.TypeCase.PLAINE) return 0.5f;
                    break;
                default: break;
            }
            return 1.0f;
        }

        private Boolean estAuBordDeLeau(int column, int row) {
            if (column > 0) { if (getTypeCase(column - 1, row) == Case.TypeCase.EAU) return true; }
            if (column < longueurCote - 1) { if (getTypeCase(column + 1, row) == Case.TypeCase.EAU) return true; }
            if (row > 0) { if (getTypeCase(column, row -1) == Case.TypeCase.EAU) return true; }
            if (row < longueurCote - 1) { if (getTypeCase(column, row +1) == Case.TypeCase.EAU) return true; }
            return false;
        }


        public int getPointOccupation(Case casearr, Peuple.NomPeuple nompeuple) {
            switch (nompeuple)
            {
                case Peuple.NomPeuple.GAULOIS:
                    if (casearr.getType() == Case.TypeCase.PLAINE) return 2*casearr.getNbUnitsOnCase();
                    if (casearr.getType() == Case.TypeCase.MONTAGNE) return 0;
                    break;
                case Peuple.NomPeuple.NAINS:
                    if (casearr.getType() == Case.TypeCase.FORET) return 2*casearr.getNbUnitsOnCase();
                    if (casearr.getType() == Case.TypeCase.PLAINE) return 0;
                    break;
                default:
                    if (casearr.getType() == Case.TypeCase.DESERT) return 0;
                    if (casearr.getType() == Case.TypeCase.EAU) return 0;
                    int total=0;
                    foreach(UniteDeBase u in casearr.getUnitsOnCase()) {
                        if (estAuBordDeLeau(u.getColumn(), u.getRow())){
                            total+=2;
                        }else{
                            total+=1;
                        }
                    }
                    return total;
            }
            return casearr.getNbUnitsOnCase();
        }


        public Boolean moveProcessing(int xdep, int ydep, int xarr, int yarr, Case casedep, Case casearr, Peuple.NomPeuple nompeuple , Joueur j, int numJoueur) {
            UniteDeBase u = casedep.UnitsOnCase[0];
            if (!isMoveAllowed(xdep, ydep, xarr, yarr, casedep, casearr, nompeuple)) return false;
            float cost = getMoveCost(casedep, casearr, nompeuple);
            if (u.ptDeDepl < cost) return false;
            casedep.UnitsOnCase.Remove(u);
            if (casedep.UnitsOnCase.Count == 0) {
                casedep.setEtatOccupation(0); // 0 etant l'etat libre
            }
            UniteDeBase umodifie = u;
            umodifie.ptDeDepl -= cost;
            umodifie.setRow(yarr);
            umodifie.setColumn(xarr);
            casearr.UnitsOnCase.Add(umodifie);
            casearr.setEtatOccupation(numJoueur);
            //j.changeLeBonElement(u, umodifie);  ici on a pas besoin de supprimer l'element de la liste du joueur
            return true;
        }
                
        private Boolean isFightAllowed(int xdep, int ydep, int xarr, int yarr, Case casearr, Peuple.NomPeuple nompeuple) {
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

        //rend vrai quand l'attaquant a gagne le combat cad s'il a tué l'unite defensive, ET qu'il ne reste plus d'unite sur la case d'arrivee
        public Boolean fightProcessing(int xdep, int ydep, int xarr, int yarr, Case casedep, Case casearr, Peuple.NomPeuple nompeuple, Joueur joueuratt, Joueur joueurdef)
        {
            if (!isFightAllowed(xdep, ydep, xarr, yarr, casearr, nompeuple)) return false;
            UniteDeBase uattaquante = casedep.UnitsOnCase[0];
            UniteDeBase udefensive = casearr.getLUniteDePlusGrandeDefense();
            int nbCombat = WrapperAlgo.nbCombat(uattaquante.getPV(), udefensive.getPV());
            while (nbCombat > 0 && (uattaquante.getPV() != 0) && (udefensive.getPV() != 0)) {
                Boolean LattaquantAPerduUnPV=WrapperAlgo.LattaquantPerdUnPV(uattaquante.getAtt(), udefensive.getDef(), uattaquante.getPourcentagePV(), udefensive.getPourcentagePV());
                if(LattaquantAPerduUnPV){
                    int PVinit=(uattaquante.getPV()*100)/uattaquante.getPourcentagePV();
                    uattaquante.setPourcentagePV(((uattaquante.getPV()-1)*100)/PVinit);
                    uattaquante.setPV(uattaquante.getPV()-1);
                }else{
                    int PVinit=(udefensive.getPV()*100)/udefensive.getPourcentagePV();
                    udefensive.setPourcentagePV(((udefensive.getPV()-1)*100)/PVinit);
                    udefensive.setPV(udefensive.getPV()-1);
                }
                nbCombat--;
            }
            if (udefensive.getPV() == 0) {
                udefensive.meurt();
                casearr.UnitsOnCase.Remove(udefensive);
                joueurdef.getUnite().Remove(udefensive);
                if (casearr.UnitsOnCase.Count == 0) {
                    casearr.setEtatOccupation(0);// la case devient libre
                    return true;
                }
            }
            if (uattaquante.getPV() == 0)
            {
                uattaquante.meurt();
                casedep.UnitsOnCase.Remove(uattaquante);
                joueuratt.getUnite().Remove(uattaquante);
                if (casedep.UnitsOnCase.Count == 0) {
                    casedep.setEtatOccupation(0);// la case devient libre
                }
                return false;
            }
            return false;
        }
    }
}
