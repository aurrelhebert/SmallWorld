using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace SmallWorld
{
    [XmlInclude(typeof(Desert))]
    [XmlInclude(typeof(Eau))]
    [XmlInclude(typeof(Foret))]
    [XmlInclude(typeof(Plaine))]
    [XmlInclude(typeof(Montagne))]
    public abstract class Case
    {
        public List<UniteDeBase> UnitsOnCase;
        public enum etatCase { libre, joueur1, joueur2 };
        public etatCase etatOccupation;
        public enum TypeCase { MONTAGNE = 0, PLAINE, DESERT, EAU, FORET };
        public TypeCase type;


        /// <summary>
        /// Constructeur de case
        /// </summary>
        /// <param name="column"> le type de la case </param>
        public Case(TypeCase t)
        {
            type = t;
            etatOccupation = etatCase.libre;
            UnitsOnCase = new List<UniteDeBase>();
        }

        /// <summary>
        /// getter de la liste des unités sur la case
        /// </summary>
        /// <returns> la liste des cases UnitsOnCase</returns>
        public List<UniteDeBase> getUnitsOnCase()
        {
            return UnitsOnCase;
        }

        /// <summary>
        /// getter de l'etat d'occupation de la casse
        /// </summary>
        /// <returns> l'etat d'occupation de la case, etatOccupation</returns>
        public etatCase getEtatOccupation()
        {
            return etatOccupation;
        }

        /// <summary>
        /// setter de l'etat d'occupation de la case
        /// </summary>
        /// <param name="column"> l'etat d'occupation que l'on veut affecter à la case </param>
        public void setEtatOccupation(int numjoueur)
        {
            switch (numjoueur)
            {
                case 1: etatOccupation = etatCase.joueur1; break;
                case 2: etatOccupation = etatCase.joueur2; break;
                default: etatOccupation = etatCase.libre; break;
            }

        }

        /// <summary>
        /// fonction permettant d'ajouter une unités sur une case
        /// </summary>
        /// <param name="column"> l'unité que l'on veut ajouter à a case </param>
        public void setUnitsOnCase(UniteDeBase u)
        {
            UnitsOnCase.Add(u);
        }

        /// <summary>
        /// fonction permettant de changer la liste des unités présentes sur une case
        /// </summary>
        /// <param name="column"> la liste des unités qui va servir à initialiser la liste des unités de la case </param>
        public void initUnitsOnCase(List<UniteDeBase> l)
        {
            UnitsOnCase.Clear();
            foreach (UniteDeBase u in l)
            {
                UnitsOnCase.Add(u);
            }
        }


        /// <summary>
        /// getter du type de la case
        /// </summary>
        /// <returns> le type de la case, type</returns>
        public TypeCase getType()
        {
            return type;
        }

        /// <summary>
        /// fonction permettant de connaitre le nombre d'unités sur une case
        /// </summary>
        /// <returns> le nombre d'unité sur la case </returns>
        public int getNbUnitsOnCase()
        {
            return UnitsOnCase.Count();
        }

        /// <summary>
        /// fonction permettant de connaitre l'unité de plus grande défense sur une case
        /// </summary>
        /// <returns> l'unité de cette case qui a la plus graande défense </returns>
        public UniteDeBase getLUniteDePlusGrandeDefense()
        {
            int plusGrandeDef = 0;
            UniteDeBase uniteDePlusGrandeDef = UnitsOnCase[0];
            foreach (UniteDeBase u in UnitsOnCase)
            {
                if (u.getDef() > plusGrandeDef)
                {
                    plusGrandeDef = u.getDef();
                    uniteDePlusGrandeDef = u;
                }
            }
            return uniteDePlusGrandeDef;
        }



    }
}
