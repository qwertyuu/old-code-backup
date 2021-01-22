using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raphael_Cote_Interfaces_Lab3_Pt3
{
    class Client
    {
        public CompteBancaire Compte { get; private set; }
        public Client()
        {
            DemanderNAS();
        }

        private void DemanderNAS()
        {
            Compte = new CompteBancaire(Console.ReadLine());
        }
    }
}
