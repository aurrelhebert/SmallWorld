using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld
{
    public interface Peuple
    {

        void creerUnites(int nbr);

        void ajouteUnite(string Unite);

        void supprimerUnite(string Unite);

        void creerUnite();

        void getUnites();
    }
}
