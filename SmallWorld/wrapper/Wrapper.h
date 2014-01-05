#ifndef __WRAPPER__
#define __WRAPPER__

#include "../lib_genCarte/algo.h" // A changer
#pragma comment(lib, "../Debug/lib_genCarte.lib") // A changer

using namespace System;

namespace Wrapper {
public ref class WrapperAlgo {

private:
Carte* algo;

public:
WrapperAlgo(int n){ algo = Carte_new(n); }
~WrapperAlgo(){ Carte_delete(algo); }
int** remplirCarte() {return Algo_remplirCarte(algo); }
void positionJoueur(int* xJ1,int* yJ1,int* xJ2,int* yJ2) {Algo_positionJoueur(algo,xJ1,yJ1,xJ2,yJ2); }
static void positionJoueurParTaille(int taille, int* xJ1,int* yJ1,int* xJ2,int* yJ2) {Algo_positionJoueurParTaille(taille,xJ1,yJ1,xJ2,yJ2); }
int getTypeCase(int x, int y){return Algo_getTypeCase(algo,x,y);}//peut retourner -1 si la case n'est pas bonne
Carte* getCarte(){return algo;}
static Boolean isAdjacentCase(int x1, int y1,int x2, int y2){return Algo_isAdjacentCase(x1, y1, x2, y2);}
static int nbCombat(int pv1, int pv2){return Algo_ChoixNbDeCombat(pv1, pv2);}
static Boolean LattaquantPerdUnPV(int attaque, int defense, int pourcentageAttaque, int pourcentageDefense){return Algo_CalculAttaque(attaque, defense, pourcentageAttaque, pourcentageDefense);}
};

}

#endif

