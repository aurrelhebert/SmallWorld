using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld
{
    public class CartePetite : StrategieCarte
    {

        public int nombreUniteParPeuple()
        {
            return 6;
        }

        public int tailleCarte()
        {
            return 10;
        }

        public int nombreDeTour()
        {
            return 20;
        }
    }
}
