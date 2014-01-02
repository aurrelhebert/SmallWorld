using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld
{
    public class Gaulois : Peuple
    {
       // List<Unite> _unites;

        public override void creerUnites(int nbr)
        {
            int i;
            for (i = 0; i < nbr; i++)
            {
                this.getUnites().Add(new GuerrierGaulois());
            }

        }
    }
}
