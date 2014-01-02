using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cours.Shared
{
    public interface IMap
    {
        int Width { get; }
        int Height { get; }

        ITile[,] Tiles { get; }
    }
}
