using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld
{
    public class Vikings : Peuple
    {
        public Vikings()
        {
            this.nomPeuple = NomPeuple.VIKINGS;
        }

        public override void creerUnites(int nbr)
        {
            int i;
            for (i = 0; i < nbr; i++)
            {
                this.getUnites().Add(new GuerrierVikings());
            }

        }

        public override Boolean isNain()
        {
            return false;
        }

        public override Boolean isGaulois()
        {
            return false;
        }

        public override Boolean isVikings()
        {
            return true;
        }
    }
}
