using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_Heritage_Pt1
{
    class CompteBancaireRemunere : CompteBancaire
    {
        public double Remuneration { get; private set; }

        public CompteBancaireRemunere(string _titulaire, double _remuneration)
            : base(_titulaire)
        {
            this.Remuneration = _remuneration;
        }

        public void Crediter(double _depot)
        {
            this.Solde += _depot + this.Remuneration;
        }
    }
}
