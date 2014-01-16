

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
	bool verifChemin(int i, int j, Carte* algo,int mode);
};

/// <summary>
/// Constructeur d'une carte
/// </summary>
/// <param name="n"> taille de la carte</param>
/// <returns> Une carte vide</returns>
EXTERNC DLL Carte* Carte_new(int n);

/// <summary>
/// Constructeur d'une carte
/// </summary>
/// <param name="n"> taille de la carte</param>
EXTERNC DLL void Carte_delete(Carte* carte);

/// <summary>
/// Algo de generation d'une carte
/// </summary>
/// <param name="algo">la carte non généré</param>
/// <returns> le tableau de case</returns>
EXTERNC DLL int** Algo_remplirCarte(Carte* algo);

/// <summary>
/// Algo effectuant le placement des joueurs
/// </summary>
/// <param name="algo">la carte</param>
EXTERNC DLL void Algo_placer_joueurs(Carte* algo);

/// <summary>
/// Algo effectuant le placement des joueurs 
/// </summary>
/// <param name="algo">la carte</param>
/// <param name="xJ1"> Param modifié indiquant la position en x du joueur 1 </param>
/// <param name="yJ1"> Param modifié indiquant la position en y du joueur 1 </param>
/// <param name="xJ2"> Param modifié indiquant la position en x du joueur 2 </param>
/// <param name="yJ2"> Param modifié indiquant la position en y du joueur 2 </param>
/// <returns> Une carte vide</returns>
EXTERNC DLL void Algo_positionJoueur(Carte* algo,int* xJ1,int* yJ1,int* xJ2,int* yJ2);

/// <summary>
/// Algo effectuant le placement des joueurs 
/// </summary>
/// <param name="taille">Selon la taille de la carte</param>
/// <param name="xJ1"> Param modifié indiquant la position en x du joueur 1 </param>
/// <param name="yJ1"> Param modifié indiquant la position en y du joueur 1 </param>
/// <param name="xJ2"> Param modifié indiquant la position en x du joueur 2 </param>
/// <param name="yJ2"> Param modifié indiquant la position en y du joueur 2 </param>
EXTERNC DLL void Algo_positionJoueurParTaille(int taille,int* xJ1,int* yJ1,int* xJ2,int* yJ2);

/// <summary>
/// Algo donnant le type précis d'une carte
/// </summary>
/// <param name="x"> la ligne de la case</param>
/// <param name="y"> la colonne de la case</param>
/// <returns> Un entier (Enum) donnant le type de la carte</returns>
EXTERNC DLL int Algo_getTypeCase(Carte* algo, int x, int y);

/// <summary>
/// Refere si deux cases sont adjacentes
/// </summary>
/// <param name="x1"> valeur x de la case 1</param>
/// <param name="y1"> valeur y de la case 1</param>
/// <param name="x2"> valeur x de la case 2</param>
/// <param name="y2"> valeur y de la case 2</param>
/// <returns> v si (x1,y1) adjacent à (x2,y2)</returns>
EXTERNC DLL bool Algo_isAdjacentCase(int x1, int y1, int x2, int y2);

/// <summary>
/// Algo décidant du nombre d'affrontement entre deux unités
/// </summary>
/// <param name="pv1"> les pv de l'unité attaquante</param>
/// <param name="pv2"> les pv de l'unité défendante</param>
/// <returns> Une carte vide</returns>
EXTERNC DLL int Algo_ChoixNbDeCombat(int pv1, int pv2);

/// <summary>
/// L'attaquant a-t-il gagné ?
/// </summary>
/// <param name="att"> l'attaque de l'unité attaquante</param>
/// <param name="def"> l'attaque de l'unité defense</param>
/// <param name="att"> son pourcentage d'attaque du au perte de pv</param>
/// <param name="def"> son pourcentage de defense du au perte de pv</param>
/// <returns> Une carte vide</returns>
EXTERNC DLL bool Algo_CalculAttaque(int attaque, int defense, int pourcentageAttaque, int pourcentageDefense);