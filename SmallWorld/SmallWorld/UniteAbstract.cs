using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace SmallWorld
{
    [XmlInclude(typeof(GuerrierNains))]
    [XmlInclude(typeof(GuerrierGaulois))]
    [XmlInclude(typeof(GuerrierVikings))]

    public abstract class UniteDeBase : Unite
    {
        public int att, def, pv, row, column, indexEllipse, pourcentagePV, tag;
        public float ptDeDepl;
        public Boolean estMort = false; //seDeplaceApresCombat = false;  y en a pas besoin ici +  estMort aussi il sert pas vraiment
        public static int nbUnit = 0;

        public UniteDeBase()
        {
            att = 2;
            def = 1;
            ptDeDepl = 1;
            pv = 5;
            row = 0;
            column = 0;
            pourcentagePV = 100;
            tag = nbUnit;
            nbUnit++;
        }

        public Boolean estMorte()
        {
            return estMort;
        }

        public void setRow(int r)
        {
            row = r;
        }

        public void setColumn(int c)
        {
            column = c;
        }

        public int getRow()
        {
            return row;
        }

        public int getTag()
        {
            return tag;
        }

        public int getColumn()
        {
            return column;
        }

        public int getPV()
        {
            return pv;
        }

        public int getAtt()
        {
            return att;
        }

        public int getDef()
        {
            return def;
        }

        public void setPV(int a)
        {
            pv = a;
        }

        public void setIndexEllipse(int i)
        {
            indexEllipse = i;
        }

        public int getIndexEllipse()
        {
            return indexEllipse;
        }

        public Boolean seDeplacer(int departureRow, int departureColumn, int arrivalRow, int arrivalColumn) { return true; }

        public void meurt()
        {
            this.estMort = true;
        }

        public void majPosition(int _row, int _column)
        {
            //seDeplaceApresCombat = true;
            row = _row;
            column = _column;
        }

        /*public Boolean seDeplaceSuiteAuCombat()
        {
            return seDeplaceApresCombat;
        }*/

        /*public Boolean Egal(UniteDeBase u)
        {
            return (att==u.att && def==u.def && pv==u.pv && row==u.row && column==u.column && this.indexEllipse==u.indexEllipse && ptDeDepl==u.ptDeDepl && estMort==u.estMort && seDeplaceApresCombat==u.seDeplaceApresCombat);
        }*/

        public void setPourcentagePV(int i)
        {
            pourcentagePV = i;
        }

        public int getPourcentagePV()
        {
            return pourcentagePV;
        }

        public Boolean getEstMort()
        {
            return estMort;
        }

        public void setPtDeDepl(int i)
        {
            ptDeDepl = i;
        }

        public float getptDeDepl()
        {
            return ptDeDepl;
        }

    }
}
