using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cours.Shared;

namespace Cours.Engine
{
    public class Map : IMap
    {
        Tile[,] tiles; // tableau des tuiles
        public Map(int width, int height)
        {
            Width = width; // attribut implicitement défini
            Height = height; // attribut implicitement défini
            tiles = new Tile[width, height];
            for (int l = 0; l < height; l++)
                for (int c = 0; c < width; c++)
                    Tiles[c, l] = new Land();

            // spécialisation de quelques tuiles
            tiles[1, 2] = new Sea(); tiles[1, 3] = new Sea(); tiles[2, 2] = new Sea();
            tiles[2, 1] = new Forest();
            tiles[6, 9] = new Forest(); tiles[7, 7] = new Forest(); tiles[8, 8] = new Forest();
        }

        public int Width
        {
            get;
            private set;
        }

        public int Height
        {
            get;
            private set;
        }

        public ITile[,] Tiles
        {
            get { return tiles; }
        }

        // pour réduire la resource fer de la tuile
        internal void Consume(int row, int column)
        {
            tiles[column, row].Iron--;
        }

    }
}
