using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld
{
    public interface Carte
    {

        void getCase(int Position);
    }

    public interface CarteNormale : StrategieCarte
    {
    }
}
