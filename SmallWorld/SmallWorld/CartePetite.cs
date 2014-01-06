using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld
{
    public class CartePetite : StrategieCarte
    {
        public CartePetite()
        {
        }

        public override int nombreUniteParPeuple()
        {
            return 6;
        }

        public override int tailleCarte()
        {
            return 10;
        }

        public override int nombreDeTour()
        {
            return 20;
        }
    }
}
