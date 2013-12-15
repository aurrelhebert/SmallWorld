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
void positionJoueur(int xJ1,int yJ1,int xJ2,int yJ2) {Algo_positionJoueur(algo,xJ1,yJ1,xJ2,yJ2); }
};
}
#endif

