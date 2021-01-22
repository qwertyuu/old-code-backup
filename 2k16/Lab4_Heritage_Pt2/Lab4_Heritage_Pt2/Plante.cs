using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_Heritage_Pt2
{
    class Plante : Nature
    {
        public Plante(int _x, int _y)
            : base(_x, _y)
        {
            Caractere = '*';
            Energie = 1;
        }

        protected override void GererEnergie()
        {
            Energie++;
        }

        public override int ValeurNutritive
        {
            get { return Energie; }
        }

    }
}
