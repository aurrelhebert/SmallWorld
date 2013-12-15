using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld
{
    public interface FabriquePeuple
    {
        Peuple creerNain();

        Peuple creerGaulois();

        Peuple creerViking();
    }
}
