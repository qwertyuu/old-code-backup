using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_Heritage_Pt2
{
    abstract class Nature : Element
    {

        public Nature(int _x, int _y)
            : base(_x, _y)
        {
            Caractere = 'N';
        }

        public override void Update(List<Element> _environnement)
        {
            GererEnergie();
        }

        protected abstract void GererEnergie();
    }
}
