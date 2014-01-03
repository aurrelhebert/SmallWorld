using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld
{
    public class Gaulois : Peuple
    {
        public Gaulois() { }

        public override void creerUnites(int nbr)
        {
            int i;
            for (i = 0; i < nbr; i++)
            {
                this.getUnites().Add(new GuerrierGaulois());
            }

        }

        public override Boolean isNain()
        {
            return false;
        }

        public override Boolean isGaulois()
        {
            return true;
        }

        public override Boolean isVikings()
        {
            return false;
        }
    }
}
