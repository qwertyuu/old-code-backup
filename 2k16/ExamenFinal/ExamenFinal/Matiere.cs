using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenFinal
{
    enum TypeMateriel { Papier, Verre, Plastique }
    class Matiere
    {
        public TypeMateriel type { get; private set; }

        public Matiere(TypeMateriel _t)
        {
            this.type = _t;
        }
    }
}
