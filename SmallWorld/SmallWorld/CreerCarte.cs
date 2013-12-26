using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld
{
    public interface StrategieCarte
    {
        /// <summary>
        /// Methode permettant de connaitre le nombre d'unite par peuple
        /// </summary>
        /// <returns> le nombre maximum que chaque joueur peut controler</returns>
        int nombreUniteParPeuple();

        /// <summary>
        /// Methode permettant de connaitre la taille de la carte
        /// </summary>
        /// <returns> le nombre de case par ligne (et par colonne : la carte étant un carré)</returns>
        int tailleCarte();


        /// <summary>
        /// Methode permettant de connaitre le nombre de tour de jeux
        /// </summary>
        /// <returns> le nombre de tour</returns>
        int nombreDeTour();
    }
}
