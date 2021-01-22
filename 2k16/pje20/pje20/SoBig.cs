using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pje20
{
    class SoBig
    {
        bool[] binaire;
        
        public SoBig()
        {
            binaire = new bool[530];

        }

        public void ShiftLeft(int _diff)
        {
            for (int i = 0; i + _diff < binaire.Length; i++)
            {
                binaire[i] = binaire[i + _diff];
            }
        }

        public void ShiftRight(int _diff)
        {
            for (int i = binaire.Length - 1; i - _diff >= 0; i--)
            {
                binaire[i] = binaire[i - _diff];
            }
        }
    }
}
