using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld
{
    public interface Unite
    {

        /// <summary>
        /// Methode permettant le deplacement d'une unité
        /// </summary>
        void seDeplacer();


        /// <summary>
        /// Methode permettantà une unité d'attaquer
        /// </summary>
        void attaquer();


        /// <summary>
        /// Methode permettant de changer l'indice de la ligne d'une unité
        /// </summary>
        void setRaw(int x);


        /// <summary>
        /// Methode permettant de connaitre l'indice de la ligne d'une unité
        /// </summary>
        /// <returns> l'indice de la ligne d'une unité</returns>
        int getRaw();

        /// <summary>
        /// Methode permettant de changer l'indice de la colonne d'une unité
        /// </summary>
        void setColumn(int x);

        /// <summary>
        /// Methode permettant de connaitre l'indice de la colonne d'une unité
        /// </summary>
        /// <returns> l'indice de la colonne d'une unité</returns>
        int getColumn();

        /// <summary>
        /// Methode permettant de changer l'indice de l'ellipse symbolisant une unité
        /// </summary>
        void setIndexEllipse(int i);

        /// <summary>
        /// Methode permettant de connaitre l'indice de l'ellipse symbolisant une unité
        /// </summary>
        /// <returns> l'indice de l'ellipse symbolisant une unité</returns>
        int getIndexEllipse();
    }
}
