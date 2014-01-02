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
        private List<Case> ListeDesCases;
        private int longueurCote;

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

        public Case getCase(int x, int y) {
            if (x < 0) x = 0;
            if (x >= longueurCote) x = longueurCote - 1;
            if (y < 0) y = 0;
            if (y >= longueurCote) y = longueurCote - 1;
            return ListeDesCases[(longueurCote * x) + y];
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
            int x = joueur.getx0();
            int y = joueur.gety0();
            if (x < 0) x = 0;
            if (x >= longueurCote) x = longueurCote - 1;
            if (y < 0) y = 0;
            if (y >= longueurCote) y = longueurCote - 1;
            ListeDesCases[(longueurCote * x) + y].setEtatOccupation(numJoueur);
            ListeDesCases[(longueurCote * x) + y].initUnitsOnCase(joueur.getUnite());

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

        public Boolean moveProcessing(int xdep, int ydep, int xarr, int yarr, Case casedep, Case casearr, Peuple.NomPeuple nompeuple , Joueur j)
        {
            if (!isMoveAllowed(xdep, ydep, xarr, yarr, casedep, casearr, nompeuple)) return false;
            float cost = getMoveCost(casedep, casearr, nompeuple);
            UniteDeBase u = casedep.UnitsOnCase.First();
            casedep.UnitsOnCase.Remove(u);
            UniteDeBase u2 = j.getUnite().First();
            //int index_u= j.getUnit().find(u);
            u.ptDeDepl -= cost;
            u.setRow(yarr);
            u.setColumn(xarr);
            //j.getUnit().setItem(u, index_u);
            casearr.UnitsOnCase.Add(u);
            return true;
        }

    }
}
