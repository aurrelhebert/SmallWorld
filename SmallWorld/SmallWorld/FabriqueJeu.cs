using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld
{
    public interface FabriqueJeu
    {
        Joueur creerJoueur(String nom, Peuple peuple);

        Partie creerPartie(int nombreTour, Joueur j1, Joueur j2, Carte carte, List listeUniteJoueur1, List listeUniteJoueur2);

        Carte creerCarte(int strategy);
    }
}
