using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_POO_.NET
{
    class Program
    {
        static void Main(string[] args)
        {
            Utilisateur AT = new Utilisateur("André", "Tremblay", 45);
            Utilisateur FL = new Utilisateur("Fernand", "Laberge", 50);
            Utilisateur HD = new Utilisateur("Hervé", "Dufour", 115);
            Utilisateur TL = new Utilisateur("Thierry", "Lefebvre", 28);
            Console.WriteLine(AT);
            Console.WriteLine(FL);
            Console.WriteLine(HD);
            Console.WriteLine(TL);

            Console.ReadKey(true);
        }
    }
}
