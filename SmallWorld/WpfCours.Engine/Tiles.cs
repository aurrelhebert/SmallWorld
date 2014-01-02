using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cours.Shared;

// Définiton des Tuiles
namespace Cours.Engine
{
    public class Tile : ITile {
        public int Iron {
            get;
            internal set;
        }
    }

    public class Land : Tile, ILand {
        public Land()
        {
            Iron = 10;
        }
    }

    public class Sea : Tile, ISea {
        public Sea() {
            Iron = 2;
        }
    }

    public class Forest : Tile, IForest {
        public Forest() {
            Iron = 5;
        }
    }
}
