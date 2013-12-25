using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld
{
    public class Gaulois : Peuple
    {
        List<Unite> _unites;

        public void creerUnites(int nbr)
        {
            int i;
            for (i = 0; i < nbr; i++)
            {
                _unites[i] = new GuerrierGaulois();
            }

        }
    }
}
