using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace SmallWorld
{
    [XmlInclude(typeof(CarteDemo))]
    [XmlInclude(typeof(CarteNormale))]
    [XmlInclude(typeof(CartePetite))]
    public abstract class StrategieCarte
    {

        public StrategieCarte()
        {
        }

        /// <summary>
        /// Methode permettant de connaitre le nombre d'unite par peuple
        /// </summary>
        /// <returns> le nombre maximum d'unites que chaque joueur peut controler</returns>
        public abstract int nombreUniteParPeuple();

        /// <summary>
        /// Methode permettant de connaitre la taille de la carte
        /// </summary>
        /// <returns> le nombre de case par ligne (et par colonne : la carte étant un carré)</returns>
        public abstract int tailleCarte();


        /// <summary>
        /// Methode permettant de connaitre le nombre de tour de jeux
        /// </summary>
        /// <returns> le nombre de tour</returns>
        public abstract int nombreDeTour();
    }
}
