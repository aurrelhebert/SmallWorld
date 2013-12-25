using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld
{
    public interface Unite
    {
        void seDeplacer();

        void attaquer();

        void setRaw(int x);

        int getRaw();

        void setColumn(int x);

        int getColumn();
    }
}
