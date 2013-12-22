using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cours.Shared;

namespace Cours.Engine
{
    // Coeur de l'application
    // Moteur : Creation d'une map de (20,10) et d'une unité
    public class Engine : IEngine
    {
        Map map;
        Unit unit;
        public Engine(){
            map = new Map(20, 10);
            unit = new Unit();
        }

        public IMap GetMap(){
            return map;
        }

        public IUnit GetUnit(){
            return unit;
        }

        // Passage au tour suivant
        public void NextTurn()
        {
            // Simulation d'un calcul important du moteur pour illustrer l'interet des threads
            System.Threading.Thread.Sleep(3000);

            // On consomme une ressource de Fer à l'endroit de l'unité
            map.Consume(unit.Column, unit.Row);

            // On déplace l'unité (NB: attention on peut sortir de la map)
            unit.Column++;
            unit.Row++;

        }
    }
}
