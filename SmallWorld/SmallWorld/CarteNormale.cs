using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld
{
    public class CarteNormale : StrategieCarte
    {

        public int nombreUniteParPeuple()
        {
            return 8;
        }

        public int tailleCarte()
        {
            return 15;
        }

        public int nombreDeTour()
        {
            return 30;
        }
    }
}
