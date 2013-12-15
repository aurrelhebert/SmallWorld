using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld
{
    public interface Partie
    {
        void gestionUnites(List unite);

        void executionTour();

        void deroulementDeLaPartie();

        void miseAJourDesPoints();
    }
}
