using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld
{
    public class Nains : Peuple
    {
        public Nains()
        {
            this.nomPeuple = NomPeuple.NAINS;
        }


        public override void creerUnites(int nbr)
        {
            int i;
            for (i = 0; i < nbr; i++)
            {
               this.getUnites().Add(new GuerrierNains());
            }

        }

        public override Boolean isNain()
        {
            return true;
        }

        public override Boolean isGaulois()
        {
            return false;
        }

        public override Boolean isVikings()
        {
            return false;
        }
    }
}
