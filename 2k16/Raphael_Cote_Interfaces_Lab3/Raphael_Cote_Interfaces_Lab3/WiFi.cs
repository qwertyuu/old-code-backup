using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raphael_Cote_Interfaces_Lab3
{
    class WiFi : IBaseCom
    {
        public void Ecrire()
        {
            Console.WriteLine("WiFi - Ecrire");
        }
        public void Connecter()
        {
            Console.WriteLine("WiFi - Connecter");
        }
        public void Lire()
        {
            Console.WriteLine("WiFi - Lire");
        }
        public void Deconnecter()
        {
            Console.WriteLine("WiFi - Deconnecter");
        }
    }
}
