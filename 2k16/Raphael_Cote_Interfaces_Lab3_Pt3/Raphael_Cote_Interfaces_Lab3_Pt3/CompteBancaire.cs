using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raphael_Cote_Interfaces_Lab3_Pt3
{
    class CompteBancaire
    {
        public string NAS { get; private set; }
        public CompteBancaire(string NAS)
        {
            this.NAS = NAS;
        }
    }
}
