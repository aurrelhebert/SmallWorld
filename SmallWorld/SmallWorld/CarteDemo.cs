using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld
{
    public class CarteDemo : StrategieCarte
    {
        public CarteDemo()
        {
        }

        public override int nombreUniteParPeuple()
        {
            return 4;
        }

        public override int tailleCarte()
        {
            return 5;
        }

        public override int nombreDeTour()
        {
            return 5;
        }
    }
}
