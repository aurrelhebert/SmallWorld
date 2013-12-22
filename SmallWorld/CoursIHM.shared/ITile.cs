using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cours.Shared
{
    public interface ITile{
       int Iron { get; }
    }

    public interface ILand : ITile {   }

    public interface ISea : ITile {  }

    public interface IForest : ITile  {   }

}
