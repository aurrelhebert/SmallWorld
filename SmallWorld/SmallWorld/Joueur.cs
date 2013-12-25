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

        public Joueur()
        {
        }

        public Joueur(int nbUnite, Peuple peuple)
        {
            _nbUnite = nbUnite;
            _peuple = peuple;
        }

        public void setPeuple(Peuple p)
        {
            _peuple = p;
        }

        public void setNbUnite(int nb)
        {
            _nbUnite = nb;
        }

        public List<Unite> getUnite()
        {
            return this._peuple.getUnites();
        }

        public void setXUnites(int x)
        {
            this._peuple.creerUnites(x);
        }

        public void combat()
        {
        }
    }
}
