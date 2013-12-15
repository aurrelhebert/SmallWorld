#include "Algo.h"
#include <time.h> 
#include <stdlib.h>
using namespace std;
int Carte::computeFoo() {
return 1;
}

Carte* Carte_new(const int n) { 
	int i;
	Carte* c = new Carte();
	c->tabCases=new int*[n];
	//Parcourir chaque case en faisant new int avec n.
	for(i=0;i<n;i++) {
		c->tabCases[i]=new int[n];
	}
	c->tabRessources=new int*[n];
	//Parcourir chaque case en faisant new int avec n.
	for(i=0;i<n;i++) {
		c->tabRessources[i]=new int[n];
	}
	c->nbressource=n/2;
	c->taille=n;
	srand (time(NULL));
	return c;
	//Calcul en random de la pos de 
}

void Carte_delete(Carte* carte) { if(carte!=NULL) delete carte; }
int** Algo_remplirCarte(Carte* algo) { 
	int i;
	int j;
	//algo->computeFoo();
	for(i=0;i<algo->taille;i++) {
		for(j=0;j<algo->taille;j++) {
			// gen ale case;
			int alea = rand()%5;
			algo->tabCases[i][j] = alea;
		}
	}
	return algo->tabCases;
}

 void Algo_positionJoueur(Carte* algo,int xJ1,int yJ1,int xJ2,int yJ2){
	 int alea = rand()%2;
	 if (alea ==0) {
		xJ1 = 0;
		yJ1 = 0;
		xJ2 = algo->taille;
		yJ2 = algo->taille;
	 }
	 else {
		xJ1 = algo->taille;
		yJ1 = 0;
		xJ2 = 0;
		yJ2 = algo->taille;
	 }
 }

