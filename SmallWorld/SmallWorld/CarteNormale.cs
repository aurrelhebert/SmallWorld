using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld
{
    public class CarteNormale : StrategieCarte
    {
        public CarteNormale()
        {
        }

        public override int nombreUniteParPeuple()
        {
            return 8;
        }

        public override int tailleCarte()
        {
            return 15;
        }

        public override int nombreDeTour()
        {
            return 30;
        }
    }
}
