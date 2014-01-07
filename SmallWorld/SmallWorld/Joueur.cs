using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld
{
    public class Joueur
    {
        public Peuple _peuple;
        public int x0;
        public int y0;

        /// <summary>
        /// Constructeur
        /// </summary>
        public Joueur()
        {/*
            x0 = 0;
            y0 = 0;*/
        }

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="nbUnite"> Le nombre max d'unite d'un peuple </param>
        /// <param name="peuple"> Le peuple du joueur </param>
        public Joueur(Peuple peuple, int raw0=0,int column0=0)
        {
            _peuple = peuple;
            x0 = raw0;
            y0 = column0;
        }

        /// <summary>
        /// Setter du peuple
        /// </summary>
        /// <param name="p"> Peuple </param>
        public void setPeuple(Peuple p)
        {
            _peuple = p;
        }

        public Peuple getPeuple()
        {
            return _peuple;
        }



        /// <summary>
        /// Getter du nombre d'unité d'un joueur
        /// </summary>
        /// <returns> le nombre d'unité possédé par un jouueur</returns>
        public int getNbUnite()
        {
            return _peuple.getUnites().Count;
        }

        /// <summary>
        /// Obtention de la liste d'unité d'un joueur
        /// </summary>
        /// <returns> sa liste d'unité</returns>
        public List<UniteDeBase> getUnite()
        {
            return this._peuple.getUnites();
        }

        /// <summary>
        /// Création de sa liste d'unités
        /// </summary>
        /// <param name="x"> le nombre d'unités </param>
        public void setXUnites(int x)
        {
            this._peuple.creerUnites(x);
        }

        /// <summary>
        /// Gestion des combatd
        /// </summary>
        /// <param name="">  </param>
        /// <param name="">  </param>
        /// <returns></returns>
        public void combat()
        {
        }

        public int getx0()
        {
            return x0;
        }

        public int gety0()
        {
            return y0;
        }

        public void setx0(int x)
        {
            x0=x;
        }

        public void sety0(int y)
        {
            y0 = y;
        }

        public void changeLeBonElement(UniteDeBase u, UniteDeBase umodifie) {
            List<UniteDeBase> l = _peuple.getUnites();
            int i;
            for (i = 0; i<l.Count; i++)
            {
                if (l[i] == u)
                {
                    l.RemoveAt(i);
                    l.Insert(i, umodifie);
                }
            }

        }
        
    }
}
