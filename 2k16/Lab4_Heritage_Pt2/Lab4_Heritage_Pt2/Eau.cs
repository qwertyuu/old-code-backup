using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_Heritage_Pt2
{
    class Eau : Nature
    {
        private static Random dé;
        public Eau(int _x, int _y)
            : base(_x, _y)
        {
            if (dé == null)
            {
                dé = new Random();
            }
            Caractere = '~';
            Energie = dé.Next(30,120);
        }

        public override int ValeurNutritive
        {
            get { return this.Energie; }
        }
        protected override void GererEnergie()
        {
            Energie--;
        }
    }
}
