using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallWorld
{
    public class SelectionOperateur
    {
        public int xdepart, ydepart, xdarrivee, ydarrivee;
        public enum etatSelection { RienEstSelectionne, UniteDeDepartDelectionnee, UniteDarriveeSelectionnee };
        private etatSelection etat;


        public SelectionOperateur() {
            xdepart = 0;
            ydepart = 0;
            xdarrivee = 0;
            ydarrivee = 0;
            etat = etatSelection.RienEstSelectionne;
        }

        public void selectCase(int xCase, int yCase) {
            if (etat == etatSelection.RienEstSelectionne) {
                xdepart = xCase;
                ydepart = yCase;
                etat = etatSelection.UniteDeDepartDelectionnee;
            } else if (etat == etatSelection.UniteDeDepartDelectionnee) {
                xdarrivee = xCase;
                ydarrivee = yCase;
                etat = etatSelection.UniteDarriveeSelectionnee;
            }
        }

        unsafe public Boolean getSelectedCases(int* xdep, int* ydep, int* xarr,int* yarr) {
            if (etat != etatSelection.UniteDarriveeSelectionnee)
            {
                return false;
            }
            else
            {
                *xdep = xdepart;
                *ydep = ydepart;
                *xarr = xdarrivee;
                *yarr = ydarrivee;
                return true;
            }
        }

        public void FinDeSelection() {
            etat = etatSelection.RienEstSelectionne;
        }

        public etatSelection getEtatSelection() { return etat; }
    }
}
