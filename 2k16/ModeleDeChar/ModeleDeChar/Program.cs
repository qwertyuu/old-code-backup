using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeleDeChar
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Automobile.JeSuisQuoi());

            Automobile monChar = new Automobile()
            {
                Poids = 80,
                Couleur = "Bleu",
                Kilometrage = 100000,
                Modele = "Pontiac"
            };

            Automobile tonChar = new Automobile()
            {
                Poids = 50,
                Couleur = "Orange",
                Kilometrage = 2,
                Modele = "Tank"
            };

            Console.WriteLine(monChar.publicRouille());
            Console.WriteLine(tonChar.Modele);
            Console.ReadLine();

        }
    }
}
