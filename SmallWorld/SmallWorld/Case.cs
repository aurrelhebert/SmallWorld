using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld
{
    public abstract class Case
    {
        public List<UniteDeBase> UnitsOnCase;
        public enum etatCase { libre, joueur1, joueur2 };
        private etatCase etatOccupation;
        public enum TypeCase { MONTAGNE = 0, PLAINE, DESERT, EAU, FORET };
        public TypeCase type;

        public Case(TypeCase t) {
            type = t;
            etatOccupation = etatCase.libre;
            UnitsOnCase = new List<UniteDeBase>();
        }

        public List<UniteDeBase> getUnitsOnCase()
        {
            return UnitsOnCase;
        }

        //void ajoutPtDepl(UniteDeBase u, float deplacement) {//ça devrait être dans unité cette méthode plutôt
        //   u.ptDeDepl+=deplacement;
        //}

        public etatCase getEtatOccupation()
        {
            return etatOccupation;
        }

        public void setEtatOccupation(int numjoueur) {
            switch (numjoueur) {
                case 1: etatOccupation = etatCase.joueur1; break;
                case 2: etatOccupation = etatCase.joueur2; break;
                default: etatOccupation = etatCase.libre; break;
            }

        }

        public void setUnitsOnCase(UniteDeBase u)
        {
            UnitsOnCase.Add(u);
        }

        public void initUnitsOnCase(List<UniteDeBase> l)
        {
            UnitsOnCase.Clear();
            foreach(UniteDeBase u in l) {
                UnitsOnCase.Add(u);
            }
        }


        public void positionUnite() { ;}

        public TypeCase getType() {
            return type;
        }

        public int getNbUnitsOnCase() { // Cette fonction permet de connaître le nombre d'unité sur une case donnée de la carte. (car on les superpose.)
            return UnitsOnCase.Count();        
        }

        public UniteDeBase getLUniteDePlusGrandeDefense(){
            int plusGrandeDef = 0;
            UniteDeBase uniteDePlusGrandeDef = UnitsOnCase[0];
            foreach(UniteDeBase u in UnitsOnCase){
                if (u.getDef() > plusGrandeDef){
                    plusGrandeDef = u.getDef();
                    uniteDePlusGrandeDef=u;
                }
            }
            return uniteDePlusGrandeDef;
        }



    }
}
