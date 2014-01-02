using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld
{
    public abstract class UniteDeBase : Unite
    {
        public int att, def, pv, row, column, indexEllipse;
        public float ptDeDepl;

        public UniteDeBase()
        {
            att = 2;
            def = 1;
            ptDeDepl = 1;
            pv = 2;
            row = 0;
            column = 0;
        }

        public void setRow(int x)
        {
            row = x;
        }

        public void setColumn(int x)
        {
            column = x;
        }

        public int getRow()
        {
            return row;
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

        public void setIndexEllipse(int i)
        {
            indexEllipse = i;
        }

        public int getIndexEllipse()
        {
            return indexEllipse;
        }

        public Boolean seDeplacer(int departureRow, int departureColumn, int arrivalRow, int arrivalColumn) { return true; }

        public void attaquer() { }
    }
}
