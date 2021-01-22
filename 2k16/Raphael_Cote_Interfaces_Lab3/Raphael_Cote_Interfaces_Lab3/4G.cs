using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raphael_Cote_Interfaces_Lab3
{
    class _4G : IBaseCom
    {
        public void Ecrire()
        {
            Console.WriteLine("4G - Ecrire");
        }
        public void Connecter()
        {
            Console.WriteLine("4G - Connecter");
        }
        public void Lire()
        {
            Console.WriteLine("4G - Lire");
        }
        public void Deconnecter()
        {
            Console.WriteLine("4G - Deconnecter");
        }
    }
}
