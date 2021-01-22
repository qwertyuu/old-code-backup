using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_Heritage_Pt2
{
    class Predateur : Animal
    {
        public override int ValeurNutritive
        {
            get { return 0; }
        }

        public Predateur(int _x, int _y)
            : base(_x, _y)
        {
            this.Caractere = '#';
            ElementsImportants = new List<Type>() { 
                typeof(Proie),
                typeof(Eau)
            };
        }

        protected override void FaireAction()
        {
            if (Point.Distance(this.Pos, Cible.Pos) < PorteeDeDeplacement)
            {
                this.Manger(Cible);
            }
            else
            {
                this.Pos.AvancerSelonAngleEtDistance(Point.AngleEntre(this.Pos, Cible.Pos), PorteeDeDeplacement);
            }
        }

        protected override void DeterminerCible(Element _plusPres)
        {
            if (_plusPres is Proie)
            {
                (_plusPres as Proie).SeFairePourchasser(this);
            }
            Cible = _plusPres;
            Etat = Action.Mouvement;
        }

        public bool Occupe { get { return Etat == Action.Mouvement; } }
    }
}
