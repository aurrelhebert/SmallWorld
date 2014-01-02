using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld
{
    public class Joueur
    {
        private int _nbUnite;
        private Peuple _peuple;
        private int x0;
        private int y0;

        /// <summary>
        /// Constructeur
        /// </summary>
        public Joueur()
        {
            x0 = 0;
            y0 = 0;
            _nbUnite = 0;
            _peuple = new Peuple(Peuple.NomPeuple.GAULOIS);
        }

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="nbUnite"> Le nombre max d'unite d'un peuple </param>
        /// <param name="peuple"> Le peuple du joueur </param>
        public Joueur(int nbUnite, Peuple peuple, int raw0=0,int column0=0)
        {
            _nbUnite = nbUnite;
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
        /// Setter des unites
        /// </summary>
        /// <param name="nb"> Nombre d'unite max </param>
        public void setNbUnite(int nb)
        {
            _nbUnite = nb;
        }

        /// <summary>
        /// Getter du nombre d'unité d'un joueur
        /// </summary>
        /// <returns> le nombre d'unité possédé par un jouueur</returns>
        public int getNbUnite()
        {
            return _nbUnite;
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

        public Boolean haveAttaquePerduUneVie(int att, int def)
        {
            Boolean resultat = false;
            int i;
            Boolean attPlusFort = false;
            if (att > def)
            {
                i = att - def;
                attPlusFort = true;
            }
            else 
            {
                i = def - att;
            }
            double chance = (i * 25)*0.5 + 50;
            Random rand = new Random();
            int res = rand.Next(1,100);
            if (attPlusFort)
            {
                if (res > chance)
                    resultat = true;
            }
            else
            {
                if (res < chance)
                    resultat = true;
            }
            return resultat;
        }
    }
}
