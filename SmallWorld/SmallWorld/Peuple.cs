using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld
{
    public abstract class Peuple
    {
        List<Unite> _unites;

        /// <summary>
        /// Constructeur
        /// </summary>
        public Peuple()
        {
            _unites = new List<Unite>();
        }

        /// <summary>
        /// Methode permettant de remplir la liste d'unité d'un peuple
        /// </summary>
        /// <param name="nbr"> le nombre d'unites à ajouter </param>
        public virtual void creerUnites(int nbr)
        {
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
        public List<Unite> getUnites()
        {
            return this._unites;
        }
    }
}
