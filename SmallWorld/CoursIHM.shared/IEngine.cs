using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cours.Shared
{
    public interface IEngine
    {
        IMap GetMap();       
        IUnit GetUnit();
        void NextTurn();
    }
}
