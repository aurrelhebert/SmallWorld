using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cours.Shared;

// Défintion des unités
namespace Cours.Engine
{
    public class Unit: IUnit{

        public int Row
        {
            get;
            internal set;
        }

        public int Column
        {
            get;
            internal set;
        }
    }
}
