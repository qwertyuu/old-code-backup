using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_Heritage_Pt2
{
    abstract class Animal : Element
    {
        protected enum Action { Recherche, Mouvement }

        public double Vitesse { get; protected set; }
        protected double Rayon { get; set; }
        protected List<Type> ElementsImportants { get; set; }
        protected Element Cible { get; set; }
        private static Random rand;

        public double PorteeDeDeplacement { get; set; }
        protected Action Etat { get; set; }

        public Animal(int _x, int _y)
            : base(_x, _y)
        {
            Energie = 100;
            Rayon = 15;
            Etat = Action.Recherche;
            Caractere = 'A';
            PorteeDeDeplacement = 1;
            if (rand == null)
            {
                rand = new Random();
            }
        }

        public override void Update(List<Element> _environnement)
        {
            switch (Etat)
            {
                case Action.Recherche:
                    this.Scan(_environnement);
                    break;
                case Action.Mouvement:
                    if (Cible.EnVie)
                    {
                        this.FaireAction();
                        this.Energie--;
                    }
                    else
                    {
                        this.Etat = Action.Recherche;
                    }
                    break;
            }
        }

        private void Scan(List<Element> _environnement)
        {
            Element plusPres = null;
            double rayonPlusPres = this.Rayon * this.Rayon;
            foreach (var item in _environnement)
            {
                double dist = Point.Distance(this.Pos, item.Pos);

                if (dist < rayonPlusPres && ElementsImportants.Contains(item.GetType()))
                {
                    rayonPlusPres = dist;
                    plusPres = item;
                }
            }
            if (plusPres != null)
            {
                DeterminerCible(plusPres);
            }
            else
            {
                BougerAleatoirement();
            }
        }

        private void BougerAleatoirement()
        {
            this.Pos.AvancerSelonAngleEtDistance(rand.Next(), this.PorteeDeDeplacement);
            this.Energie--;
        }

        protected virtual void Manger(Element _buffet)
        {
            this.Energie += _buffet.ValeurNutritive;
            Element.Tuer(_buffet);
            this.Etat = Action.Recherche;
        }

        protected abstract void FaireAction();
        protected virtual void DeterminerCible(Element _plusPres)
        {
            Cible = _plusPres;
            Etat = Action.Mouvement;
        }
    }
}
