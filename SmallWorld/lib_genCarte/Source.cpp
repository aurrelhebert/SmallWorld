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

void Carte_delete(Carte* carte) { 
	if(carte!=NULL){
		int i;
		for(i=0;i<carte->taille;i++) {
		if (carte->tabCases[i]!=NULL) delete carte->tabCases[i];
	}
	 delete carte; 
	}
}

int** Algo_remplirCarte(Carte* algo) { 
	int i;
	int j;
	//algo->computeFoo();
	for(i=0;i<algo->taille;i++) {
		for(j=0;j<algo->taille;j++) {
			// gen ale case;
			int alea = rand()%NB_MAX_LANDSCAPE;
			algo->tabCases[i][j] = alea;
		}
	}
	return algo->tabCases;
}

 void Algo_positionJoueur(Carte* algo,int* xJ1,int* yJ1,int* xJ2,int* yJ2){
	 int alea = rand()%2;
	 if (alea ==0) {
		*xJ1 = 0;
		*yJ1 = 0;
		*xJ2 = algo->taille-1;
		*yJ2 = algo->taille-1;
	 }
	 else {
		*xJ1 = algo->taille-1;
		*yJ1 = 0;
		*xJ2 = 0;
		*yJ2 = algo->taille-1;
	 }
 }

 void Algo_positionJoueurParTaille(int taille,int* xJ1,int* yJ1,int* xJ2,int* yJ2){
	 int alea = rand()%2;
	 if (alea ==0) {
		*xJ1 = 0;
		*yJ1 = 0;
		*xJ2 =taille-1;
		*yJ2 = taille-1;
	 }
	 else {
		*xJ1 = taille-1;
		*yJ1 = 0;
		*xJ2 = 0;
		*yJ2 = taille-1;
	 }
 }


 int Algo_getTypeCase(Carte* algo, int x, int y) {
	 if (algo==NULL) return -1;
	 if (x>=algo->taille) return -1;
	 if (y>=algo->taille) return -1;
	 return algo->tabCases[x][y];
 }

 bool Algo_isAdjacentCase(int  x1, int y1, int x2, int y2){
	 if(x1==x2){
		 if(y1==(y2-1) || y1==(y2+1)) return true;
	 }else
	 {
		 if(y1!=y2) return false;
		 if(x1==(x2-1) || x1==(x2+1)) return true;
	 }
	 return false;
 }
