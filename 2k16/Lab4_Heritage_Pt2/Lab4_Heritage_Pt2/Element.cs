using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab4_Heritage_Pt2
{
    abstract class Element
    {

        public Point Pos { get; protected set; }
        public abstract void Update(List<Element> _environnement);
        public char Caractere { get; protected set; }
        protected int Energie { get; set; }
        public abstract int ValeurNutritive { get; }
        public bool EnVie { get { return Energie > 0; } }

        public Element(int _x, int _y)
        {
            Pos = new Point(_x, _y);
        }

        protected static void Tuer(Element _e)
        {
            _e.Energie = 0;
        }
    }
}
