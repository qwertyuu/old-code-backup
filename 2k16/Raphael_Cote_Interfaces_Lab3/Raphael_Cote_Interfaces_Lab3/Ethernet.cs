using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raphael_Cote_Interfaces_Lab3
{
    class Ethernet : IBaseCom
    {
        public void Ecrire()
        {
            Console.WriteLine("Ethernet - Ecrire");
        }
        public void Connecter()
        {
            Console.WriteLine("Ethernet - Connecter");
        }
        public void Lire()
        {
            Console.WriteLine("Ethernet - Lire");
        }
        public void Deconnecter()
        {
            Console.WriteLine("Ethernet - Deconnecter");
        }
    }
}
