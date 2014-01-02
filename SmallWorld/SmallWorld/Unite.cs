using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wrapper;

namespace SmallWorld
{
    public interface Unite
    {
        //WrapperAlgo wa;

        /// <summary>
        /// Methode permettant le deplacement d'une unité
        /// </summary>
        Boolean seDeplacer(int departureRow, int departureColumn, int arrivalRow, int arrivalColumn);


        /// <summary>
        /// Methode permettantà une unité d'attaquer
        /// </summary>
        void attaquer();


        /// <summary>
        /// Methode permettant de changer l'indice de la ligne d'une unité
        /// </summary>
        void setRow(int x);


        /// <summary>
        /// Methode permettant de connaitre l'indice de la ligne d'une unité
        /// </summary>
        /// <returns> l'indice de la ligne d'une unité</returns>
        int getRow();

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
        /// Methode permettant de connaitre les PV restant d'une unité
        /// </summary>
        /// <returns> l'indice de la colonne d'une unité</returns>
        int getPV();

        /// <summary>
        /// Methode permettant de connaitre l'attaque d'une unité
        /// </summary>
        /// <returns> l'indice de la colonne d'une unité</returns>
        int getAtt();

        /// <summary>
        /// Methode permettant de connaitre la défense d'une unité
        /// </summary>
        /// <returns> l'indice de la colonne d'une unité</returns>
        int getDef();


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
