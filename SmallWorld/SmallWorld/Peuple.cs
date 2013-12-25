using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld
{
    public abstract class Peuple
    {
        List<Unite> _unites;

        public Peuple()
        {
            _unites = new List<Unite>();
        }

        public void creerUnites(int nbr)
        {
        }

        public void ajouteUnite(string Unite)
        {
        }

        public void supprimerUnite(string Unite)
        {
        }

        public void creerUnite()
        {
        }

        public List<Unite> getUnites()
        {
            return this._unites;
        }
    }
}
