#ifndef __WRAPPER__
#define __WRAPPER__

#include "../lib_genCarte/algo.h" // A changer
#pragma comment(lib, "../Debug/lib_genCarte.lib") // A changer
#pragma comment(lib, "../Release/lib_genCarte.lib") // A changer

using namespace System;

namespace Wrapper {
	public ref class WrapperAlgo {

	private:
		Carte* algo;

	public:

		/// <summary>
		/// Constructeur d'une carte
		/// </summary>
		/// <param name="n"> taille de la carte</param>
		WrapperAlgo(int n){ algo = Carte_new(n); }

		/// <summary>
		/// Destructeur 
		/// </summary>
		~WrapperAlgo(){ Carte_delete(algo); }

		/// <summary>
		/// Algo de generation d'une carte
		/// </summary>
		/// <returns> le tableau de case</returns>
		int** remplirCarte() {return Algo_remplirCarte(algo); }

		/// <summary>
		/// Algo effectuant le placement des joueurs 
		/// </summary>
		/// <param name="xJ1"> Param modifié indiquant la position en x du joueur 1 </param>
		/// <param name="yJ1"> Param modifié indiquant la position en y du joueur 1 </param>
		/// <param name="xJ2"> Param modifié indiquant la position en x du joueur 2 </param>
		/// <param name="yJ2"> Param modifié indiquant la position en y du joueur 2 </param>
		/// <returns> Une carte vide</returns>
		void positionJoueur(int* xJ1,int* yJ1,int* xJ2,int* yJ2) {Algo_positionJoueur(algo,xJ1,yJ1,xJ2,yJ2); }

		/// <summary>
		/// Algo effectuant le placement des joueurs 
		/// </summary>
		/// <param name="taille">Selon la taille de la carte</param>
		/// <param name="xJ1"> Param modifié indiquant la position en x du joueur 1 </param>
		/// <param name="yJ1"> Param modifié indiquant la position en y du joueur 1 </param>
		/// <param name="xJ2"> Param modifié indiquant la position en x du joueur 2 </param>
		/// <param name="yJ2"> Param modifié indiquant la position en y du joueur 2 </param>
		static void positionJoueurParTaille(int taille, int* xJ1,int* yJ1,int* xJ2,int* yJ2) {Algo_positionJoueurParTaille(taille,xJ1,yJ1,xJ2,yJ2); }

		/// <summary>
		/// Algo donnant le type précis d'une carte
		/// </summary>
		/// <param name="x"> la ligne de la case</param>
		/// <param name="y"> la colonne de la case</param>
		/// <returns> Un entier (Enum) donnant le type de la carte</returns>		
		int getTypeCase(int x, int y){return Algo_getTypeCase(algo,x,y);}//peut retourner -1 si la case n'est pas bonne

		/// <summary>
		/// Getter de la carte
		/// </summary>
		/// <param name="algo">la carte non généré</param>
		/// <returns> le tableau de case</returns>
		Carte* getCarte(){return algo;}

		/// <summary>
		/// Refere si deux cases sont adjacentes
		/// </summary>
		/// <param name="x1"> valeur x de la case 1</param>
		/// <param name="y1"> valeur y de la case 1</param>
		/// <param name="x2"> valeur x de la case 2</param>
		/// <param name="y2"> valeur y de la case 2</param>
		/// <returns> v si (x1,y1) adjacent à (x2,y2)</returns>
		static Boolean isAdjacentCase(int x1, int y1,int x2, int y2){return Algo_isAdjacentCase(x1, y1, x2, y2);}

		/// <summary>
		/// Algo décidant du nombre d'affrontement entre deux unités
		/// </summary>
		/// <param name="pv1"> les pv de l'unité attaquante</param>
		/// <param name="pv2"> les pv de l'unité défendante</param>
		/// <returns> Une carte vide</returns>
		static int nbCombat(int pv1, int pv2){return Algo_ChoixNbDeCombat(pv1, pv2);}

		/// <summary>
		/// L'attaquant a-t-il gagné ?
		/// </summary>
		/// <param name="att"> l'attaque de l'unité attaquante</param>
		/// <param name="def"> l'attaque de l'unité defense</param>
		/// <param name="att"> son pourcentage d'attaque du au perte de pv</param>
		/// <param name="def"> son pourcentage de defense du au perte de pv</param>
		/// <returns> Une carte vide</returns>
		static Boolean LattaquantPerdUnPV(int attaque, int defense, int pourcentageAttaque, int pourcentageDefense){return Algo_CalculAttaque(attaque, defense, pourcentageAttaque, pourcentageDefense);}
	};

}

#endif

