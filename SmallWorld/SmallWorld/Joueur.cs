using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld
{
    public class Joueur
    {
        int _nbUnite;
        Peuple _peuple;

        /// <summary>
        /// Constructeur
        /// </summary>
        public Joueur()
        {
        }

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="nbUnite"> Le nombre max d'unite d'un peuple </param>
        /// <param name="peuple"> Le peuple du joueur </param>
        public Joueur(int nbUnite, Peuple peuple)
        {
            _nbUnite = nbUnite;
            _peuple = peuple;
        }

        /// <summary>
        /// Setter du peuple
        /// </summary>
        /// <param name="p"> Peuple </param>
        public void setPeuple(Peuple p)
        {
            _peuple = p;
        }

        /// <summary>
        /// Setter des unites
        /// </summary>
        /// <param name="nb"> Nombre d'unite max </param>
        public void setNbUnite(int nb)
        {
            _nbUnite = nb;
        }

        /// <summary>
        /// Obtention de la liste d'unité d'un joueur
        /// </summary>
        /// <returns> sa liste d'unité</returns>
        public List<Unite> getUnite()
        {
            return this._peuple.getUnites();
        }

        /// <summary>
        /// Création de sa liste d'unités
        /// </summary>
        /// <param name="x"> le nombre d'unités </param>
        public void setXUnites(int x)
        {
            this._peuple.creerUnites(x);
        }

        /// <summary>
        /// Gestion des combatd
        /// </summary>
        /// <param name="">  </param>
        /// <param name="">  </param>
        /// <returns></returns>
        public void combat()
        {
        }
    }
}
