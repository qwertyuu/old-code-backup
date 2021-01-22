using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab4_Heritage_Pt2
{
    class Proie : Animal
    {
        public override int ValeurNutritive
        {
            get { return 50; }
        }
        public Proie(int _x, int _y)
            : base(_x, _y)
        {
            this.Caractere = '$';
            ElementsImportants = new List<Type>() { 
                typeof(Eau),
                typeof(Plante)
            };
        }

        public void SeFairePourchasser(Predateur _chasseur)
        {
            Cible = _chasseur;
            Etat = Action.Mouvement;
        }

        protected override void FaireAction()
        {
            if (Cible is Predateur)
            {
                this.Pos.AvancerSelonAngleEtDistance(Point.AngleEntre(this.Pos, Cible.Pos) + Math.PI, PorteeDeDeplacement);
            }
            else if (Point.Distance(this.Pos, Cible.Pos) < PorteeDeDeplacement)
            {
                this.Manger(Cible);
            }
            else
            {
                this.Pos.AvancerSelonAngleEtDistance(Point.AngleEntre(this.Pos, Cible.Pos), PorteeDeDeplacement);
            }
        }
    }
}
