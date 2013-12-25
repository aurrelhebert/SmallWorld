using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld
{
    public abstract class UniteDeBase : Unite
    {
        int att, def, ptDeDepl, pv, raw, column;

        public UniteDeBase()
        {
            att = 2;
            def = 1;
            ptDeDepl = 0;
            pv = 2;
            raw = 0;
            column = 0;
        }

        public void setRaw(int x)
        {
            raw = x;
        }

        public void setColumn(int x)
        {
            column = x;
        }

        public int getRaw()
        {
            return raw;
        }

        public int getColumn()
        {
            return column;
        }


        public void seDeplacer() { }

        public void attaquer() { }
    }
}
