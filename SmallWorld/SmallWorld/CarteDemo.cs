using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld
{
    public class CarteDemo : StrategieCarte
    {
        
        public int nombreUniteParPeuple()
        {
            return 4;
        }

        public int tailleCarte()
        {
            return 5;
        }

        public int nombreDeTour()
        {
            return 5;
        }
    }
}
