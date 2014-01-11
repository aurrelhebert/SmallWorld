#include "Algo.h"
#include <time.h> 
#include <stdlib.h>
using namespace std;

 //int depart_J1 =0;

int Carte::computeFoo() {
return 1;
}

 bool verifChemin(int i, int j, Carte* algo,int mode) ;
 int depart_J1;
	
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
	depart_J1 = rand()%2;
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
	do {
		for(i=0;i<algo->taille;i++) {
			for(j=0;j<algo->taille;j++) {
				// gen ale case;
				int alea = rand()%NB_MAX_LANDSCAPE;
				algo->tabCases[i][j] = alea;
			}
		}
	}while(!verifChemin(4*depart_J1,0,algo,depart_J1));
	
	return algo->tabCases;
}

// normalement on ne l'utilise plus

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
	 if (depart_J1 ==0 ) {
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

 int Algo_ChoixNbDeCombat(int pv1, int pv2){
	 int pvmax;
	 if(pv1<pv2){
		 pvmax=pv2;
	 }else{
		 pvmax=pv1;
	 }
	 if(pvmax<=1) {return 3;
	 }else{
		 return 3+(rand()%pvmax);
	 }
 }

 bool Algo_CalculAttaque(int attaque, int defense, int pourcentageAttaque, int pourcentageDefense){
	 float attaqueFinale=(attaque*pourcentageAttaque)/100.0f;
	 float defenseFinale=(defense*pourcentageDefense)/100.0f;
	 float pourcentageDeChanceAttaquantPerdUneVie;
	 if(attaqueFinale <= defenseFinale){
		if(defenseFinale==0.0f) return false;
		float rapport=attaqueFinale/defenseFinale;
		pourcentageDeChanceAttaquantPerdUneVie=100-(rapport*50);//pourcentageDeChanceAttaquantPerdUneVie > 50%
	 }else{
		 if(attaqueFinale==0.0f) return true;
		float rapport=defenseFinale/attaqueFinale;
		pourcentageDeChanceAttaquantPerdUneVie=(rapport*50);//pourcentageDeChanceAttaquantPerdUneVie < 50%
	 }
	 int tirageAleatoire=rand()%101;
	 return (tirageAleatoire <= pourcentageDeChanceAttaquantPerdUneVie);
 }

 bool estEau(int i, int j, Carte* algo) 
{
	return (algo->tabCases[i][j] == 3);
}

  bool verifChemin(int i, int j, Carte* algo,int mode) {
	 bool test_i;
	 int k;

	 if (mode==0)
	 {
		 k=i+1;
		 test_i= i<(algo->taille-1);

		 if((i==j) && (j==algo->taille-1))
			 return true;
	 }
	 else
	 {
		 k=i-1;
		 test_i= i>0;

		 if((i==0) && (j==0))
			return true;
	 }

	 if (test_i && (j<algo->taille-1))
		{

		if (estEau(k,j,algo) && estEau(i, j+1, algo))
		{
			return false;
		}
		if (!estEau(k,j,algo) && !estEau(i, j+1, algo))
			{
				bool depDroit = verifChemin(k, j, algo, mode);
				bool depGauche = verifChemin(i, j+1, algo, mode);
				return (depDroit || depGauche);
			}
		else if (!estEau(k,j,algo))
			{
				bool depDroit = verifChemin(k, j, algo, mode);
				return (depDroit);
			}
		else if (!estEau(i, j+1, algo))
			{
				bool depGauche = verifChemin(i, j+1, algo, mode);
				return (depGauche);
			}
		else 
			{
				return false;
			}
		}

	 if (test_i)
		{

		if (!estEau(k,j,algo))
			{
				bool depDroit = verifChemin(k, j, algo, mode);
				return (depDroit);
			}
		else 
			{
				return false;
			}
		}

	  if (j<(algo->taille-1))
		{
		if (!estEau(i, j+1, algo))
			{
				bool depGauche = verifChemin(i, j+1, algo, mode);
				return (depGauche);
			}
		else 
			{
				return false;
			}
		}
 }


