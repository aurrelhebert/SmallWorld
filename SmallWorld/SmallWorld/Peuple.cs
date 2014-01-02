using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld
{
    public class Peuple
    {
        List<UniteDeBase> _unites;
        public enum NomPeuple { GAULOIS = 0, NAINS, VIKINGS };
        public NomPeuple nomPeuple;

        /// <summary>
        /// Constructeur
        /// </summary>
        public Peuple(NomPeuple name)
        {
            nomPeuple = name;
            _unites = new List<UniteDeBase>();
        }

        /// <summary>
        /// Methode permettant de remplir la liste d'unité d'un peuple
        /// </summary>
        /// <param name="nbr"> le nombre d'unites à ajouter </param>
        public virtual void creerUnites(int nbr) {
            int i;
            UniteDeBase unit;
            switch(nomPeuple){
                case (NomPeuple.GAULOIS): unit = new GuerrierGaulois(); break;
                case (NomPeuple.NAINS): unit = new GuerrierNains(); break;
                default: unit = new GuerrierVikings(); break;                
            }
            for (i = 0; i < nbr; i++)
            {
                this.getUnites().Add(unit);
            }
        }

       
        public void ajouteUnite(string Unite)
        {
        }

        /// <summary>
        /// Methode permettant de supprimer une unité d'un peuple
        /// </summary>
        /// <param name="unite"> l'unité à supprimer </param>
        public void supprimerUnite(int Unite)
        {
        }

        public void creerUnite()
        {
        }

        /// <summary>
        /// Methode permettant de récuperer la liste d'unité du peuple
        /// </summary>
        /// <returns> la liste des unités</returns>
        public List<UniteDeBase> getUnites()
        {
            return this._unites;
        }
    }
}
