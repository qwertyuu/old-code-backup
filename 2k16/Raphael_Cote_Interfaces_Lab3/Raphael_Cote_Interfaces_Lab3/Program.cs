using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raphael_Cote_Interfaces_Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            bool quitter = false;
            while (!quitter)
            {
                Console.WriteLine("Menu Principal\n1 : 4G\n2 : WiFi\n3 : Ethernet\n\n0 : Quitter\nVotre choix :");
                var key = Console.ReadKey();
                Console.WriteLine();
                IBaseCom com = null;
                switch (key.Key)
                {
                    case ConsoleKey.D0:
                        quitter = true;
                        break;
                    case ConsoleKey.D1:
                        com = new _4G();
                        break;
                    case ConsoleKey.D2:
                        com = new WiFi();
                        break;
                    case ConsoleKey.D3:
                        com = new Ethernet();
                        break;
                }
                if (com != null)
                {
                    com.Connecter();
                    com.Ecrire();
                    com.Lire();
                    com.Deconnecter();
                }
                Console.WriteLine('\n');
            }


        }
    }
}