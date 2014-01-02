

#ifdef WANTDLLEXP
#define DLL _declspec(dllexport)
#define EXTERNC extern "C"
#else
#define DLL
#define EXTERNC
#endif


enum {MONTAGNE=0,PLAINE,DESERT,EAU,FORET, NB_MAX_LANDSCAPE};

class DLL Carte {
public:
	int** tabCases;// tab gérant les cases de la Carte, les entiers correspondent aux type de case possibles : en 2D.
	int nbressource;// Le nombre de ressource de la carte.
	int taille;
	int** tabRessources;

	


public:
Carte() {}
~Carte() {}
int computeFoo();
};

// A ne pas implémenter dans le .h !
EXTERNC DLL Carte* Carte_new(int n);
EXTERNC DLL void Carte_delete(Carte* carte);
EXTERNC DLL int** Algo_remplirCarte(Carte* algo);
EXTERNC DLL void Algo_placer_joueurs(Carte* algo);
EXTERNC DLL void Algo_positionJoueur(Carte* algo,int* xJ1,int* yJ1,int* xJ2,int* yJ2);
EXTERNC DLL void Algo_positionJoueurParTaille(int taille,int* xJ1,int* yJ1,int* xJ2,int* yJ2);
EXTERNC DLL int Algo_getTypeCase(Carte* algo, int x, int y);
EXTERNC DLL bool Algo_isAdjacentCase(int x1, int y1, int x2, int y2);